using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class IngresarPedido : Form
    {
        private int idVehiculo;
        private int idClienteSeleccionado;

        public IngresarPedido(int idVehiculo)
        {
            InitializeComponent();
            this.idVehiculo = idVehiculo;
            CargarDatosVehiculo(idVehiculo);
            IngresarPedido_Load(this, EventArgs.Empty);
        }

        private void IngresarPedido_Load(object sender, EventArgs e)
        {
            // Establecer la fecha actual en el campo de Fecha Pedido
            TBFechaPedido.Text = DateTime.Now.ToString("dd/MM/yyyy");
            TBFechaPedido.ReadOnly = true; // Hacer que este campo sea de solo lectura
            Empleado empleado= LoginForm.EmpleadoLogin;
            TBVendedor.Text = $"{empleado.Nombre} {empleado.Apellido}";
            TBCuilVendedor.Text = empleado.CUIL;
        }

        private void CargarDatosVehiculo(int idVehiculo)
        {
            VehiculoDAL vehiculoDAL = new VehiculoDAL();
            Vehiculos vehiculo = vehiculoDAL.ObtenerVehiculoPorId(idVehiculo);

            if (vehiculo != null)
            {
                TBCondicionPedido.Text = vehiculo.CondicionNombre;
                if (vehiculo.IdCondicion == 2)
                {
                    TBCodPatPedido.Text = vehiculo.Patente;
                    TBCondicionPedido.Text = "Usado";
                }
                else if (vehiculo.IdCondicion == 1)
                {
                    TBCodPatPedido.Text = vehiculo.CodigoOKM.ToString();
                    TBCondicionPedido.Text = "Nuevo";
                }

                TBMarcaPedido.Text = vehiculo.Marca;
                TBModeloPedido.Text = vehiculo.Modelo;
                TBVersionPedido.Text = vehiculo.Version;
                TBKmPedido.Text = vehiculo.Kilometraje.ToString();
                TBAnioPedido.Text = vehiculo.Anio.ToString("yyyy"); // Muestra solo el año
                TBPrecioPedido.Text = vehiculo.Precio.ToString("F2"); // Muestra el precio con dos decimales

                // Hacer que los campos sean de solo lectura
                TBCondicionPedido.ReadOnly = true;
                TBCodPatPedido.ReadOnly = true;
                TBMarcaPedido.ReadOnly = true;
                TBModeloPedido.ReadOnly = true;
                TBVersionPedido.ReadOnly = true;
                TBKmPedido.ReadOnly = true;
                TBAnioPedido.ReadOnly = true;
                TBPrecioPedido.ReadOnly = true;

                // Cargar la imagen del vehículo en PBVehiculoPedido o una imagen por defecto
                if (!string.IsNullOrEmpty(vehiculo.RutaImagen) && System.IO.File.Exists(vehiculo.RutaImagen))
                {
                    PBVehiculoPedido.Image = Image.FromFile(vehiculo.RutaImagen);
                }
                else
                {
                    PBVehiculoPedido.Image = AgMaGest.Properties.Resources.VhiculoPorDefecto;
                }
            }
        }

        private void CargarImagenVehiculo(string rutaImagen, PictureBox pictureBox)
        {
            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                try
                {
                    pictureBox.Image = Image.FromFile(rutaImagen);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("La imagen del vehículo no se encuentra en la ruta especificada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void BBuscarPedido_Click(object sender, EventArgs e)
        {
            // Obtener el CUIL/CUIT ingresado por el usuario
            string cuilCuit = TBBuscarClientePedido.Text.Trim();

            if (string.IsNullOrEmpty(cuilCuit))
            {
                MessageBox.Show("Por favor, ingrese un CUIL o CUIT para buscar.");
                return;
            }

            try
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                // Filtrar clientes únicamente por el CUIL/CUIT ingresado
                List<Cliente> clientes = clienteDAL.FiltrarClientesConID(cuilCuit);

                if (clientes.Count == 1)
                {
                    // Si hay exactamente un cliente encontrado
                    Cliente cliente = clientes[0];
                    idClienteSeleccionado = cliente.IdCliente; // Guardamos el ID del cliente encontrado

                    // Verificar si el cliente es final o empresa para llenar los datos correspondientes
                    if (cliente is ClienteFinal final)
                    {
                        TBNombreClientePedido.Text = $"{final.NombreCFinal} {final.ApellidoCFinal}";
                        TBCuilCuitClientePedido.Text = final.CuilCFinal;
                    }
                    else if (cliente is ClienteEmpresa empresa)
                    {
                        TBNombreClientePedido.Text = empresa.RazonSocialCEmpresa;
                        TBCuilCuitClientePedido.Text = empresa.CuitCEmpresa;
                    }

                    // Llenar el resto de los datos del cliente
                    TBEmailClientePedido.Text = cliente.EmailCliente;
                    TBCelularClientePedido.Text = cliente.CelularCliente;
                }
                else if (clientes.Count > 1)
                {
                    // Si hay múltiples coincidencias, notificar al usuario
                    MessageBox.Show("Se encontraron múltiples clientes con el CUIL/CUIT ingresado. Por favor, refine su búsqueda.");
                }
                else
                {
                    // Si no se encontraron clientes
                    MessageBox.Show("No se encontraron clientes con el CUIL o CUIT ingresado.");

                    // Limpiar los campos si no se encontró el cliente
                    LimpiarCamposCliente();
                    idClienteSeleccionado = 0; // Restablecer el ID del cliente si no se encontró
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores generales
                MessageBox.Show($"Ocurrió un error al buscar el cliente: {ex.Message}");
            }
        }

        // Método auxiliar para limpiar los campos
        private void LimpiarCamposCliente()
        {
            TBNombreClientePedido.Clear();
            TBCuilCuitClientePedido.Clear();
            TBEmailClientePedido.Clear();
            TBCelularClientePedido.Clear();
        }
        private void BConfirmarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar que el cliente esté seleccionado y el monto esté completo
                if (idClienteSeleccionado == 0 || string.IsNullOrEmpty(TBPrecioPedido.Text))
                {
                    MessageBox.Show("Por favor, asegúrese de que todos los campos obligatorios están completos.");
                    return;
                }

                // Datos necesarios para el pedido
                string cuilEmpleado = TBCuilVendedor.Text;
                int idCliente = idClienteSeleccionado;
                int idVehiculo = this.idVehiculo;
                DateTime fechaPedido = DateTime.Now;
                double montoPedido = double.Parse(TBPrecioPedido.Text);
                int idEstadoPedido = 1;

                // Llamar al método para insertar el pedido en la base de datos
                PedidoDAL pedidoDAL = new PedidoDAL();
                bool resultado = pedidoDAL.InsertarPedido(cuilEmpleado, idCliente, idVehiculo, fechaPedido, montoPedido, idEstadoPedido);

                if (resultado)
                {
                    // Actualizar el estado del vehículo a 2 (asignado a un pedido o confirmado)
                    int estadoConfirmado = 2;


                    bool estadoVehiculoActualizado = pedidoDAL.ActualizarEstadoVehiculo(idVehiculo, estadoConfirmado);

                    if (estadoVehiculoActualizado)
                    {
                        MessageBox.Show("Pedido registrado y estado del vehículo actualizado exitosamente.");
                        this.Close(); // Cerrar el formulario si el pedido y el estado del vehículo se han confirmado correctamente
                    }
                    else
                    {
                        MessageBox.Show("Pedido registrado, pero no se pudo actualizar el estado del vehículo.");
                    }
                }
                else
                {
                    MessageBox.Show("Error al registrar el pedido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void BSalirPedido_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
