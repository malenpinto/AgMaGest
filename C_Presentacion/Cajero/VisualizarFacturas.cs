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
    public partial class VisualizarFacturas : Form
    {
        public VisualizarFacturas()
        {
            InitializeComponent();
            this.Load += Facturas_Load; // Maneja el evento Load para inicializar la vista
        }

        private void Facturas_Load(object sender, EventArgs e)
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
            dataGridFacturas.Columns.Add("NumFactura", "Número de Factura");
            dataGridFacturas.Columns["NumFactura"].DataPropertyName = "NumFactura";

            dataGridFacturas.Columns.Add("FechaFactura", "Fecha de la Factura");
            dataGridFacturas.Columns["FechaFactura"].DataPropertyName = "FechaFactura";
            dataGridFacturas.Columns["FechaFactura"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridFacturas.Columns.Add("TotalFactura", "Total de la Factura");
            dataGridFacturas.Columns["TotalFactura"].DataPropertyName = "TotalFactura";

            dataGridFacturas.Columns.Add("IdPago", "ID del Pago");
            dataGridFacturas.Columns["IdPago"].DataPropertyName = "IdPago";

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


    }
}