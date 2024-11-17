using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Cajero
{
    public partial class VisualizarPagos : Form
    {
        public VisualizarPagos()
        {
            InitializeComponent();
            this.Load += new EventHandler(VisualizarPagos_Load);
            dataGridPagos.CellFormatting += DataGridPagos_CellFormatting;
        }

        private void VisualizarPagos_Load(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void CargarPagos()
        {
            try
            {
                ConfigurarDataGridView();
                dataGridPagos.AutoGenerateColumns = false;

                PagoDAL pagoDAL = new PagoDAL();
                List<Pago> listaPagos = pagoDAL.ObtenerPagos();

                if (listaPagos != null && listaPagos.Count > 0)
                {
                    dataGridPagos.DataSource = new BindingList<Pago>(listaPagos);
                }
                else
                {
                    MessageBox.Show("No se encontraron pagos en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar configuraciones previas
            dataGridPagos.Columns.Clear();

            // Configurar columnas estándar
            dataGridPagos.Columns.Add("IdPago", "ID Pago");
            dataGridPagos.Columns["IdPago"].DataPropertyName = "IdPago";

            dataGridPagos.Columns.Add("NombreEstadoPago", "Estado del Pago");
            dataGridPagos.Columns["NombreEstadoPago"].DataPropertyName = "NombreEstadoPago";

            dataGridPagos.Columns.Add("NombreTipoPago", "Tipo de Pago");
            dataGridPagos.Columns["NombreTipoPago"].DataPropertyName = "NombreTipoPago";

            dataGridPagos.Columns.Add("Descripcion", "Descripcion");
            dataGridPagos.Columns["Descripcion"].DataPropertyName = "Descripcion";

            dataGridPagos.Columns.Add("Importe", "Importe");
            dataGridPagos.Columns["Importe"].DataPropertyName = "Importe";

            dataGridPagos.Columns.Add("CUIL_Empleado", "CUIL Empleado");
            dataGridPagos.Columns["CUIL_Empleado"].DataPropertyName = "CUIL_Empleado";

            dataGridPagos.Columns.Add("NombreCompleto", "Nombre Completo");
            dataGridPagos.Columns["NombreCompleto"].DataPropertyName = "NombreCompleto";

            dataGridPagos.Columns.Add("CUIL_Cliente", "CUIL del Cliente");
            dataGridPagos.Columns["CUIL_Cliente"].DataPropertyName = "CUIL_Cliente";

            dataGridPagos.Columns.Add("NombreCliente", "Nombre del Cliente");
            dataGridPagos.Columns["NombreCliente"].DataPropertyName = "NombreCliente";

            dataGridPagos.Columns.Add("DetallesVehiculo", "Detalles del Vehículo");
            dataGridPagos.Columns["DetallesVehiculo"].DataPropertyName = "DetallesVehiculo";

            // Configuraciones generales del DataGridView
            dataGridPagos.AutoGenerateColumns = false;
            dataGridPagos.AllowUserToAddRows = false;
            dataGridPagos.ReadOnly = true;
        }

        private void BBuscarPagos_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = TBBuscarPagos.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar los pedidos
                PagoDAL pagooDAL = new PagoDAL();
                List<Pago> pagosFiltrados = pagooDAL.BuscarPagos(criterioBusqueda);

                if (pagosFiltrados != null && pagosFiltrados.Count > 0)
                {
                    // Cargar solo los pedidos filtrados
                    dataGridPagos.DataSource = new BindingList<Pago>(pagosFiltrados);
                }
                else
                {
                    MessageBox.Show("No se encontraron pagos con el criterio ingresado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar todos los pedidos solo si el DataGridView está vacío o no tiene datos relevantes
                    if (dataGridPagos.Rows.Count == 0 || dataGridPagos.DataSource == null)
                    {
                        CargarPagos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar los pagos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BRefrescarPagos_Click(object sender, EventArgs e)
        {
            CargarPagos();
        }

        private void DataGridPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridPagos.Columns[e.ColumnIndex].Name == "NombreEstadoPago")
            {
                string estadoPedido = e.Value?.ToString();

                if (!string.IsNullOrEmpty(estadoPedido))
                {
                    switch (estadoPedido.ToLower())
                    {
                        case "pagado":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.Black;
                            break;

                        case "pendiente":
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.Black;
                            break;

                        default:
                            e.CellStyle.BackColor = Color.White;
                            e.CellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }
    }
}
