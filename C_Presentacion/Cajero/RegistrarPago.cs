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
            dataGridPagos.CellClick += DataGridPagos_CellClick;
            dataGridPagos.CellFormatting += DataGridPagos_CellFormatting;
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
                dataGridPagos.AutoGenerateColumns = false;

                PedidoDAL pedidoDAL = new PedidoDAL();
                List<Pedido> listaPedidos = pedidoDAL.ObtenerPedidos();

                // Validar las imágenes antes de asignar al DataGridView
                foreach (var pedido in listaPedidos)
                {
                    // Verificar si la imagen del vehículo está asignada
                    if (pedido.Imagen == null)
                    {
                        Console.WriteLine("Imagen no asignada para el pedido con ID: " + pedido.IdPedido);
                    }

                    // Validación de que la ruta de la imagen sea válida
                    if (!string.IsNullOrEmpty(pedido.Vehiculo.RutaImagen) && File.Exists(pedido.Vehiculo.RutaImagen))
                    {
                        // Verifica si la ruta existe y es válida
                        pedido.Imagen = Image.FromFile(pedido.Vehiculo.RutaImagen);
                    }
                    else
                    {
                        // Asigna la imagen por defecto si la ruta no es válida o no existe
                        pedido.Imagen = Properties.Resources.VhiculoPorDefecto;
                    }

                    // Asegúrate de que el campo "DetallesVehiculo" se cargue
                    pedido.DetallesVehiculo = $"{pedido.Vehiculo.CondicionNombre} - {pedido.Vehiculo.Marca} - {pedido.Vehiculo.TipoNombre} - {pedido.Vehiculo.Modelo} - {pedido.Vehiculo.Anio.Year}";
                }

                // Asignar la lista de pedidos al DataGridView
                if (listaPedidos != null && listaPedidos.Count > 0)
                {
                    dataGridPagos.DataSource = new BindingList<Pedido>(listaPedidos);
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
            dataGridPagos.Columns.Clear();

            // Configurar las columnas estándar
            dataGridPagos.Columns.Add("NombreEstadoPedido", "Estado Pedido");
            dataGridPagos.Columns["NombreEstadoPedido"].DataPropertyName = "NombreEstadoPedido";

            dataGridPagos.Columns.Add("IdPedido", "ID Pedido");
            dataGridPagos.Columns["IdPedido"].DataPropertyName = "IdPedido";

            dataGridPagos.Columns.Add("CUIL", "CUIL Empleado");
            dataGridPagos.Columns["CUIL"].DataPropertyName = "CUIL";

            dataGridPagos.Columns.Add("NombreEmpleado", "Nombre ");
            dataGridPagos.Columns["NombreEmpleado"].DataPropertyName = "NombreEmpleado";

            dataGridPagos.Columns.Add("ApellidoEmpleado", "Apellido ");
            dataGridPagos.Columns["ApellidoEmpleado"].DataPropertyName = "ApellidoEmpleado";

            dataGridPagos.Columns.Add("IdCliente", "ID Cliente");
            dataGridPagos.Columns["IdCliente"].DataPropertyName = "IdCliente";

            // Columna para los detalles del vehículo
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn
            {
                Name = "Imagen",
                HeaderText = "Imagen",
                ImageLayout = DataGridViewImageCellLayout.Zoom, // Ajusta la imagen al tamaño de la celda
                Width = 100
            };
            dataGridPagos.Columns.Add(imageColumn);

            dataGridPagos.Columns.Add("DetallesVehiculo", "Detalles Vehiculo");
            dataGridPagos.Columns["DetallesVehiculo"].DataPropertyName = "DetallesVehiculo";

            // Configurar las columnas para fecha y monto
            dataGridPagos.Columns.Add("FechaPedido", "Fecha del Pedido");
            dataGridPagos.Columns["FechaPedido"].DataPropertyName = "FechaPedido";
            dataGridPagos.Columns["FechaPedido"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dataGridPagos.Columns.Add("MontoPedido", "Monto Pedido");
            dataGridPagos.Columns["MontoPedido"].DataPropertyName = "MontoPedido";
            dataGridPagos.Columns["MontoPedido"].DefaultCellStyle.Format = "C2";


            dataGridPagos.AllowUserToAddRows = false;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener números.");
            }
        }

        private void BGenerarVenta_Click(object sender, EventArgs e)
        {
            GenerarPago formPago = new GenerarPago();
            formPago.ShowDialog();
        }
        private void BBuscarFacturas_Click(object sender, EventArgs e)
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
                    dataGridPagos.DataSource = new BindingList<Pedido>(pedidosFiltrados);
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

        private void DataGridPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la columna sea la de la imagen y que la fila sea válida
            if (e.ColumnIndex == dataGridPagos.Columns["Imagen"].Index && e.RowIndex >= 0)
            {
                // Obtiene el objeto Pedido vinculado a la fila seleccionada
                Pedido pedido = (Pedido)dataGridPagos.Rows[e.RowIndex].DataBoundItem;
                    
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


        private void DataGridPagos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridPagos.Columns[e.ColumnIndex].Name == "NombreEstadoPedido")
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

        /*private void BGenerarPago_Click(object sender, EventArgs e)
        {
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dataGridPagos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un pedido para generar el pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener la fila seleccionada y el CUIT/CUIL del pedido
            var selectedRow = dataGridPagos.SelectedRows[0];
            string cuilCuit = selectedRow.Cells["CuilCuit"].Value.ToString();

            // Lógica para determinar si es cliente empresa o cliente final
            if (EsCuit(cuilCuit))
            {
                // Abre el formulario para cliente empresa y pasa los datos del pedido
                GenerarPagoEmpresa formEmpresa = new GenerarPagoEmpresa();
                formEmpresa.CargarPedidos((Pedido)selectedRow.DataBoundItem); // Asegúrate de implementar el método `CargarDatosPedido`
                formEmpresa.ShowDialog();
            }
            else
            {
                // Abre el formulario para cliente final y pasa los datos del pedido
                GenerarPago formFinal = new GenerarPago();
                formFinal.CargarPedidos((Pedido)selectedRow.DataBoundItem); // Asegúrate de implementar el método `CargarDatosPedido`
                formFinal.ShowDialog();
            }
        }*/
        private bool EsCuit(string cuilCuit)
        {
            // En Argentina, el CUIT tiene prefijos de 30, o 33 (por ejemplo, para personas jurídicas)
            // Mientras que el CUIL tiene prefijos típicos de 20, 27, 23 para personas físicas.
            // Ajustar la lógica según el criterio para diferenciar CUIT y CUIL
            // Un CUIT de empresa suele empezar con 30 o 33 y tiene longitud de 11 caracteres

            return cuilCuit.Length == 11 && (cuilCuit.StartsWith("30") || cuilCuit.StartsWith("33"));
        }
    }
}
