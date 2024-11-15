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
using AgMaGest.C_Datos;
using System.Windows.Forms.DataVisualization.Charting;

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class VisualizarEstadisticas : Form
    {
        public VisualizarEstadisticas()
        {
            InitializeComponent();
            CargarEstadisticasPedidos();
        }

        public void CargarEstadisticasPedidos()
        {
            // Crear una instancia de PedidoDAL
            PedidoDAL pedidoDAL = new PedidoDAL();

            // Obtener los estados de los pedidos desde la base de datos
            var estadosPedidos = pedidoDAL.ObtenerEstadosPedidos();

            // Limpiar el Chart antes de agregar datos
            chartPedidos.Series.Clear();

            // Crear una nueva serie para los estados
            var serie = new System.Windows.Forms.DataVisualization.Charting.Series("Pedidos por Estado");

            // Configuración de la serie (puedes personalizar el tipo de gráfico)
            serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;  // Tipo de gráfico: torta (pie)
            chartPedidos.Series.Add(serie);

            // Recorrer los estados y agregar los valores al gráfico
            foreach (var estado in estadosPedidos)
            {
                int idEstado = estado.Key;
                string nombreEstado = estado.Value;

                // Obtener la cantidad de pedidos para este estado
                int cantidadPedidos = pedidoDAL.ContarPedidosPorEstado(idEstado);

                // Asegúrate de que hay pedidos para ese estado
                if (cantidadPedidos > 0)
                {
                    // Agregar el nombre del estado y la cantidad al gráfico
                    chartPedidos.Series["Pedidos por Estado"].Points.AddXY(nombreEstado, cantidadPedidos);
                }
            }

            // Validación adicional para asegurarse de que se agregaron puntos
            if (chartPedidos.Series["Pedidos por Estado"].Points.Count == 0)
            {
                MessageBox.Show("No se encontraron pedidos para mostrar en el gráfico.");
            }
            chartPedidos.Titles.Add("Estadísticas de los estados de los pedidos");
        }
    }
}
