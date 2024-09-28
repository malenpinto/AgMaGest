﻿using System;
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

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class IngresarClienteEmpresa : Form
    {
        public IngresarClienteEmpresa()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
        }

        private void IngresarClienteEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BAgregarCEmpresa_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }
        private void BAgregarCEmpresa_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(TBRazonSocial.Text) ||
                string.IsNullOrWhiteSpace(TBCuitEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBTelefonoEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBEmailEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBCalleEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBNumCalleEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBNumPisoEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBDptoEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBCodPostalEmpresa.Text) ||
                string.IsNullOrWhiteSpace(CBPaisEmpresa.Text) ||
                string.IsNullOrWhiteSpace(CBProvinciaEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBCiudadEmpresa.Text) ||
                string.IsNullOrWhiteSpace(TBLocalidadEmpresa.Text))
            {
                // Mostrar mensaje de error si falta algún campo
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (VerificarEmail() && VerificarCUIT())
            {
                // Convertir el nombre y apellido a formato de título (primeras letras en mayúsculas)
                string nombreCompleto = ToTitleCase(TBRazonSocial.Text);

                // Si todos los campos son válidos, procedemos con la lógica de agregar.
                MessageBox.Show("Se agrego exitosamente a: " + nombreCompleto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar todos los campos después de agregar
                LimpiarCampos();
            }
        }

        // Función para convertir la primera letra de cada palabra a mayúscula
        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        // Función para limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            TBRazonSocial.Text = "";
            TBCuitEmpresa.Text = "";
            TBTelefonoEmpresa.Text = "";
            TBEmailEmpresa.Text = "";
            TBCalleEmpresa.Text = "";
            TBNumCalleEmpresa.Text = "";
            TBNumPisoEmpresa.Text = "";
            TBDptoEmpresa.Text = "";
            TBCodPostalEmpresa.Text = "";
            CBPaisEmpresa.SelectedIndex = -1;
            CBProvinciaEmpresa.SelectedIndex = -1;
            TBCiudadEmpresa.Text = "";
            TBLocalidadEmpresa.Text = "";
        }

        // Validar formato de correo electrónico
        private bool VerificarEmail()
        {
            string email = TBEmailEmpresa.Text;
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("El formato del correo electrónico es inválido.");
                return false;
            }
            return true;
        }

        // Validar que el DNI y CUIL tengan el formato adecuado
        private bool VerificarCUIT()
        {
            if (TBCuitEmpresa.Text.Length != 11)
            {
                MessageBox.Show("El CUIT debe tener 11 dígitos.");
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

        private void BSalirCEmpresa_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
