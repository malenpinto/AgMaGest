using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class IngresarEmpleado : Form
    {
        public IngresarEmpleado()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
        }

        private void IngresarEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BAgregarEmpleado_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void BAgregarEmpleado_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(TBNombreEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBDniEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCuilEmpleado.Text) ||
                string.IsNullOrWhiteSpace(CBPerfilEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCelularEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBEmailEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCalleEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBNumCalleEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBNumPisoEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBDptoEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCodPostalEmpleado.Text) ||
                string.IsNullOrWhiteSpace(CBPaisEmpleado.Text) ||
                string.IsNullOrWhiteSpace(CBProvinciaEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCiudadEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBLocalidadEmpleado.Text))
            {
                // Mostrar mensaje de error si falta algún campo
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (VerificarEmail() && VerificarDNIyCUIL())
            {
                // Convertir el nombre y apellido a formato de título (primeras letras en mayúsculas)
                string nombreCompleto = ToTitleCase(TBApellidoEmpleado.Text) + " " + ToTitleCase(TBNombreEmpleado.Text);
                
                // Si todos los campos son válidos, procedemos con la lógica de agregar.
                MessageBox.Show("Se agrego exitosamente a: " + nombreCompleto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar todos los campos después de agregar
                LimpiarCampos();
            }
        }

        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        // Función para limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            TBNombreEmpleado.Text = "";
            TBApellidoEmpleado.Text = "";
            TBDniEmpleado.Text = "";
            TBCuilEmpleado.Text = "";
            TBCelularEmpleado.Text = "";
            CBPerfilEmpleado.SelectedIndex = -1;
            TBEmailEmpleado.Text = "";
            TBCalleEmpleado.Text = "";
            TBNumCalleEmpleado.Text = "";
            TBNumPisoEmpleado.Text = "";
            TBDptoEmpleado.Text = "";
            TBCodPostalEmpleado.Text = "";
            CBPaisEmpleado.SelectedIndex = -1;
            CBProvinciaEmpleado.SelectedIndex = -1;
            TBCiudadEmpleado.Text = "";
            TBLocalidadEmpleado.Text = "";
        }

        // Validar formato de correo electrónico
        private bool VerificarEmail()
        {
            string email = TBEmailEmpleado.Text;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("El formato del correo electrónico es inválido.");
                return false;
            }
            return true;
        }

        // Validar que el DNI y CUIL tengan el formato adecuado
        private bool VerificarDNIyCUIL()
        {
            if (TBDniEmpleado.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.");
                return false;
            }
            if (TBCuilEmpleado.Text.Length != 11)
            {
                MessageBox.Show("El CUIL debe tener 11 dígitos.");
                return false;
            }
            return true;
        }

        // Validar que el input sea solo números
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener números.");
            }
        }

        // Validar que el input sea solo letras
        private void SoloLetras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener letras.");
            }
        }

        private void BSalirEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
