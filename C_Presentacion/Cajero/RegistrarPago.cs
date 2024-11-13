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
    public partial class RegistrarPago : Form
    {
        public RegistrarPago()
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
                dataGridPagos.AutoGenerateColumns = false;

                // Obtener los pedidos desde la base de datos
                PedidoDAL pedidoDAL = new PedidoDAL();
                List<Pedido> listaPedidos = pedidoDAL.ObtenerPedidos();

                if (listaPedidos != null && listaPedidos.Count > 0)
                {
                    dataGridPagos.DataSource = new BindingList<Pedido>(listaPedidos);
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
            dataGridPagos.Columns.Clear();

            // Configurar las columnas manualmente

            dataGridPagos.Columns.Add("IdPedido", "ID Pedido");
            dataGridPagos.Columns["IdPedido"].DataPropertyName = "IdPedido";

            dataGridPagos.Columns.Add("CUIL", "CUIL Empleado");
            dataGridPagos.Columns["CUIL"].DataPropertyName = "CUIL";

            dataGridPagos.Columns.Add("NombreEmpleado", "Nombre Empleado");
            dataGridPagos.Columns["NombreEmpleado"].DataPropertyName = "NombreEmpleado";

            dataGridPagos.Columns.Add("ApellidoEmpleado", "Apellido Empleado");
            dataGridPagos.Columns["ApellidoEmpleado"].DataPropertyName = "ApellidoEmpleado";

            dataGridPagos.Columns.Add("IdCliente", "ID Cliente");
            dataGridPagos.Columns["IdCliente"].DataPropertyName = "IdCliente";

            dataGridPagos.Columns.Add("IdVehiculo", "ID Vehículo");
            dataGridPagos.Columns["IdVehiculo"].DataPropertyName = "IdVehiculo";

            dataGridPagos.Columns.Add("FechaPedido", "Fecha del Pedido");
            dataGridPagos.Columns["FechaPedido"].DataPropertyName = "FechaPedido";
            dataGridPagos.Columns["FechaPedido"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridPagos.Columns.Add("MontoPedido", "Monto Pedido");
            dataGridPagos.Columns["MontoPedido"].DataPropertyName = "MontoPedido";
            dataGridPagos.Columns["MontoPedido"].DefaultCellStyle.Format = "MontoPedido";

            dataGridPagos.Columns.Add("IdEstadoPedido", "Estado Pedido");
            dataGridPagos.Columns["IdEstadoPedido"].DataPropertyName = "IdEstadoPedido";

        }


        private void BGenerarVenta_Click(object sender, EventArgs e)
        {
            GenerarPago formPago = new GenerarPago();
            formPago.ShowDialog();
        }
        private void BBuscarFacturas_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = textBox1.Text.Trim();

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
                    dataGridPagos.DataSource = new BindingList<Pedido>(pedidosFiltrados);
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
