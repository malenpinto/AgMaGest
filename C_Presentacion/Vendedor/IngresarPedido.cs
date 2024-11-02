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

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class IngresarPedido : Form
    {
        public IngresarPedido()
        {
            InitializeComponent();
        }

        private void BSalirPedido_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BConfirmarPedido_Click(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un cliente y otros datos necesarios
            if (string.IsNullOrEmpty(txtCUILCliente.Text) ||
                string.IsNullOrEmpty(txtNumFactura.Text) ||
                string.IsNullOrEmpty(txtIdCliente.Text))
            {
                MessageBox.Show("Debe seleccionar un cliente y completar todos los campos obligatorios.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Crear un nuevo objeto Pedido con los datos del formulario
                Pedido pedido = new Pedido
                {
                    CUIL = txtCUILCliente.Text,
                    NumFactura = int.Parse(txtNumFactura.Text),
                    IdCliente = int.Parse(txtIdCliente.Text),
                    FechaPedido = DateTime.Now // Toma la fecha y hora actual
                };

                // Insertar el pedido usando PedidoDAL
                PedidoDAL pedidoDAL = new PedidoDAL();
                pedidoDAL.InsertarPedido(pedido);

                MessageBox.Show("Pedido registrado exitosamente con ID: " + pedido.IdPedido,
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar campos después de guardar
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el pedido: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtCUILCliente.Clear();
            txtNumFactura.Clear();
            txtIdCliente.Clear();
            // Limpia otros campos si es necesario
        }

        private void BBuscarPedido_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = TBBuscarPedido.Text;

            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClienteDAL clienteDAL = new ClienteDAL();
            Cliente cliente = clienteDAL.ObtenerClientePorCUILoNombre(criterioBusqueda);

            if (cliente != null)
            {
                txtNombreCliente.Text = cliente.Nombre;
                txtCUILCliente.Text = cliente.CUIL;
                txtDNICliente.Text = cliente.DNI;
                txtEmailCliente.Text = cliente.Email;
                txtCelularCliente.Text = cliente.Celular;
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
