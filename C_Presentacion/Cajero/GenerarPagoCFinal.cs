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

        public GenerarPagoCFinal()
        {
            InitializeComponent();
        }

        private void BSalirGenerarPago_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void GenerarPago_Load(object sender, EventArgs e)
        {
            try
            {
                //CargarDatosPedido();
                CargarMediosDePago();  // cargar opciones de medios de pago
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void CargarDatosPedido()
        {
            if (pedidoActual != null)
            {
                // Datos personales del cliente
                TBNombrePagoCFinal.Text = pedidoActual.Cliente.Nombre;
                TBApellidoPagoCFinal.Text = pedidoActual.Cliente.Apellido;
                TBDniPagoCFinal.Text = pedidoActual.Cliente.Dni;
                TBCuilPagoCFinal.Text = pedidoActual.Cliente.Cuil;
                DTPFechaNacPagoCFinal.Value = pedidoActual.Cliente.FechaNacimiento;
                TBCelularPagoCFinal.Text = pedidoActual.Cliente.Celular;
                TBEmailPagoCFinal.Text = pedidoActual.Cliente.Email;

                // Datos del pedido y monto
                TBVehiculoPagoCFinal.Text = pedidoActual.VehiculoDescripcion;
                TBCantidadPagoCFinal.Text = pedidoActual.Cantidad.ToString();
                TBMontoPagoCFinal.Text = pedidoActual.MontoTotal.ToString("C"); // Formato de moneda
            }
            else
            {
                MessageBox.Show("No se encontró el pedido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void CargarMediosDePago()
        {
            CBMediosPagos.Items.Add("Tarjeta de Crédito");
            CBMediosPagos.Items.Add("Tarjeta de Débito");
            CBMediosPagos.Items.Add("Efectivo");
            CBMediosPagos.Items.Add("Transferencia Bancaria");
            CBMediosPagos.SelectedIndex = 0;
        }

        private void BConfirmarPago_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                // Implementar la lógica para registrar el pago en la base de datos
                MessageBox.Show("Pago registrado correctamente.", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBNombrePagoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoPagoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBDniPagoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCuilPagoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBVehiculoPagoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCantidadPagoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBMontoPagoCFinal.Text))
            {
                MessageBox.Show("Debe completar todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
