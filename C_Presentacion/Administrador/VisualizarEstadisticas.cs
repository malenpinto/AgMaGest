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

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class VisualizarEstadisticas : Form
    {
        public VisualizarEstadisticas()
        {
            InitializeComponent();
            CargarEstadisticasVendedorDelMes();
        }

        private void CargarEstadisticasVendedorDelMes()
        {
            PedidoDAL pedidoDAL = new PedidoDAL();
            var estadisticas = pedidoDAL.ObtenerVendedorDelMes();

            // Limpiar el Chart antes de agregar datos
            chartVendedor.Series.Clear();

            // Crear una nueva serie para las estadísticas del vendedor del mes
            var serie = new Series("Vendedor del Mes");

            // Configuración de la serie
            serie.ChartType = SeriesChartType.Bar;  // Tipo de gráfico: barra
            chartVendedor.Series.Add(serie);

            // Recorrer las estadísticas y agregar los valores al gráfico
            foreach (var estadistica in estadisticas)
            {
                // Agregar el nombre del vendedor y la cantidad de pedidos al gráfico
                serie.Points.AddXY($"{estadistica.NombreEmpleado} {estadistica.ApellidoEmpleado}", estadistica.CantidadPedidos);
            }

            // Validación adicional para asegurarse de que se agregaron puntos
            if (serie.Points.Count == 0)
            {
                MessageBox.Show("No se encontraron datos de ventas para el mes actual.");
            }

            // Opcional: personalización adicional del gráfico
            chartVendedor.ChartAreas[0].AxisX.Title = "Vendedores";
            chartVendedor.ChartAreas[0].AxisY.Title = "Cantidad de Pedidos";
            chartVendedor.Titles.Clear();
            chartVendedor.Titles.Add("Estadísticas del Vendedor del Mes");
        }
    }

}
