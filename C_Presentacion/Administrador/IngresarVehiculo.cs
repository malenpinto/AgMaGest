using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class IngresarVehiculo : Form
    {
        private string rutaImagenSeleccionada; // Variable de clase para almacenar la ruta de la imagen

        public IngresarVehiculo()
        {
            InitializeComponent();
            CargarCondiciones();
            CargarTiposVehiculo();
            CargarEstadosVehiculo();
        }

        private void AgregarVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BAgregarVehiculo_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void CargarCondiciones()
        {
            CBCondicionVehiculo.DataSource = null; // Limpia el origen de datos previo
            CBCondicionVehiculo.Items.Clear();    // Limpia las opciones previas


            // Obtener la lista de condiciones desde la base de datos
            CondicionVehiculoDAL condicionDAL = new CondicionVehiculoDAL();
            List<CondicionVehiculo> condiciones = condicionDAL.ObtenerCondicionVehiculo();

            // Agregar una opción por defecto 
            condiciones.Insert(0, new CondicionVehiculo { IdCondicion = 0, NombreCondicion = "Seleccione una condición" });

            // Asignar la lista de países al ComboBox
            CBCondicionVehiculo.DataSource = condiciones;
            CBCondicionVehiculo.DisplayMember = "NombreCondicion"; // Nombre para mostrar
            CBCondicionVehiculo.ValueMember = "IdCondicion"; // Valor seleccionado

            // Seleccionar la opción por defecto
            CBCondicionVehiculo.SelectedIndex = 0;
        }

        private void CargarTiposVehiculo()
        {
            CBTipoVehiculo.DataSource = null;
            CBTipoVehiculo.Items.Clear();

            // Obtener la lista de tipos desde la base de datos
            TipoVehiculoDAL tipoDAL = new TipoVehiculoDAL();
            List<TipoVehiculo> tipos = tipoDAL.ObtenerTipoVehiculo();

            // Agregar una opción por defecto 
            tipos.Insert(0, new TipoVehiculo { IdTipoVehiculo = 0, NombreTipoVehiculo = "Seleccione un tipo" });

            // Asignar la lista de países al ComboBox
            CBTipoVehiculo.DataSource = tipos;
            CBTipoVehiculo.DisplayMember = "NombreTipoVehiculo"; // Nombre para mostrar
            CBTipoVehiculo.ValueMember = "IdTipoVehiculo"; // Valor seleccionado

            // Seleccionar la opción por defecto
            CBTipoVehiculo.SelectedIndex = 0;
        }

        private void CargarEstadosVehiculo()
        {
            CBEstadoVehiculo.DataSource = null;
            CBEstadoVehiculo.Items.Clear();

            // Obtener la lista de estados desde la base de datos
            EstadoVehiculoDAL estadoDAL = new EstadoVehiculoDAL();
            List<EstadoVehiculo> estados = estadoDAL.ObtenerEstadoVehiculo();

            // Agregar una opción por defecto "Seleccione una"
            estados.Insert(0, new EstadoVehiculo { IdEstado = 0, NombreEstado = "Seleccione un estado" });

            // Asignar la lista de países al ComboBox
            CBEstadoVehiculo.DataSource = estados;
            CBEstadoVehiculo.DisplayMember = "NombreEstado"; // Nombre para mostrar
            CBEstadoVehiculo.ValueMember = "IdEstado"; // Valor seleccionado

            // Seleccionar la opción por defecto
            CBEstadoVehiculo.SelectedIndex = 0;
        }

        private void BAgregarVehiculo_Click(object sender, EventArgs e)
        {
            if (CBCondicionVehiculo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la condición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBTipoVehiculo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de vehículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBEstadoVehiculo.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el estado del vehículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Verificar que todos los campos estén completos
            if (CBCondicionVehiculo.SelectedIndex == -1 ||
                CBTipoVehiculo.SelectedIndex == -1 ||
                CBEstadoVehiculo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(TBCodigoPatenteVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBMarcaVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBModeloVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBVersionVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBKilometrajeVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBPrecioVehiculo.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar la fecha de fabricación
            if (DTPFechaFabricacion.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de fabricación no puede ser una fecha futura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que se haya cargado una imagen
            if (PBImagenVehiculo.Image == null)
            {
                MessageBox.Show("Debe agregar una imagen del vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear instancia de Vehiculos y asignar valores
            Vehiculos vehiculo = new Vehiculos
            {
                Marca = ToTitleCase(TBMarcaVehiculo.Text),
                Modelo = ToTitleCase(TBModeloVehiculo.Text),
                Version = ToTitleCase(TBVersionVehiculo.Text),
                Kilometraje = int.Parse(TBKilometrajeVehiculo.Text),
                Anio = new DateTime(DTPFechaFabricacion.Value.Year, 1, 1),
                Precio = double.Parse(TBPrecioVehiculo.Text, CultureInfo.InvariantCulture),
                IdTipoVehiculo = Convert.ToInt32(CBTipoVehiculo.SelectedValue),
                IdEstado = Convert.ToInt32(CBEstadoVehiculo.SelectedValue),
                IdCondicion = Convert.ToInt32(CBCondicionVehiculo.SelectedValue)
            };

            // Asignar valores a Patente y CodigoOKM según la condición del vehículo
            string condicionSeleccionada = CBCondicionVehiculo.Text;
            if (condicionSeleccionada.Equals("Usado", StringComparison.OrdinalIgnoreCase))
            {
                vehiculo.Patente = TBCodigoPatenteVehiculo.Text;
                vehiculo.CodigoOKM = null;
            }
            else if (condicionSeleccionada.Equals("Nuevo", StringComparison.OrdinalIgnoreCase))
            {
                vehiculo.CodigoOKM = int.TryParse(TBCodigoPatenteVehiculo.Text, out int codigoOkm) ? (int?)codigoOkm : null;
                vehiculo.Patente = null;
            }

            try
            {
                VehiculoDAL vehiculoDal = new VehiculoDAL();
                vehiculo.RutaImagen = rutaImagenSeleccionada;
                if (vehiculoDal.InsertarVehiculo(vehiculo, vehiculo.RutaImagen))

                {
                    string vehiculoInfo = vehiculo.Marca + " " + vehiculo.Modelo;

                    MessageBox.Show("Se agregó exitosamente el vehículo: " + vehiculoInfo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposVehiculo();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el vehículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            // Convertir texto a formato de título
        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        // Limpiar todos los campos después de agregar
        private void LimpiarCamposVehiculo()
        {
            CBCondicionVehiculo.SelectedIndex = 0;
            TBCodigoPatenteVehiculo.Clear();
            CBTipoVehiculo.SelectedIndex = 0;
            CBEstadoVehiculo.SelectedIndex = 0;
            TBMarcaVehiculo.Clear();
            TBModeloVehiculo.Clear();
            TBVersionVehiculo.Clear();
            TBKilometrajeVehiculo.Clear();
            DTPFechaFabricacion.Value = DateTime.Now;
            TBPrecioVehiculo.Clear();
            PBImagenVehiculo.Image = Properties.Resources.Icono_MasVehiculo;
            PBImagenVehiculo.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void BCargarImagenVehiculo_Click(object sender, EventArgs e)
        {
            // Crear y configurar el diálogo para seleccionar archivos
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                // Filtrar los tipos de archivo a imágenes
                Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png",
                Title = "Seleccionar Imagen del Vehículo"
            };

            // Mostrar el cuadro de diálogo y verificar si el usuario selecciona un archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtener la ruta del archivo seleccionado
                    string rutaImagenOriginal = openFileDialog.FileName;

                    // Generar un nombre único para la imagen basada en la fecha y hora (para evitar sobrescritura)
                    string nombreImagen = Path.GetFileName(rutaImagenOriginal);
                    string nuevaRutaImagen = Path.Combine(@"C:\AgMaGest\AgMaGest\bin\Debug\Resources\Vehiculos", nombreImagen);

                    // Verificar si el archivo ya existe en la ruta de destino
                    if (File.Exists(nuevaRutaImagen))
                    {
                        // Si existe, puedes renombrar la imagen o agregar un sufijo único
                        string nombreSinExtension = Path.GetFileNameWithoutExtension(nombreImagen);
                        string extension = Path.GetExtension(nombreImagen);
                        int contador = 1;

                        // Generar un nombre único para la imagen
                        while (File.Exists(nuevaRutaImagen))
                        {
                            nuevaRutaImagen = Path.Combine(@"C:\AgMaGest\AgMaGest\bin\Debug\Resources\Vehiculos",
                                $"{nombreSinExtension}_{contador}{extension}");
                            contador++;
                        }
                    }

                    // Copiar la imagen a la nueva ruta
                    File.Copy(rutaImagenOriginal, nuevaRutaImagen);

                    // Cargar la imagen seleccionada en el PictureBox
                    PBImagenVehiculo.Image = Image.FromFile(nuevaRutaImagen);
                    PBImagenVehiculo.SizeMode = PictureBoxSizeMode.Zoom; // Ajustar la imagen al tamaño del PictureBox sin distorsionar

                    // Guardar la ruta de la imagen seleccionada para usarla al guardar el vehículo
                    rutaImagenSeleccionada = nuevaRutaImagen;
                }
                catch (Exception ex)
                {
                    // Si ocurre un error al cargar la imagen, mostrar un mensaje
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener números.");
            }
        }

        private void BSalirVehiculo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

