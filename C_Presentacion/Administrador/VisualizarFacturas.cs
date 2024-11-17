using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


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
                dataGridFacturas.AutoGenerateColumns = false;

                FacturaDAL facturaDAL = new FacturaDAL(); 
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

            dataGridFacturas.Columns.Add("CUIL_Empleado", "CUIL Empleado");
            dataGridFacturas.Columns["CUIL_Empleado"].DataPropertyName = "CUIL_Empleado";

            dataGridFacturas.Columns.Add("NombreCompleto", "Nombre Completo");
            dataGridFacturas.Columns["NombreCompleto"].DataPropertyName = "NombreCompleto";

            dataGridFacturas.Columns.Add("CUIL_Cliente", "CUIL del Cliente");
            dataGridFacturas.Columns["CUIL_Cliente"].DataPropertyName = "CUIL_Cliente";

            dataGridFacturas.Columns.Add("NombreCliente", "Nombre del Cliente");
            dataGridFacturas.Columns["NombreCliente"].DataPropertyName = "NombreCliente";

            dataGridFacturas.Columns.Add("DetallesVehiculo", "Detalles del Vehículo");
            dataGridFacturas.Columns["DetallesVehiculo"].DataPropertyName = "DetallesVehiculo";

            dataGridFacturas.Columns.Add("TotalFactura", "Total de la Factura");
            dataGridFacturas.Columns["TotalFactura"].DataPropertyName = "TotalFactura";


            // Configuraciones generales del DataGridView
            dataGridFacturas.AutoGenerateColumns = false;
            dataGridFacturas.AllowUserToAddRows = false;
            dataGridFacturas.ReadOnly = true;
        }

        private void BBuscarFactura_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = TBBuscarFactura.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar las facturas
                FacturaDAL facturaDAL = new FacturaDAL();
                List<Factura> facturasFiltradas = facturaDAL.BuscarFacturas(criterioBusqueda);

                if (facturasFiltradas != null && facturasFiltradas.Count > 0)
                {
                    // Cargar solo las facturas filtradas
                    dataGridFacturas.DataSource = new BindingList<Factura>(facturasFiltradas);
                }
                else
                {
                    MessageBox.Show("No se encontraron facturas con el criterio ingresado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar todas las facturas solo si el DataGridView está vacío o no tiene datos relevantes
                    if (dataGridFacturas.Rows.Count == 0 || dataGridFacturas.DataSource == null)
                    {
                        CargarFacturas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar las facturas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BRefrescarFacturas_Click(object sender, EventArgs e)
        {
            CargarFacturas();
        }

        private void BDescargar_Click(object sender, EventArgs e)
        {
            if (dataGridFacturas.SelectedRows.Count > 0)
            {
                // Obtener la factura seleccionada
                Factura facturaSeleccionada = dataGridFacturas.SelectedRows[0].DataBoundItem as Factura;

                if (facturaSeleccionada != null)
                {
                    GenerarPDF(facturaSeleccionada);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información de la factura seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para generar el PDF de la factura.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GenerarPDF(Factura factura)
        {
            try
            {
                // Crear un nuevo documento PDF
                PdfDocument documento = new PdfDocument();
                documento.Info.Title = $"Factura {factura.NumFactura}";

                // Agregar una página al documento
                PdfPage pagina = documento.AddPage();
                pagina.Size = PdfSharp.PageSize.A4; // Establecer tamaño A4

                // Crear un objeto para dibujar en la página
                XGraphics graficos = XGraphics.FromPdfPage(pagina);

                // Definir fuentes
                XFont fuenteTitulo = new XFont("Arial", 14, XFontStyleEx.Bold);
                XFont fuenteSubtitulo = new XFont("Arial", 14, XFontStyleEx.Bold);
                XFont fuenteNormal = new XFont("Arial", 10);

                // Coordenadas iniciales
                double posY = 40;

                // Dibujar Encabezado
                graficos.DrawRectangle(XPens.Black, new XRect(40, posY, 500, 50));
                graficos.DrawString("Factura", fuenteTitulo, XBrushes.Black, new XPoint(40, posY));
                posY += 20;

                graficos.DrawString($"Fecha: {factura.FechaFactura:dd/MM/yyyy}", fuenteNormal, XBrushes.Black, new XPoint(40, posY));
                graficos.DrawString($"N.º de Factura: {factura.NumFactura}", fuenteNormal, XBrushes.Black, new XPoint(300, posY));
                posY += 20;

                graficos.DrawString($"Id. de Cliente: {factura.CUIL_Cliente}", fuenteNormal, XBrushes.Black, new XPoint(40, posY));
                graficos.DrawString($"Para: {factura.NombreCliente}", fuenteNormal, XBrushes.Black, new XPoint(300, posY));
                posY += 40;

                // Dibujar Detalles del Vendedor
                graficos.DrawString("Vendedor", fuenteSubtitulo, XBrushes.Black, new XPoint(40, posY));
                posY += 20;

                graficos.DrawString($"Nombre: {factura.NombreCompleto}", fuenteNormal, XBrushes.Black, new XPoint(40, posY));
                graficos.DrawString($"CUIL: {factura.CUIL_Empleado}", fuenteNormal, XBrushes.Black, new XPoint(300, posY));
                posY += 20;

                graficos.DrawString($"Condiciones de Pago: Contado", fuenteNormal, XBrushes.Black, new XPoint(40, posY));
                posY += 40;

                // Dibujar Tabla de Detalles
                graficos.DrawString("DETALLES DEL VEHÍCULO", fuenteSubtitulo, XBrushes.Black, new XPoint(40, posY));
                posY += 20;

                graficos.DrawRectangle(XPens.Black, new XRect(40, posY, 500, 20));
                graficos.DrawString($"Descripción", fuenteNormal, XBrushes.Black, new XPoint(50, posY + 5));
                graficos.DrawString("Importe", fuenteNormal, XBrushes.Black, new XPoint(400, posY + 5));
                posY += 20;

                graficos.DrawRectangle(XPens.Black, new XRect(40, posY, 500, 20));
                graficos.DrawString(factura.DetallesVehiculo, fuenteNormal, XBrushes.Black, new XPoint(50, posY + 5));
                graficos.DrawString($"{factura.TotalFactura:C}", fuenteNormal, XBrushes.Black, new XPoint(400, posY + 5));
                posY += 40;

                // Dibujar Total de la Factura
                graficos.DrawString($"Total Factura: {factura.TotalFactura:C}", fuenteSubtitulo, XBrushes.Black, new XPoint(40, posY));
                posY += 40;

                // Dibujar Pie de Página
                graficos.DrawString("¡Gracias por su confianza!", fuenteNormal, XBrushes.Black, new XPoint(40, posY));
                posY += 20;

                graficos.DrawString("AgMaGest 2024 © | Corrientes, CP 3400 | Phone: 111-222-3333 | Fax: 111-222-3334",
                    fuenteNormal, XBrushes.Black, new XPoint(40, posY));

                // Guardar el archivo PDF
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Factura_{factura.NumFactura}.pdf");
                documento.Save(rutaArchivo);

                // Notificar al usuario
                MessageBox.Show($"PDF generado con éxito en: {rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir el archivo PDF
                System.Diagnostics.Process.Start(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DataGridFacturas_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridFacturas.SelectedRows.Count > 0)
            {
                BDescargar.Visible = true;
            }
            else
            {
                // Opcionalmente, ocultar los botones si no hay selección
                BDescargar.Visible = false;
            }
        }
    }
}
