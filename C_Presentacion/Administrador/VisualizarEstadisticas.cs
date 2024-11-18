using AgMaGest.C_Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgMaGest.C_Logica.Entidades;
using System.Windows.Forms.DataVisualization.Charting;
using System.Globalization;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class VisualizarEstadisticas : Form
    {
        public VisualizarEstadisticas()
        {
            InitializeComponent();
            CargarEstadisticasVendedorDelMes();
            InicializarComboMesFiltro(); // Inicializar el ComboBox de meses
            CBFiltroVendedor.SelectedIndexChanged += CBFiltroVendedor_SelectedIndexChanged;
        }

        private void CargarEstadisticasVendedorDelMes()
        {
            PedidoDAL pedidoDAL = new PedidoDAL();

            // Obtener el mes seleccionado del ComboBox
            int? mesSeleccionado = CBFiltroVendedor.SelectedIndex == 0 ? (int?)null : CBFiltroVendedor.SelectedIndex;

            // Verificar si se seleccionó "Todos los meses" y mostrar el mensaje correspondiente
            if (mesSeleccionado == null)
            {
                MessageBox.Show("No se encontraron datos de ventas para el año actual.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Salir antes de hacer la carga de estadísticas si es "Todos los meses"
            }

            // Obtener estadísticas filtradas por mes
            var estadisticas = pedidoDAL.ObtenerVendedorDelMes(mesSeleccionado);

            // Limpiar el Chart antes de agregar datos
            chartVendedor.Series.Clear();

            // Crear y llenar la serie con datos
            var serie = new Series("Vendedor del Mes")
            {
                ChartType = SeriesChartType.Column // Tipo de gráfico: Barra
            };
            chartVendedor.Series.Add(serie);

            foreach (var estadistica in estadisticas)
            {
                string nombreCompleto = $"{estadistica.NombreEmpleado} {estadistica.ApellidoEmpleado}";
                serie.Points.AddXY(nombreCompleto, estadistica.CantidadPedidos);
            }

            // Mostrar mensaje si no hay datos para el mes seleccionado
            if (serie.Points.Count == 0)
            {
                if (mesSeleccionado.HasValue && mesSeleccionado.Value >= 1 && mesSeleccionado.Value <= 12)
                {
                    string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesSeleccionado.Value);
                    string mensaje = $"No se encontraron datos de ventas para el mes seleccionado: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMes)}.";
                    MessageBox.Show(mensaje, "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            // Configuración del gráfico
            chartVendedor.ChartAreas[0].AxisX.Interval = 1;
            chartVendedor.ChartAreas[0].AxisX.Title = "Vendedores";
            chartVendedor.ChartAreas[0].AxisY.Title = "Cantidad de Pedidos";
            chartVendedor.Titles.Clear();
            chartVendedor.Titles.Add("Estadísticas del Vendedor del Mes");
            chartVendedor.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }


        // Método para inicializar el ComboBox con los nombres de los meses
        private void InicializarComboMesFiltro()
        {
            CBFiltroVendedor.Items.Add("Todos los meses");
            for (int i = 1; i <= 12; i++)
            {
                string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                CBFiltroVendedor.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMes));
            }
            CBFiltroVendedor.SelectedIndex = 0; // Seleccionar "Todos los meses" por defecto
        }

        private void CBFiltroVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Mostrar las estadísticas en el gráfico
            CargarEstadisticasVendedorDelMes();
        }


    }

}
