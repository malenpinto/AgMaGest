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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class IngresarVehiculo : Form
    {
        public IngresarVehiculo()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.Load += IngresarVehiculo_Load; // Suscribirse al evento Load
            CBTipoVehiculo.DataSource = null; // Asegurar de que esté vacío al principio
        }

        public void IngresarVehiculo_Load(object sender, EventArgs e)
        {
            CargarTipoVehiculos();
            CargarCondicionVehiculos();
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

        private void BSalirVehiculo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CargarTipoVehiculos()
        {
            // Obtener la lista de tipos de vehiculo desde la base de datos
            TipoVehiculoDAL tipoVehiculoDAL = new TipoVehiculoDAL();
            List<TipoVehiculo> tipos = tipoVehiculoDAL.ObtenerTipoVehiculo();

            // Agregar una opción por defecto "Seleccione una"
            tipos.Insert(0, new TipoVehiculo { IdTipoVehiculo = 0, NombreTipoVehiculo = "Seleccione un tipo" });

            // Asignar la lista al ComboBox
            CBTipoVehiculo.DataSource = tipos; // Asignar la lista de tipos al ComboBox
            CBTipoVehiculo.DisplayMember = "NombreTipoVehiculo"; // Campo que se mostrará en el ComboBox
            CBTipoVehiculo.ValueMember = "IdTipoVehiculo"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBTipoVehiculo.SelectedIndex = 0;
        }

        private void CargarCondicionVehiculos()
        {
            // Obtener la lista de condicion de vehiculo desde la base de datos
            CondicionVehiculoDAL CondicionVehiculoDAL = new CondicionVehiculoDAL();
            List<CondicionVehiculo> condiciones = CondicionVehiculoDAL.ObtenerCondicionVehiculo();

            // Agregar una opción por defecto "Seleccione una"
            condiciones.Insert(0, new CondicionVehiculo { IdCondicion = 0, NombreCondicion = "Seleccione una Condición" });

            // Asignar la lista al ComboBox
            CBCondicionVehiculo.DataSource = condiciones; // Asignar la lista de tipos al ComboBox
            CBCondicionVehiculo.DisplayMember = "NombreCondicion"; // Campo que se mostrará en el ComboBox
            CBCondicionVehiculo.ValueMember = "IdCondicion"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBCondicionVehiculo.SelectedIndex = 0;
        }

        private void BAgregarVehiculo_Click(object sender, EventArgs e)
        {
            if (CBTipoVehiculo.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar un Tipo de Vehiculo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que todos los campos estén completos
            if (CBCondicionVehiculo.SelectedIndex == -1 ||
                CBTipoVehiculo.SelectedIndex == -1 ||
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
                Anio = DTPFechaFabricacion.Value,
                Precio = double.Parse(TBPrecioVehiculo.Text),
                IdTipoVehiculo = Convert.ToInt32(CBTipoVehiculo.SelectedValue),
                IdEstado = 1,
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

            // Convertir imagen a byte array
            byte[] imagenBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                PBImagenVehiculo.Image.Save(ms, PBImagenVehiculo.Image.RawFormat);
                imagenBytes = ms.ToArray();
            }

            // Intentar insertar el vehículo en la base de datos
            try
            {
                VehiculoDAL vehiculoDal = new VehiculoDAL();
                if (vehiculoDal.InsertarVehiculo(vehiculo, imagenBytes))
                {
                    // Si todos los campos son válidos, procedemos con la lógica de agregar
                    string vehiculoInfo = vehiculo.Marca + " " + vehiculo.Modelo;

                    MessageBox.Show("Se agregó exitosamente el vehículo: " + vehiculoInfo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposVehiculo();
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
            CBCondicionVehiculo.SelectedIndex = 0; // Deselecciona cualquier valor en el ComboBox
            TBCodigoPatenteVehiculo.Clear();
            CBTipoVehiculo.SelectedIndex = 0;
            TBMarcaVehiculo.Clear();
            TBModeloVehiculo.Clear();
            TBVersionVehiculo.Clear();
            TBKilometrajeVehiculo.Clear();
            DTPFechaFabricacion.Value = DateTime.Now; // Restablecer la fecha al día actual
            TBPrecioVehiculo.Clear();
            // Limpiar la imagen del PictureBox (establecer a null)
            PBImagenVehiculo.Image = Properties.Resources.Icono_MasVehiculo; // Tambien se puede reemplazar con una imagen por defecto                                                           // Restablecer el SizeMode a Normal para que no se deforme el PictureBox sin imagen
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
                // Obtener la ruta del archivo seleccionado
                string rutaImagen = openFileDialog.FileName;

                // Cargar la imagen seleccionada en el PictureBox
                PBImagenVehiculo.Image = Image.FromFile(rutaImagen);
                PBImagenVehiculo.SizeMode = PictureBoxSizeMode.StretchImage; // Ajustar la imagen al tamaño del PictureBox
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
    }
}

