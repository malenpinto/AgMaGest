using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class VisualizarInventario : Form
    {
        public VisualizarInventario()
        {
            InitializeComponent();
            CargarInventario();
            dataGridInventario.CellClick += DataGridInventario_CellClick;
            dataGridInventario.CellFormatting += DataGridVehiculos_CellFormatting;
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
                    dataGridInventario.Rows.Add(
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarDataGridView()
        {
            // Limpiar cualquier configuración previa
            dataGridInventario.Columns.Clear();

            // Columnas para Estado, Condición y Tipo
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "EstadoNombre", DataPropertyName = "EstadoNombre", HeaderText = "Estado" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "CondicionNombre", DataPropertyName = "CondicionNombre", HeaderText = "Condición" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "TipoNombre", DataPropertyName = "TipoNombre", HeaderText = "Tipo" });
            
            // Agregar columna de imagen
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom, // Ajusta la imagen al tamaño de la celda
                Width = 100
            };
            dataGridInventario.Columns.Add(imageColumn);

            // Configurar las columnas manualmente
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdVehiculo", DataPropertyName = "IdVehiculo", HeaderText = "ID" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "Marca", DataPropertyName = "Marca", HeaderText = "Marca" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "Modelo", DataPropertyName = "Modelo", HeaderText = "Modelo" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "Version", DataPropertyName = "Version", HeaderText = "Versión" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "Kilometraje", DataPropertyName = "Kilometraje", HeaderText = "Kilometraje" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "Anio", DataPropertyName = "Anio", HeaderText = "Año" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "Patente", DataPropertyName = "Patente", HeaderText = "Patente" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "CodigoOKM", DataPropertyName = "CodigoOKM", HeaderText = "CódigoOkm" });
            dataGridInventario.Columns.Add(new DataGridViewTextBoxColumn { Name = "Precio", DataPropertyName = "Precio", HeaderText = "Precio" });

            // Deshabilitar la fila adicional de entrada de datos
            dataGridInventario.AllowUserToAddRows = false;  // No permitir agregar filas vacías
        }

        private void BBuscarVehiculo_Click(object sender, EventArgs e)
        {
            string textoBusqueda = TBBuscarVehiculo.Text.Trim();
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

            dataGridInventario.Rows.Clear(); // Borra filas existentes

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
                    dataGridInventario.Rows.Add(
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

        private void BAgregarVehiculo_Click(object sender, EventArgs e)
        {
            IngresarVehiculo formVehiculo = new IngresarVehiculo();
            formVehiculo.ShowDialog();
        }

        private void BEditarVehiculo_Click(object sender, EventArgs e)
        {
            if (dataGridInventario.SelectedRows.Count > 0)
            {
                // Obtener el ID del vehículo seleccionado desde el DataGridView
                int idVehiculo = Convert.ToInt32(dataGridInventario.SelectedRows[0].Cells["IdVehiculo"].Value);

                // Cargar el vehículo desde la base de datos usando el ID
                VehiculoDAL vehiculoDAL = new VehiculoDAL();
                Vehiculos vehiculo = vehiculoDAL.ObtenerVehiculoPorId(idVehiculo);

                if (vehiculo != null)
                {
                    // Pasar el objeto vehiculo al formulario EditarVehiculo
                    EditarVehiculo editarForm = new EditarVehiculo(vehiculo);
                    if (editarForm.ShowDialog() == DialogResult.OK)
                    {
                        CargarInventario(); // Recargar datos actualizados
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo encontrar el vehículo seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehículo para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BEliminarVehiculo_Click(object sender, EventArgs e)
        {
            if (dataGridInventario.SelectedRows.Count > 0)
            {
                // Confirmar la eliminación
                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este vehículo?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Obtener el ID del vehículo seleccionado desde el DataGridView
                    int idVehiculo = Convert.ToInt32(dataGridInventario.SelectedRows[0].Cells["IdVehiculo"].Value);

                    // Llamar al método para eliminar el vehículo en VehiculoDAL
                    VehiculoDAL vehiculoDAL = new VehiculoDAL();
                    bool eliminado = vehiculoDAL.EliminarVehiculo(idVehiculo);

                    if (eliminado)
                    {
                        MessageBox.Show("Vehículo eliminado exitosamente.", "Eliminación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Recargar el inventario para reflejar la eliminación
                        CargarInventario();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehículo para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void DataGridInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que el clic sea en la columna de la imagen
            if (e.ColumnIndex == dataGridInventario.Columns["Imagen"].Index && e.RowIndex >= 0)
            {
                // Obtener la imagen de la celda seleccionada
                var imagen = dataGridInventario.Rows[e.RowIndex].Cells["Imagen"].Value as Image;

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

        private void DataGridInventario_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridInventario.SelectedRows.Count > 0)
            {
                BEditarVehiculo.Visible = true;
                BEliminarVehiculo.Visible = true;
            }
            else
            {
                // Opcionalmente, ocultar los botones si no hay selección
                BEditarVehiculo.Visible = false;
                BEliminarVehiculo.Visible = false;
            }
        }

        private void DataGridVehiculos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si estamos en la columna "EstadoNombre" 
            if (dataGridInventario.Columns[e.ColumnIndex].Name == "EstadoNombre")
            {
                // Obtener el valor de la celda de estado
                string estadoVehiculo = e.Value as string;

                if (estadoVehiculo == "Activo")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (estadoVehiculo == "Inactivo")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }
    }
}
