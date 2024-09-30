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
    public partial class EditarVehiculo : Form
    {
        public EditarVehiculo()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
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

        private void BEditarVehiculo_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos estén completos
            if (string.IsNullOrWhiteSpace(CBCondicionVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBCodigoPatenteVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBTipoVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBMarcaVehiculo.Text) ||
                string.IsNullOrWhiteSpace(TBModeloVehiculo.Text) ||
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

            // Si todos los campos son válidos, procedemos con la lógica de agregar
            string vehiculoInfo = ToTitleCase(TBMarcaVehiculo.Text) + " " + ToTitleCase(TBModeloVehiculo.Text);

            MessageBox.Show("Se edito exitosamente el vehículo: " + vehiculoInfo, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private string ToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
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
