using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        private void BAgregarVehiculo_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(CBCondicionVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBCodigoPatenteVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBTipoVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBMarcaVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBModeloVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBKilometrajeVehiculo.Text)||
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

            // Si todos los campos son válidos, procedemos con la lógica de agregar
            string vehiculoInfo = ToTitleCase(TBMarcaVehiculo.Text) + " " + ToTitleCase(TBModeloVehiculo.Text);

            MessageBox.Show("Se agregó exitosamente el vehículo: " + vehiculoInfo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos después de agregar
            LimpiarCamposVehiculo();
        }

        // Convertir texto a formato de título
        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        // Limpiar todos los campos después de agregar
        private void LimpiarCamposVehiculo()
        {
            CBCondicionVehiculo.SelectedIndex = -1; // Deselecciona cualquier valor en el ComboBox
            TBCodigoPatenteVehiculo.Clear();
            TBTipoVehiculo.Clear();
            TBMarcaVehiculo.Clear();
            TBModeloVehiculo.Clear();
            TBKilometrajeVehiculo.Clear();
            DTPFechaFabricacion.Value = DateTime.Now; // Restablecer la fecha al día actual
            
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

