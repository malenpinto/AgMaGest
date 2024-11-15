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
            this.Load += new EventHandler(VisualizarVentas_Load);
            dataGridPedidos.CellClick += DataGridPedidos_CellClick;
            dataGridPedidos.CellFormatting += DataGridPedidos_CellFormatting;
        }

        private void VisualizarVentas_Load(object sender, EventArgs e)
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

                if (listaPedidos != null && listaPedidos.Count > 0)
                {
                    foreach (var pedido in listaPedidos)
                    {
                        pedido.DetallesVehiculo = $"{pedido.Vehiculo.CondicionNombre} - {pedido.Vehiculo.Marca} - {pedido.Vehiculo.TipoNombre} - {pedido.Vehiculo.Modelo} - {pedido.Vehiculo.Anio.Year}";

                        // Cargar la imagen del vehículo
                        pedido.Imagen = null;
                        if (!string.IsNullOrEmpty(pedido.Vehiculo.RutaImagen) && File.Exists(pedido.Vehiculo.RutaImagen))
                        {
                            pedido.Imagen = Image.FromFile(pedido.Vehiculo.RutaImagen);
                        }
                        else
                        {
                            pedido.Imagen = Properties.Resources.VhiculoPorDefecto; // Imagen predeterminada
                        }
                    }

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
            dataGridPedidos.Columns.Add("NombreEstadoPedido", "Estado Pedido");
            dataGridPedidos.Columns["NombreEstadoPedido"].DataPropertyName = "NombreEstadoPedido";

            dataGridPedidos.Columns.Add("IdPedido", "ID Pedido");
            dataGridPedidos.Columns["IdPedido"].DataPropertyName = "IdPedido";

            dataGridPedidos.Columns.Add("CUIL", "CUIL Empleado");
            dataGridPedidos.Columns["CUIL"].DataPropertyName = "CUIL";

            dataGridPedidos.Columns.Add("NombreEmpleado", "Nombre ");
            dataGridPedidos.Columns["NombreEmpleado"].DataPropertyName = "NombreEmpleado";

            dataGridPedidos.Columns.Add("ApellidoEmpleado", "Apellido ");
            dataGridPedidos.Columns["ApellidoEmpleado"].DataPropertyName = "ApellidoEmpleado";

            dataGridPedidos.Columns.Add("IdCliente", "ID Cliente");
            dataGridPedidos.Columns["IdCliente"].DataPropertyName = "IdCliente";

            // Columna para los detalles del vehículo
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom, // Ajusta la imagen al tamaño de la celda
                Width = 100
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
            dataGridPedidos.Columns["MontoPedido"].DefaultCellStyle.Format = "C2";


            dataGridPedidos.AllowUserToAddRows = false;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener números.");
            }
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
                PedidoDAL pedidoDAL = new PedidoDAL();
                List<Pedido> pedidosFiltrados = pedidoDAL.BuscarPedidos(criterioBusqueda);

                if (pedidosFiltrados.Count > 0)
                {
                    dataGridPedidos.DataSource = new BindingList<Pedido>(pedidosFiltrados);
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos con el criterio ingresado.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar los pedidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /*private void DataGridPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
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
        }*/

        private void DataGridPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la columna sea la de la imagen y que la fila sea válida
            if (e.ColumnIndex == dataGridPedidos.Columns["Imagen"].Index && e.RowIndex >= 0)
            {
                // Obtiene el objeto Pedido vinculado a la fila seleccionada
                Pedido pedido = (Pedido)dataGridPedidos.Rows[e.RowIndex].DataBoundItem;

                if (pedido?.Vehiculo?.Imagen != null)
                {
                    // Muestra la imagen en un formulario de visualización
                    VisualizarImagen formImagen = new VisualizarImagen(pedido.Vehiculo.Imagen);
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
                        case "completado":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.ForeColor = Color.Black;
                            break;

                        case "pendiente":
                            e.CellStyle.BackColor = Color.LightYellow;
                            e.CellStyle.ForeColor = Color.Black;
                            break;

                        case "cancelado":
                            e.CellStyle.BackColor = Color.LightCoral;
                            e.CellStyle.ForeColor = Color.White;
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
