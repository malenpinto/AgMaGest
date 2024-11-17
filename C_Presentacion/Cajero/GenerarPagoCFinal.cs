using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Cajero
{
    public partial class GenerarPagoCFinal : Form
    {
        public GenerarPagoCFinal(string cuilCuit, Pedido pedido)
        {
            InitializeComponent();
            CargarDatosCliente(cuilCuit);
            CargarDatosPedido(pedido);
            CargarTipoPago();
            ConfigurarCamposNoEditables();
        }

        private void CargarDatosCliente(string cuilCuit)
        {
            ClienteFinalDAL clienteDAL = new ClienteFinalDAL();
            ClienteFinal cliente = clienteDAL.ObtenerClienteFinalPorCUIL(cuilCuit);

            if (cliente != null)
            {
                TBNombrePagoCFinal.Text = cliente.NombreCFinal;
                TBApellidoPagoCFinal.Text = cliente.ApellidoCFinal;
                TBDniPagoCFinal.Text = cliente.DniCFinal;
                TBCuilPagoCFinal.Text = cliente.CuilCFinal;
                TBEmailPagoCFinal.Text = cliente.EmailCliente;
                TBCelularPagoCFinal.Text = cliente.CelularCliente;
            }
        }

        private void CargarDatosPedido(Pedido pedido)
        {
            TBVehiculoPago.Text = pedido.DetallesVehiculo;
            TBNumPedido.Text = pedido.IdPedido.ToString();
            TBFechaPedido.Text = pedido.FechaPedido.ToString("dd/MM/yyyy");
            TBMontoPago.Text = pedido.MontoPedido.ToString();
        }

        private void ConfigurarCamposNoEditables()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    ((TextBox)control).ReadOnly = true;
            }
        }

        private void CargarTipoPago()
        {
            // Obtener la lista de perfiles desde la base de datos
            TipoPagoDAL tipoPagoDAL = new TipoPagoDAL();
            List<TipoPago> tipos = tipoPagoDAL.ObtenerTipoPago();

            // Agregar una opción por defecto "Seleccione una"
            tipos.Insert(0, new TipoPago { IdTipoPago = 0, NombreTipoPago = "Seleccione un tipo" });

            // Asignar la lista al ComboBox
            CBMediosPagos.DataSource = tipos; // Asignar la lista de perfiles al ComboBox
            CBMediosPagos.DisplayMember = "NombreTipoPago"; // Campo que se mostrará en el ComboBox
            CBMediosPagos.ValueMember = "IdTipoPago"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBMediosPagos.SelectedIndex = 0;
        }

        private void BConfirmarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (CBMediosPagos.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Debe seleccionar un perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear el objeto Pago con los datos ingresados
                Pago nuevoPago = new Pago
                {
                    Descripcion = TBDescPago.Text,
                    Importe = (Double)decimal.Parse(TBMontoPago.Text),
                    IdTipoPago = Convert.ToInt32(CBMediosPagos.SelectedValue),
                    IdEstadoPago = 1,  // Estado inicial del pago
                    IdPedido = int.Parse(TBNumPedido.Text)
                };

                PagoDAL pagoDAL = new PagoDAL();

                // Insertar el nuevo pago
                bool pagoInsertado = pagoDAL.InsertarPago(nuevoPago);

                if (pagoInsertado)
                {
                    PedidoDAL pedidoDAL = new PedidoDAL();
                    int idPedido = nuevoPago.IdPedido;

                    // Actualizar el estado del pedido a 2
                    bool estadoActualizado = pedidoDAL.ActualizarEstadoPedido(idPedido, 2);

                    if (estadoActualizado)
                    {
                        // Crear y registrar la factura
                        Factura nuevaFactura = new Factura
                        {
                            FechaFactura = DateTime.Now,  // Fecha actual
                            TotalFactura = (double)nuevoPago.Importe,  // Total igual al importe del pago
                            IdPago = nuevoPago.IdPago  // ID del pago recién insertado
                        };

                        FacturaDAL facturaDAL = new FacturaDAL();
                        bool facturaGenerada = facturaDAL.InsertarFactura(nuevaFactura);

                        if (facturaGenerada)
                        {
                            // Actualizar el estado del pago a 1 (confirmado)
                            bool estadoPagoActualizado = pagoDAL.ActualizarEstadoPago(nuevoPago.IdPago, 1);

                            if (estadoPagoActualizado)
                            {
                                // Obtener el idCliente asociado al pedido
                                int idCliente = pedidoDAL.ObtenerIdClientePorPedido(idPedido);

                                if (idCliente > 0)
                                {
                                    ClienteDAL clienteDAL = new ClienteDAL();
                                    bool estadoClienteActualizado = clienteDAL.ActualizarEstadoCliente(idCliente, 1);

                                    if (estadoClienteActualizado)
                                    {
                                        MessageBox.Show($"Pago registrado, estado del pedido y cliente actualizados, y factura #{nuevaFactura.NumFactura} generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error al actualizar el estado del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("No se encontró el cliente asociado al pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar el estado del pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar el estado del pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error al registrar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BSalirGenerarPago_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
