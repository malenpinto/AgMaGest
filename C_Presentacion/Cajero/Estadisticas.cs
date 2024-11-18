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
using System.Windows.Forms.DataVisualization.Charting;
using AgMaGest.C_Logica.Entidades;
using System.Globalization;

namespace AgMaGest.C_Presentacion.Cajero
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
            InicializarComboMesFiltro();
            CargarEstadisticasAnualesPedidos();
            CBMesFiltro.SelectedIndexChanged += CBMesFiltro_SelectedIndexChanged; // Asociar evento
        }

        private void InicializarComboMesFiltro()
        {
            CBMesFiltro.Items.Add("Todos los meses");
            for (int i = 1; i <= 12; i++)
            {
                string nombreMes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                    new DateTime(1, i, 1).ToString("MMMM").ToLower()
                );
                CBMesFiltro.Items.Add(nombreMes);
            }
            CBMesFiltro.SelectedIndex = 0; // Seleccionar "Todos los meses" por defecto
        }


        private void CargarEstadisticasAnualesPedidos()
        {
            PedidoDAL pedidoDAL = new PedidoDAL();

            // Obtener el mes seleccionado del ComboBox
            int? mesSeleccionado = CBMesFiltro.SelectedIndex == 0 ? (int?)null : CBMesFiltro.SelectedIndex;

            // Obtener estadísticas filtradas
            var estadisticasAnuales = pedidoDAL.ObtenerEstadisticasAnualesPedidos(mesSeleccionado);

            // Limpiar el Chart
            chartPedidosAnuales.Series.Clear();

            // Crear y llenar la serie con datos
            var serie = new Series("Pedidos Anuales")
            {
                ChartType = SeriesChartType.Bar
            };
            chartPedidosAnuales.Series.Add(serie);

            foreach (var estadistica in estadisticasAnuales)
            {
                string mesConFormato = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(estadistica.Key);
                serie.Points.AddXY(mesConFormato, estadistica.Value);
            }

            // Mostrar mensaje si no hay datos para el mes seleccionado
            if (serie.Points.Count == 0)
            {
                string mensaje = mesSeleccionado.HasValue
                    ? $"No hay datos para el mes seleccionado: {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(new DateTime(1, mesSeleccionado.Value, 1).ToString("MMMM"))}."
                    : "No hay datos para el año actual.";
                MessageBox.Show(mensaje, "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Configurar el gráfico
            chartPedidosAnuales.ChartAreas[0].AxisX.Interval = 1;
            chartPedidosAnuales.ChartAreas[0].AxisX.Title = "Meses";
            chartPedidosAnuales.ChartAreas[0].AxisY.Title = "Cantidad de Pedidos";
            chartPedidosAnuales.Titles.Clear();
            chartPedidosAnuales.Titles.Add("Estadísticas Anuales de Pedidos");
            chartPedidosAnuales.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        }

        private void CBMesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEstadisticasAnualesPedidos();
        }

    }
}
