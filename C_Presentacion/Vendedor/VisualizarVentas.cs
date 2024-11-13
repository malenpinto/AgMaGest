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
    public partial class VisualizarVentas : Form
    {
        public VisualizarVentas()
        {
            InitializeComponent();
            this.Load += new EventHandler(VisualizarVentas_Load);
        }

        private void VisualizarVentas_Load(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void CargarPedidos()
        {
            try
            {
                // Configura el DataGridView y establece AutoGenerateColumns a false
                ConfigurarDataGridView();
                dataGridVentas.AutoGenerateColumns = false;

                // Obtener los pedidos desde la base de datos
                PedidoDAL pedidoDAL = new PedidoDAL();
                List<Pedido> listaPedidos = pedidoDAL.ObtenerPedidos();

                if (listaPedidos != null && listaPedidos.Count > 0)
                {
                    dataGridVentas.DataSource = new BindingList<Pedido>(listaPedidos);
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar cualquier configuración previa
            dataGridVentas.Columns.Clear();

            // Configurar las columnas manualmente

            dataGridVentas.Columns.Add("IdPedido", "ID Pedido");
            dataGridVentas.Columns["IdPedido"].DataPropertyName = "IdPedido";

            dataGridVentas.Columns.Add("CUIL", "CUIL Empleado");
            dataGridVentas.Columns["CUIL"].DataPropertyName = "CUIL";

            dataGridVentas.Columns.Add("NombreEmpleado", "Nombre Empleado");
            dataGridVentas.Columns["NombreEmpleado"].DataPropertyName = "NombreEmpleado";

            dataGridVentas.Columns.Add("ApellidoEmpleado", "Apellido Empleado");
            dataGridVentas.Columns["ApellidoEmpleado"].DataPropertyName = "ApellidoEmpleado";

            dataGridVentas.Columns.Add("IdCliente", "ID Cliente");
            dataGridVentas.Columns["IdCliente"].DataPropertyName = "IdCliente";

            dataGridVentas.Columns.Add("IdVehiculo", "ID Vehículo");
            dataGridVentas.Columns["IdVehiculo"].DataPropertyName = "IdVehiculo";

            dataGridVentas.Columns.Add("FechaPedido", "Fecha del Pedido");
            dataGridVentas.Columns["FechaPedido"].DataPropertyName = "FechaPedido";
            dataGridVentas.Columns["FechaPedido"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridVentas.Columns.Add("MontoPedido", "Monto Pedido");
            dataGridVentas.Columns["MontoPedido"].DataPropertyName = "MontoPedido";
            dataGridVentas.Columns["MontoPedido"].DefaultCellStyle.Format = "MontoPedido"; 

            dataGridVentas.Columns.Add("IdEstadoPedido", "Estado Pedido");
            dataGridVentas.Columns["IdEstadoPedido"].DataPropertyName = "IdEstadoPedido";

        }
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener números.");
            }
        }

        private void BBuscarFacturas_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = TBBuscarFactura.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                PedidoDAL pedidoDAL = new PedidoDAL();
                List<Pedido> pedidosFiltrados = pedidoDAL.BuscarPedidos(criterioBusqueda);

                if (pedidosFiltrados.Count > 0)
                {
                    dataGridVentas.DataSource = new BindingList<Pedido>(pedidosFiltrados);
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos con el criterio ingresado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
