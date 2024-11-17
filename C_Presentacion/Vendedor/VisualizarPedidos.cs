using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgMaGest.C_Presentacion.Administrador;

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class VisualizarPedidos : Form
    {
        public VisualizarPedidos()
        {
            InitializeComponent();
            this.Load += new EventHandler(VisualizarPedidos_Load);
            dataGridPedidos.CellClick += DataGridPedidos_CellClick;
            dataGridPedidos.CellFormatting += DataGridPedidos_CellFormatting;
        }

        private void VisualizarPedidos_Load(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void CargarPedidos()
        {
            try
            {
                ConfigurarDataGridView();
                dataGridPedidos.AutoGenerateColumns = false;

                PedidoDAL pedidoDAL = new PedidoDAL();
                List<Pedido> listaPedidos = pedidoDAL.ObtenerPedidos();

                foreach (var pedido in listaPedidos)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(pedido.Vehiculo?.RutaImagen) && File.Exists(pedido.Vehiculo.RutaImagen))
                        {
                            // Carga la imagen desde la ruta especificada
                            pedido.Imagen = Image.FromFile(pedido.Vehiculo.RutaImagen);
                        }
                        else
                        {
                            // Asigna la imagen por defecto si la ruta no es válida o no existe
                            pedido.Imagen = Properties.Resources.VhiculoPorDefecto;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al cargar la imagen para el pedido con ID: " + pedido.IdPedido + " - " + ex.Message);
                        // Asigna la imagen por defecto en caso de error
                        pedido.Imagen = Properties.Resources.VhiculoPorDefecto;
                    }

                    // Carga el campo "DetallesVehiculo"
                    pedido.DetallesVehiculo = $"{pedido.Vehiculo.CondicionNombre} - {pedido.Vehiculo.Marca} - {pedido.Vehiculo.TipoNombre} - {pedido.Vehiculo.Modelo} - {pedido.Vehiculo.Anio.Year}";
                }

                if (listaPedidos != null && listaPedidos.Count > 0)
                {
                    dataGridPedidos.DataSource = new BindingList<Pedido>(listaPedidos);
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos en la base de datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar cualquier configuración previa
            dataGridPedidos.Columns.Clear();

            // Configurar las columnas estándar
            dataGridPedidos.Columns.Add("IdPedido", "ID Pedido");
            dataGridPedidos.Columns["IdPedido"].DataPropertyName = "IdPedido";

            dataGridPedidos.Columns.Add("NombreEstadoPedido", "Estado del Pedido");
            dataGridPedidos.Columns["NombreEstadoPedido"].DataPropertyName = "NombreEstadoPedido";

            dataGridPedidos.Columns.Add("CUIL", "CUIL Empleado");
            dataGridPedidos.Columns["CUIL"].DataPropertyName = "CUIL";

            dataGridPedidos.Columns.Add("ApellidoEmpleado", "Apellido ");
            dataGridPedidos.Columns["ApellidoEmpleado"].DataPropertyName = "ApellidoEmpleado";

            dataGridPedidos.Columns.Add("NombreEmpleado", "Nombre ");
            dataGridPedidos.Columns["NombreEmpleado"].DataPropertyName = "NombreEmpleado";

            dataGridPedidos.Columns.Add("CUIL_Cliente", "CUIL del Cliente");
            dataGridPedidos.Columns["CUIL_Cliente"].DataPropertyName = "CUIL_Cliente";

            dataGridPedidos.Columns.Add("NombreCliente", "Nombre del Cliente");
            dataGridPedidos.Columns["NombreCliente"].DataPropertyName = "NombreCliente";

            // Columna para los detalles del vehículo
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom, // Ajusta la imagen al tamaño de la celda
                Width = 100,
                DataPropertyName = "Imagen" // Importante: esta propiedad debe estar configurada
            };
            dataGridPedidos.Columns.Add(imageColumn);

            dataGridPedidos.Columns.Add("DetallesVehiculo", "Detalles Vehiculo");
            dataGridPedidos.Columns["DetallesVehiculo"].DataPropertyName = "DetallesVehiculo";

            // Configurar las columnas para fecha y monto
            dataGridPedidos.Columns.Add("FechaPedido", "Fecha del Pedido");
            dataGridPedidos.Columns["FechaPedido"].DataPropertyName = "FechaPedido";
            dataGridPedidos.Columns["FechaPedido"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridPedidos.Columns.Add("MontoPedido", "Monto Pedido");
            dataGridPedidos.Columns["MontoPedido"].DataPropertyName = "MontoPedido";

            dataGridPedidos.AllowUserToAddRows = false;
        }

        private void BBuscarCliente_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = TBBuscarPedido.Text.Trim();

            if (string.IsNullOrWhiteSpace(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Buscar los pedidos
                PedidoDAL pedidoDAL = new PedidoDAL();
                List<Pedido> pedidosFiltrados = pedidoDAL.BuscarPedidos(criterioBusqueda);

                if (pedidosFiltrados != null && pedidosFiltrados.Count > 0)
                {
                    // Cargar solo los pedidos filtrados
                    dataGridPedidos.DataSource = new BindingList<Pedido>(pedidosFiltrados);
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos con el criterio ingresado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Recargar todos los pedidos solo si el DataGridView está vacío o no tiene datos relevantes
                    if (dataGridPedidos.Rows.Count == 0 || dataGridPedidos.DataSource == null)
                    {
                        CargarPedidos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BRefrescarPedidos_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void DataGridPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridPedidos.Columns["Imagen"].Index && e.RowIndex >= 0)
            {
                var imagen = dataGridPedidos.Rows[e.RowIndex].Cells["Imagen"].Value as Image;
                if (imagen != null)
                {
                    VisualizarImagen formImagen = new VisualizarImagen(imagen);
                    formImagen.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No hay imagen disponible para este pedido.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void DataGridPedidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridPedidos.Columns[e.ColumnIndex].Name == "NombreEstadoPedido")
            {
                string estadoPedido = e.Value?.ToString();

                if (!string.IsNullOrEmpty(estadoPedido))
                {
                    switch (estadoPedido.ToLower())
                    {
                        case "confirmado":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.Black;
                            break;

                        case "pendiente":
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.Black;
                            break;

                        default:
                            e.CellStyle.BackColor = Color.White;
                            e.CellStyle.ForeColor = Color.Black;
                            break;
                    }
                }
            }
        }
    }
}
