using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using AgMaGest.C_Presentacion.Administrador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Cajero
{
    public partial class RegistrarPago : Form
    {
        public RegistrarPago()
        {
            InitializeComponent();
            this.Load += new EventHandler(VisualizarVentas_Load);
            dataGridPedidos.CellClick += DataGridPagos_CellClick;
            dataGridPedidos.CellFormatting += DataGridPagos_CellFormatting;
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

        private void BBuscarPedido_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = TBBuscarPedido.Text.Trim();

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

        private void BRefrescarPedido_Click(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void BGenerarPago_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un pedido para generar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRow = dataGridPedidos.SelectedRows[0];
            string cuilCuit = selectedRow.Cells["CUIL_Cliente"].Value?.ToString();

            if (string.IsNullOrEmpty(cuilCuit))
            {
                MessageBox.Show("No se encontró el CUIL/CUIT del cliente para el pedido seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el pedido seleccionado
            Pedido pedido = selectedRow.DataBoundItem as Pedido;

            // Verificar el estado del pago
            PedidoDAL pedidoDAL = new PedidoDAL();
            int estadoActualPago = pedidoDAL.ObtenerEstadoPagoPorPedido(pedido.IdPedido);

            if (estadoActualPago == 1)
            {
                MessageBox.Show("El pedido seleccionado ya tiene un pago confirmado. No se puede generar un nuevo pago.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (EsCuit(cuilCuit))
            {
                // Abre el formulario para cliente empresa con datos del pedido
                GenerarPagoCEmpresa formEmpresa = new GenerarPagoCEmpresa(cuilCuit, pedido);
                formEmpresa.ShowDialog();
            }
            else
            {
                // Abre el formulario para cliente final con datos del pedido
                GenerarPagoCFinal formFinal = new GenerarPagoCFinal(cuilCuit, pedido);
                formFinal.ShowDialog();
            }
        }

        private bool EsCuit(string cuilCuit)
        {
            // En Argentina, el CUIT tiene prefijos de 30, o 33 (por ejemplo, para personas jurídicas)
            // Mientras que el CUIL tiene prefijos típicos de 20, 27, 23 para personas físicas.
            // Ajustar la lógica según el criterio para diferenciar CUIT y CUIL
            // Un CUIT de empresa suele empezar con 30 o 33 y tiene longitud de 11 caracteres

            return cuilCuit.Length == 11 && (cuilCuit.StartsWith("30") || cuilCuit.StartsWith("33"));
        }

        private void DataGridPagos_CellClick(object sender, DataGridViewCellEventArgs e)
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
       
        private void DataGridPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void DataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPedidos.SelectedRows.Count > 0)
            {
                BGenerarPago.Visible = true;
            }
            else
            {
                BGenerarPago.Visible = false;
            }
        }
    }
}
