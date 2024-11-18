﻿using System;
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
using System.Globalization;

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class VisualizarEstadisticas : Form
    {
        public VisualizarEstadisticas()
        {
            InitializeComponent();
            CargarEstadisticasPedidos();
            InicializarComboMesFiltro(); // Inicializar el ComboBox para el mes
        }

        public void CargarEstadisticasPedidos()
        {
            // Crear una instancia de PedidoDAL
            PedidoDAL pedidoDAL = new PedidoDAL();

            // Obtener los estados de los pedidos desde la base de datos
            var estadosPedidos = pedidoDAL.ObtenerEstadosPedidos();

            // Obtener el mes seleccionado
            int? mesSeleccionado = CBFiltroEstado.SelectedIndex == 0 ? (int?)null : CBFiltroEstado.SelectedIndex;

            // Limpiar el Chart antes de agregar datos
            chartPedidos.Series.Clear();

            // Crear una nueva serie para los estados
            var serie = new System.Windows.Forms.DataVisualization.Charting.Series("Pedidos por Estado");

            // Configuración de la serie (puedes personalizar el tipo de gráfico)
            serie.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;  // Tipo de gráfico: torta (pie)
            chartPedidos.Series.Add(serie);

            // Variable para saber si se agregaron puntos
            bool hayDatos = false;

            // Recorrer los estados y agregar los valores al gráfico
            foreach (var estado in estadosPedidos)
            {
                int idEstado = estado.Key;
                string nombreEstado = estado.Value;

                // Obtener la cantidad de pedidos para este estado y el mes seleccionado
                int cantidadPedidos = mesSeleccionado.HasValue
                    ? pedidoDAL.ContarPedidosPorEstadoYMes(idEstado, mesSeleccionado.Value)
                    : pedidoDAL.ContarPedidosPorEstado(idEstado); // Si no se seleccionó mes, se cuentan todos los pedidos

                // Asegúrate de que hay pedidos para ese estado
                if (cantidadPedidos > 0)
                {
                    // Agregar el nombre del estado y la cantidad al gráfico
                    chartPedidos.Series["Pedidos por Estado"].Points.AddXY(nombreEstado, cantidadPedidos);
                    hayDatos = true; // Si se agregan datos, marcamos que hay datos
                }
            }

            // Si no se encontraron datos para mostrar
            if (!hayDatos)
            {
                string mensaje = "No se encontraron pedidos para mostrar en el gráfico.";

                // Verificar si se seleccionó un mes específico (no "Todos los meses")
                if (mesSeleccionado.HasValue && mesSeleccionado.Value != 0)
                {
                    try
                    {
                        // Crear el objeto DateTime solo si el mes es válido (1-12)
                        string nombreMes = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(new DateTime(2024, mesSeleccionado.Value, 1).ToString("MMMM"));
                        mensaje = $"No se encontraron pedidos para el mes seleccionado: {nombreMes}.";
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        // Si ocurre un error, capturarlo y mostrar un mensaje adecuado
                        MessageBox.Show("El mes seleccionado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Salir del método
                    }
                }

                // Mostrar el mensaje
                MessageBox.Show(mensaje, "Sin Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                // Si hay datos, agregar título al gráfico
                chartPedidos.Titles.Clear();
                chartPedidos.Titles.Add("Estadísticas de los estados de los pedidos");
            }
        }

        private void InicializarComboMesFiltro()
        {
            CBFiltroEstado.Items.Add("Todos los meses");
            for (int i = 1; i <= 12; i++)
            {
                string nombreMes = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);
                CBFiltroEstado.Items.Add(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMes));
            }
            CBFiltroEstado.SelectedIndex = 0; // Seleccionar "Todos los meses" por defecto
            CBFiltroEstado.SelectedIndexChanged += CBMesFiltro_SelectedIndexChanged; // Evento de cambio de selección
        }

        // Evento que se ejecuta cuando se cambia la selección del ComboBox de meses
        private void CBMesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEstadisticasPedidos(); // Recargar las estadísticas con el filtro aplicado
        }

    }
}
