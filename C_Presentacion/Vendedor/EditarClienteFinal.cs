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
    public partial class EditarClienteFinal : Form
    {
        public EditarClienteFinal()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
        }

        private void EditarClienteFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BAgregarEditarCFinal_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void BAgregarEditarCFinal_Click(object sender, EventArgs e)
        {
            // Verificar que todos los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(TBNombreEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBDniEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCuilEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCelularEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBEmailEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCalleEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBNumCalleEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCodPostalEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBPaisEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBProvinciaEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCiudadEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBLocalidadEditarCFinal.Text))
            {
                // Mostrar mensaje de error si falta algún campo
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (VerificarEmail() && VerificarDNIyCUIL())
            {
                // Convertir el nombre y apellido a formato de título (primeras letras en mayúsculas)
                string nombreCompleto = ToTitleCase(TBNombreEditarCFinal.Text) + " " + ToTitleCase(TBApellidoEditarCFinal.Text);

                // Si todos los campos son válidos, procedemos con la lógica de agregar.
                MessageBox.Show("Se editó exitosamente a: " + nombreCompleto, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        // Función para convertir la primera letra de cada palabra a mayúscula
        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        // Validar formato de correo electrónico
        private bool VerificarEmail()
        {
            string email = TBEmailEditarCFinal.Text;
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
            if (TBDniEditarCFinal.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.");
                return false;
            }
            if (TBCuilEditarCFinal.Text.Length != 11)
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

        private void BSalirEditarCFinal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}