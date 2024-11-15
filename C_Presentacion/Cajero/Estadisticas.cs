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

namespace AgMaGest.C_Presentacion.Cajero
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
            CargarEstadisticasAnualesPedidos();
        }

        private void CargarEstadisticasAnualesPedidos()
        {
            PedidoDAL pedidoDAL = new PedidoDAL();
            var estadisticasAnuales = pedidoDAL.ObtenerEstadisticasAnualesPedidos();

            // Limpiar el Chart antes de agregar datos
            chartPedidosAnuales.Series.Clear();

            // Crear una nueva serie para las estadísticas anuales de los pedidos
            var serie = new Series("Pedidos Anuales")
            {
                ChartType = SeriesChartType.Bar // Tipo de gráfico: Barra
            };
            chartPedidosAnuales.Series.Add(serie);

            // Recorrer las estadísticas y agregar los valores al gráfico
            foreach (var estadistica in estadisticasAnuales)
            {
                // Agregar el mes y la cantidad de pedidos al gráfico
                serie.Points.AddXY(estadistica.Key, estadistica.Value);
            }

            // Validación adicional para asegurarse de que se agregaron puntos
            if (serie.Points.Count == 0)
            {
                MessageBox.Show("No se encontraron pedidos para el año actual.");
            }

            // Configurar etiquetas del eje X para mostrar los meses
            chartPedidosAnuales.ChartAreas[0].AxisX.Interval = 1;
            chartPedidosAnuales.ChartAreas[0].AxisX.Title = "Meses";
            chartPedidosAnuales.ChartAreas[0].AxisY.Title = "Cantidad de Pedidos";

            // Configurar título del gráfico
            chartPedidosAnuales.Titles.Clear();
            chartPedidosAnuales.Titles.Add("Estadísticas Anuales de Pedidos");

            // Opcional: Personalizar las etiquetas del eje X si no se muestran correctamente
            chartPedidosAnuales.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartPedidosAnuales.ChartAreas[0].AxisX.LabelStyle.Format = "MMMM";
            chartPedidosAnuales.ChartAreas[0].AxisX.LabelStyle.IsEndLabelVisible = true;
        }
    }
}
