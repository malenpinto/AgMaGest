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
    public partial class EditarVehiculo : Form
    {
        private string rutaImagenSeleccionada; // Ruta para la imagen seleccionada
        private Vehiculos vehiculoActual;

        public EditarVehiculo(Vehiculos vehiculo)
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.vehiculoActual = vehiculo;
            this.Load += new System.EventHandler(this.EditarVehiculo_Load);
        }

        private void EditarVehiculo_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar los datos de los ComboBox
                CargarComboBox();
                CargarDatosVehiculo(vehiculoActual.IdVehiculo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarVehiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BEditarVehiculo_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void CargarComboBox()
        {
            try
            {
                // Cargar Condicion
                CondicionVehiculoDAL condicionDAL = new CondicionVehiculoDAL();
                CBCondicionEditar.DataSource = condicionDAL.ObtenerCondicionVehiculo();
                CBCondicionEditar.DisplayMember = "NombreCondicion";
                CBCondicionEditar.ValueMember = "IdCondicion";

                // Cargar tipo
                TipoVehiculoDAL tipoDAL = new TipoVehiculoDAL();
                CBTipoEditar.DataSource = tipoDAL.ObtenerTipoVehiculo();
                CBTipoEditar.DisplayMember = "NombreTipoVehiculo";
                CBTipoEditar.ValueMember = "IdTipoVehiculo";

                // Cargar estados
                EstadoVehiculoDAL estadoDAL = new EstadoVehiculoDAL();
                CBEstadoEditar.DataSource = estadoDAL.ObtenerEstadoVehiculo();
                CBEstadoEditar.DisplayMember = "NombreEstado";
                CBEstadoEditar.ValueMember = "IdEstado";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de los ComboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BCargarImagenEditar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos de imagen (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png",
                Title = "Seleccionar Imagen del Vehículo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string rutaImagenOriginal = openFileDialog.FileName;
                    string nombreImagen = Path.GetFileName(rutaImagenOriginal);
                    string nuevaRutaImagen = Path.Combine(@"C:\AgMaGest\AgMaGest\bin\Debug\Resources\Vehiculos", nombreImagen);

                    if (File.Exists(nuevaRutaImagen))
                    {
                        string nombreSinExtension = Path.GetFileNameWithoutExtension(nombreImagen);
                        string extension = Path.GetExtension(nombreImagen);
                        int contador = 1;

                        while (File.Exists(nuevaRutaImagen))
                        {
                            nuevaRutaImagen = Path.Combine(@"C:\AgMaGest\AgMaGest\bin\Debug\Resources\Vehiculos", $"{nombreSinExtension}_{contador}{extension}");
                            contador++;
                        }
                    }

                    File.Copy(rutaImagenOriginal, nuevaRutaImagen, true);
                    PBImagenEditar.Image = Image.FromFile(nuevaRutaImagen);
                    PBImagenEditar.SizeMode = PictureBoxSizeMode.Zoom;
                    rutaImagenSeleccionada = nuevaRutaImagen;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarDatosVehiculo(int id)
        {
            try
            {
                // Obtener los datos del vehículo
                VehiculoDAL vehiculoDAL = new VehiculoDAL();
                Vehiculos vehiculo = vehiculoDAL.ObtenerVehiculoPorId(id);

                if (vehiculo != null)
                {
                    // Cargar datos en los controles del formulario
                    TBMarcaEditar.Text = vehiculo.Marca;
                    TBModeloEditar.Text = vehiculo.Modelo;
                    TBKilometrajeEditar.Text = vehiculo.Kilometraje.ToString();
                    TBVersionEditar.Text = vehiculo.Version;
                    DTPFechaFabEditar.Value = vehiculo.Anio != DateTime.MinValue ? vehiculo.Anio : DateTime.Today;
                    TBPrecioEditar.Text = vehiculo.Precio.ToString(CultureInfo.InvariantCulture);
                    CBCondicionEditar.SelectedValue = vehiculo.IdCondicion;
                    CBTipoEditar.SelectedValue = vehiculo.IdTipoVehiculo;
                    CBEstadoEditar.SelectedValue = vehiculo.IdEstado;

                    if (vehiculo.IdCondicion == 2) 
                    {
                        TBCodigoPatenteEditar.Text = vehiculo.Patente;
                    }
                    else if (vehiculo.IdCondicion == 1) 
                    {
                        TBCodigoPatenteEditar.Text = vehiculo.CodigoOKM.ToString();
                    }
                    // Cargar la imagen del vehículo si existe
                    CargarImagenVehiculo(vehiculo.RutaImagen);
                }
                else
                {
                    MessageBox.Show("Vehículo no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarImagenVehiculo(string rutaImagen)
        {
            if (!string.IsNullOrEmpty(rutaImagen) && File.Exists(rutaImagen))
            {
                try
                {
                    PBImagenEditar.Image = Image.FromFile(rutaImagen);
                    PBImagenEditar.SizeMode = PictureBoxSizeMode.Zoom;
                    rutaImagenSeleccionada = rutaImagen; // Guarda la ruta de la imagen actual
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


        private void BEditarVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                vehiculoActual.Marca = ToTitleCase(TBMarcaEditar.Text);
                vehiculoActual.Modelo = ToTitleCase(TBModeloEditar.Text);
                vehiculoActual.Kilometraje = int.Parse(TBKilometrajeEditar.Text);
                vehiculoActual.Version = ToTitleCase(TBVersionEditar.Text);
                vehiculoActual.Anio = new DateTime(DTPFechaFabEditar.Value.Year, 1, 1);
                vehiculoActual.Precio = double.Parse(TBPrecioEditar.Text, CultureInfo.InvariantCulture);
                vehiculoActual.IdTipoVehiculo = Convert.ToInt32(CBTipoEditar.SelectedValue);
                vehiculoActual.IdEstado = Convert.ToInt32(CBEstadoEditar.SelectedValue);
                vehiculoActual.IdCondicion = Convert.ToInt32(CBCondicionEditar.SelectedValue);
                vehiculoActual.RutaImagen = rutaImagenSeleccionada;// Ruta de la imagen actual o nueva


                // Determinar si usar CódigoOKM o Patente
                if (vehiculoActual.IdCondicion == 1) // Nuevo (Condición 1)
                {
                    if (!int.TryParse(TBCodigoPatenteEditar.Text, out int codigoOKM))
                    {
                        MessageBox.Show("El código para vehículos nuevos debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    vehiculoActual.CodigoOKM = codigoOKM;
                }
                else // Usado (otra condición)
                {
                    if (string.IsNullOrWhiteSpace(TBCodigoPatenteEditar.Text))
                    {
                        MessageBox.Show("Debe ingresar una patente para vehículos usados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    vehiculoActual.Patente = TBCodigoPatenteEditar.Text.ToUpper();
                }

                VehiculoDAL vehiculoDAL = new VehiculoDAL();
                bool actualizado = vehiculoDAL.ActualizarVehiculo(vehiculoActual);
                if (actualizado)
                {
                    MessageBox.Show("Vehiculo actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al editar el vehículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }


        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(CBCondicionEditar.Text) ||
                string.IsNullOrWhiteSpace(CBTipoEditar.Text) ||
                string.IsNullOrWhiteSpace(CBEstadoEditar.Text) ||
                string.IsNullOrWhiteSpace(TBCodigoPatenteEditar.Text) ||
                string.IsNullOrWhiteSpace(TBMarcaEditar.Text) ||
                string.IsNullOrWhiteSpace(TBModeloEditar.Text) ||
                string.IsNullOrWhiteSpace(TBKilometrajeEditar.Text) ||
                string.IsNullOrWhiteSpace(TBPrecioEditar.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (DTPFechaFabEditar.Value > DateTime.Now)
            {
                MessageBox.Show("La fecha de fabricación no puede ser una fecha futura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (PBImagenEditar.Image == null)
            {
                MessageBox.Show("Debe agregar una imagen del vehículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener números.");
            }
        }

        private void BSalirEditarVehiculo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
