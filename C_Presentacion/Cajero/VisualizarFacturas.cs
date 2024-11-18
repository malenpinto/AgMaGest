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

            dataGridFacturas.Columns.Add("NombreTipoPago", "Forma de pago");
            dataGridFacturas.Columns["NombreTipoPago"].DataPropertyName = "NombreTipoPago";

            dataGridFacturas.Columns.Add("TotalFactura", "Total de la Factura");
            dataGridFacturas.Columns["TotalFactura"].DataPropertyName = "TotalFactura";


            // Configuraciones generales del DataGridView
            dataGridFacturas.AutoGenerateColumns = false;
            dataGridFacturas.AllowUserToAddRows = false;
            dataGridFacturas.ReadOnly = true;
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

        private void BRefrescarFactura_Click(object sender, EventArgs e)
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
                pagina.Size = PdfSharp.PageSize.A4;

                // Crear un objeto para dibujar en la página
                XGraphics graficos = XGraphics.FromPdfPage(pagina);

                // Fuentes
                XFont fuenteTitulo = new XFont("Arial", 16, XFontStyleEx.Bold);
                XFont fuenteSubtitulo = new XFont("Arial", 12, XFontStyleEx.Bold);
                XFont fuenteNormal = new XFont("Arial", 10);
                XFont fuenteNegrita = new XFont("Arial", 10, XFontStyleEx.Bold);

                // Coordenadas iniciales
                double posX = 40; // Margen izquierdo
                double posY = 40; // Margen superior

                // Encabezado principal
                graficos.DrawImage(XImage.FromFile("logo.png"), posX, posY, 100, 50);
                graficos.DrawString("FACTURA", fuenteTitulo, XBrushes.Black, new XPoint(posX + 120, posY + 20));
                posY += 70;

                // Datos de la empresa
                graficos.DrawString("CONCESIONARIA: AUDEC S.A.", fuenteSubtitulo, XBrushes.Black, new XPoint(posX, posY));
                posY += 20;
                graficos.DrawString("CUIT: 30-70757091-9", fuenteNegrita, XBrushes.Black, new XPoint(posX, posY));
                graficos.DrawString("DIRECCIÓN: ", fuenteNegrita, XBrushes.Black, new XPoint(posX, posY + 15));
                graficos.DrawString("Av. Independencia 4280, CP 3400 Corrientes", fuenteNormal, XBrushes.Black, new XPoint(posX + 70, posY + 15));
                posY += 40;

                // Datos de la factura y cliente
                graficos.DrawString($"Fecha: {factura.FechaFactura:dd/MM/yyyy}", fuenteNormal, XBrushes.Black, new XPoint(posX, posY));
                graficos.DrawString($"N.º de Factura: {factura.NumFactura}", fuenteNormal, XBrushes.Black, new XPoint(posX + 300, posY));
                posY += 20;
                graficos.DrawString($"ID de Cliente: {factura.CUIL_Cliente}", fuenteNormal, XBrushes.Black, new XPoint(posX, posY));
                graficos.DrawString($"Cliente: {factura.NombreCliente}", fuenteNormal, XBrushes.Black, new XPoint(posX + 300, posY));
                posY += 40;

                // Encabezado de tabla
                graficos.DrawString("VENDEDOR", fuenteNegrita, XBrushes.Black, new XPoint(posX, posY));
                graficos.DrawString("CUIL", fuenteNegrita, XBrushes.Black, new XPoint(posX + 150, posY));
                graficos.DrawString("FORMA DE PAGO", fuenteNegrita, XBrushes.Black, new XPoint(posX + 300, posY));
                posY += 20;

                // Datos del vendedor
                graficos.DrawString(factura.NombreCompleto, fuenteNormal, XBrushes.Black, new XPoint(posX, posY));
                graficos.DrawString(factura.CUIL_Empleado, fuenteNormal, XBrushes.Black, new XPoint(posX + 150, posY));
                graficos.DrawString(factura.NombreTipoPago, fuenteNormal, XBrushes.Black, new XPoint(posX + 300, posY));
                posY += 40;

                // Detalles del vehículo
                graficos.DrawString("DETALLES DEL VEHÍCULO", fuenteNegrita, XBrushes.Black, new XPoint(posX, posY));
                posY += 20;
                graficos.DrawString(factura.DetallesVehiculo, fuenteNormal, XBrushes.Black, new XPoint(posX, posY));
                graficos.DrawString($"{factura.TotalFactura:C}", fuenteNormal, XBrushes.Black, new XPoint(posX + 400, posY));
                posY += 40;

                // Total factura
                graficos.DrawString("Total Factura", fuenteNegrita, XBrushes.Black, new XPoint(posX + 300, posY));
                graficos.DrawString($"{factura.TotalFactura:C}", fuenteNegrita, XBrushes.Black, new XPoint(posX + 400, posY));
                posY += 50;

                // Pie de página
                posY = pagina.Height - 50; // Ajustar cerca del borde inferior
                graficos.DrawString("¡Gracias por su confianza!", fuenteNormal, XBrushes.Black, new XPoint(posX, posY));
                posY += 20;
                graficos.DrawString("AgMaGest 2024 © | Corrientes, CP 3400 | Phone: 111-222-3333 | Fax: 111-222-3334",
                    fuenteNormal, XBrushes.Black, new XPoint(posX, posY));

                // Guardar PDF
                string rutaArchivo = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Factura_{factura.NumFactura}.pdf");
                documento.Save(rutaArchivo);
                MessageBox.Show($"PDF generado: {rutaArchivo}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir PDF
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