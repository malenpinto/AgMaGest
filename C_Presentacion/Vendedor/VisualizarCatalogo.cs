using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using AgMaGest.C_Presentacion.Administrador;
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class VisualizarCatalogo : Form
    {
        public VisualizarCatalogo()
        {
            InitializeComponent();
            CargarInventario();
            dataGridCatalogo.CellClick += DataGridCatalogo_CellClick;
        }

        private void CargarInventario()
        {
            try
            {
                // Obtener la lista de vehículos desde la base de datos
                VehiculoDAL vehiculoDAL = new VehiculoDAL();
                List<Vehiculos> inventario = vehiculoDAL.ObtenerTodosLosVehiculos(); // Método que obtiene los vehículos

                // Configurar el DataGridView
                ConfigurarDataGridView();

                // Llenar el DataGridView con los datos obtenidos
                foreach (var vehiculo in inventario)
                {
                    // Cargar la imagen del vehículo
                    Image imagen = null;
                    if (!string.IsNullOrEmpty(vehiculo.RutaImagen) && File.Exists(vehiculo.RutaImagen))
                    {
                        imagen = Image.FromFile(vehiculo.RutaImagen);
                    }

                    // Agregar la fila al DataGridView con las nuevas columnas Estado, Condición y Tipo
                    dataGridCatalogo.Rows.Add(
                        vehiculo.CondicionNombre,    // Nueva columna Condición
                        vehiculo.TipoNombre,         // Nueva columna Tipo
                        imagen,
                        vehiculo.IdVehiculo,
                        vehiculo.Marca,
                        vehiculo.Modelo,
                        vehiculo.Version,
                        vehiculo.Kilometraje,
                        vehiculo.Anio.Year,
                        vehiculo.Patente,
                        vehiculo.CodigoOKM,
                        vehiculo.Precio

                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarDataGridView()
        {
            // Limpiar cualquier configuración previa
            dataGridCatalogo.Columns.Clear();

            // Columnas para Estado, Condición y Tipo
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "CondicionNombre", DataPropertyName = "CondicionNombre", HeaderText = "Condición" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipoNombre", DataPropertyName = "TipoNombre", HeaderText = "Tipo" });

            // Agregar columna de imagen
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom, // Ajusta la imagen al tamaño de la celda
                Width = 100
            };
            dataGridCatalogo.Columns.Add(imageColumn);

            // Configurar las columnas manualmente
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdVehiculo", DataPropertyName = "IdVehiculo", HeaderText = "ID" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Marca", DataPropertyName = "Marca", HeaderText = "Marca" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Modelo", DataPropertyName = "Modelo", HeaderText = "Modelo" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Version", DataPropertyName = "Version", HeaderText = "Versión" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Kilometraje", DataPropertyName = "Kilometraje", HeaderText = "Kilometraje" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Anio", DataPropertyName = "Anio", HeaderText = "Año" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Patente", DataPropertyName = "Patente", HeaderText = "Patente" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "CodigoOKM", DataPropertyName = "CodigoOKM", HeaderText = "CódigoOkm" });
            dataGridCatalogo.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", DataPropertyName = "Precio", HeaderText = "Precio" });

            // Deshabilitar la fila adicional de entrada de datos
            dataGridCatalogo.AllowUserToAddRows = false;  // No permitir agregar filas vacías
        }

        private void BBuscarVehiculo_Click(object sender, EventArgs e)
        {
            string textoBusqueda = TBBuscarVehiculoCatalogo.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                FiltrarVehiculos(textoBusqueda);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un texto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FiltrarVehiculos(string texto)
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            List<Vehiculos> vehiculosFiltrados = vehiculoDAL.FiltrarVehiculos(texto);

            dataGridCatalogo.Rows.Clear(); // Borra filas existentes

            if (vehiculosFiltrados != null && vehiculosFiltrados.Count > 0)
            {
                foreach (var vehiculo in vehiculosFiltrados)
                {
                    // Agrega la fila como en CargarInventario()
                    Image imagen = null;
                    if (!string.IsNullOrEmpty(vehiculo.RutaImagen) && File.Exists(vehiculo.RutaImagen))
                    {
                        imagen = Image.FromFile(vehiculo.RutaImagen);
                    }
                    dataGridCatalogo.Rows.Add(
                        vehiculo.EstadoNombre,       // Nueva columna Estado
                        vehiculo.CondicionNombre,    // Nueva columna Condición
                        vehiculo.TipoNombre,         // Nueva columna Tipo
                        imagen,
                        vehiculo.IdVehiculo,
                        vehiculo.Marca,
                        vehiculo.Modelo,
                        vehiculo.Version,
                        vehiculo.Kilometraje,
                        vehiculo.Anio.Year,
                        vehiculo.Patente,
                        vehiculo.CodigoOKM,
                        vehiculo.Precio

                    );
                }
            }
            else
            {
                MessageBox.Show("No se encontraron vehículos con el criterio de búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarInventario();
            }
        }

        private void DataGridCatalogo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que el clic sea en la columna de la imagen
            if (e.ColumnIndex == dataGridCatalogo.Columns["Imagen"].Index && e.RowIndex >= 0)
            {
                // Obtener la imagen de la celda seleccionada
                var imagen = dataGridCatalogo.Rows[e.RowIndex].Cells["Imagen"].Value as Image;

                if (imagen != null)
                {
                    // Mostrar el formulario con la imagen ampliada
                    VisualizarImagen formImagen = new VisualizarImagen(imagen);
                    formImagen.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay imagen disponible para este vehículo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DataGridCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridCatalogo.SelectedRows.Count > 0)
            {
                BGenerarPedido.Visible = true;
            }
            else
            {
                // Opcionalmente, ocultar los botones si no hay selección
                BGenerarPedido.Visible = false;
            }
        }

        private void BGenerarPedido_Click(object sender, EventArgs e)
        {
            IngresarPedido formPedido = new IngresarPedido();
            formPedido.ShowDialog();
        }
    }
}
