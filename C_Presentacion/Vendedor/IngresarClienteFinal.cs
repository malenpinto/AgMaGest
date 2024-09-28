using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class IngresarClienteFinal : Form
    {
        public IngresarClienteFinal()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
        }

        private void IngresarClienteFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BAgregarCFinal_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void BAgregarCFinal_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(TBNombreCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBDniCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCuilCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCelularCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBEmailCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCalleCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBNumeroCalleCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBPisoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBDptoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCodPostalCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBPaisCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBProvinciaCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCiudadCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBLocalidadCFinal.Text))
            {
                // Mostrar mensaje de error si falta algún campo
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
            else if (VerificarEmail() && VerificarDNIyCUIL())
            {
                string nombreCompleto = TBNombreCFinal.Text + " " + TBApellidoCFinal.Text;
                // Si todos los campos son válidos, procedemos con la lógica de agregar.
                MessageBox.Show("Se agrego el Cliente: "+nombreCompleto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Limpiar todos los campos después de agregar
                LimpiarCampos();
            }
        }

        // Función para limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            TBNombreCFinal.Text = "";
            TBApellidoCFinal.Text = "";
            TBDniCFinal.Text = "";
            TBCuilCFinal.Text = "";
            TBCelularCFinal.Text = "";
            TBEmailCFinal.Text = "";
            TBCalleCFinal.Text = "";
            TBNumeroCalleCFinal.Text = "";
            TBPisoCFinal.Text = "";
            TBDptoCFinal.Text = "";
            TBCodPostalCFinal.Text = "";
            CBPaisCFinal.SelectedIndex = -1; 
            CBProvinciaCFinal.SelectedIndex = -1;
            TBCiudadCFinal.Text = "";
            TBLocalidadCFinal.Text = "";
        }

        // Validar formato de correo electrónico
        private bool VerificarEmail()
        {
            string email = TBEmailCFinal.Text;
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
            if (TBDniCFinal.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.");
                return false;
            }
            if (TBCuilCFinal.Text.Length != 11)
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

        private void BSalirCFinal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
