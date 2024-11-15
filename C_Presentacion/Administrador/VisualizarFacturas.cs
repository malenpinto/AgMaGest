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

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class VisualizarFacturas : Form
    {
        public VisualizarFacturas()
        {
            InitializeComponent();
            this.Load += FacturasAdmin_Load; // Maneja el evento Load para inicializar la vista
        }

        private void FacturasAdmin_Load(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void CargarFacturas()
        {
            try
            {
                ConfigurarDataGridView();

                FacturaDAL facturaDAL = new FacturaDAL(); // Clase para acceder a la base de datos
                List<Factura> listaFacturas = facturaDAL.ObtenerFacturas();

                if (listaFacturas != null && listaFacturas.Count > 0)
                {
                    dataGridFacturas.DataSource = new BindingList<Factura>(listaFacturas);
                }
                else
                {
                    MessageBox.Show("No se encontraron facturas en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar configuraciones previas
            dataGridFacturas.Columns.Clear();

            // Configurar columnas estándar
            dataGridFacturas.Columns.Add("FechaFactura", "Fecha de la Factura");
            dataGridFacturas.Columns["FechaFactura"].DataPropertyName = "FechaFactura";
            dataGridFacturas.Columns["FechaFactura"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridFacturas.Columns.Add("NumFactura", "Número de Factura");
            dataGridFacturas.Columns["NumFactura"].DataPropertyName = "NumFactura";

            dataGridFacturas.Columns.Add("Estado", "Estado");
            dataGridFacturas.Columns["Estado"].DataPropertyName = "Estado";

            var descargarButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DescargarFactura",
                HeaderText = "Descargar Factura",
                Text = "Descargar",
                UseColumnTextForButtonValue = true
            };
            dataGridFacturas.Columns.Add(descargarButtonColumn);

            dataGridFacturas.Columns.Add("CUIL_Empleado", "CUIL Empleado");
            dataGridFacturas.Columns["CUIL_Empleado"].DataPropertyName = "CUIL_Empleado";

            dataGridFacturas.Columns.Add("NombreCompleto", "Nombre Completo");
            dataGridFacturas.Columns["NombreCompleto"].DataPropertyName = "NombreCompleto";

            dataGridFacturas.Columns.Add("TotalFactura", "Total de la Factura");
            dataGridFacturas.Columns["TotalFactura"].DataPropertyName = "TotalFactura";

            // Configuraciones generales del DataGridView
            dataGridFacturas.AutoGenerateColumns = false;
            dataGridFacturas.AllowUserToAddRows = false;
            dataGridFacturas.ReadOnly = true;
            dataGridFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                FacturaDAL facturaDAL = new FacturaDAL();
                List<Factura> facturasFiltradas = facturaDAL.BuscarFacturas(criterioBusqueda);

                if (facturasFiltradas.Count > 0)
                {
                    dataGridFacturas.DataSource = new BindingList<Factura>(facturasFiltradas);
                }
                else
                {
                    MessageBox.Show("No se encontraron facturas con el criterio ingresado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el evento CellContentClick para el botón de descargar factura
        private void dataGridFacturas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridFacturas.Columns["DescargarFactura"].Index && e.RowIndex >= 0)
            {
                // Obtener la factura seleccionada
                Factura facturaSeleccionada = dataGridFacturas.Rows[e.RowIndex].DataBoundItem as Factura;
                if (facturaSeleccionada != null)
                {
                    // Implementa la lógica para descargar la factura
                    DescargarFactura(facturaSeleccionada);
                }
            }
        }

        private void DescargarFactura(Factura factura)
        {
            // Lógica para descargar la factura
            MessageBox.Show($"Descargando la factura número {factura.NumFactura}.", "Descarga", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Aquí puedes implementar la lógica específica para la descarga del archivo de la factura
        }
    }
}
