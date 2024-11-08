using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
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
    public partial class EditarEmpleado : Form
    {
        private Empleado empleadoActual;
        public EditarEmpleado(Empleado empleado)
        {
            InitializeComponent();
            // Permite que el formulario capture el evento KeyDown
            this.KeyPreview = true;
            empleadoActual = empleado;
            CargarDatosEnCampos();
        }

        private void IngresarEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BEditarEmpleado_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void CargarDatosEnCampos()
        {
            if (empleadoActual != null)
            {
                TBNombreEditarEmpleado.Text = empleadoActual.Nombre ;
                TBApellidoEditarEmpleado.Text = empleadoActual.Apellido;
                TBDniEditarEmpleado.Text = empleadoActual.DNI;
                TBCuilEditarEmpleado.Text = empleadoActual.CUIL;
                TBEmailEditarEmpleado.Text = empleadoActual.Email;
                TBCelularEditarEmpleado.Text = empleadoActual.Celular;
                DTPFechaNacimiento.Value = empleadoActual.FechaNacimiento;
                TBCalleEditarEmpleado.Text = empleadoActual.Calle;
                TBNumCalleEditarEmpleado.Text = empleadoActual.NumeroCalle.ToString(); // Convertir int a string
                TBNumPisoEditarEmpleado.Text = empleadoActual.Piso.ToString(); // Convertir int a string
                TBDptoEditarEmpleado.Text = empleadoActual.Dpto.ToString(); // Convertir int a string
                TBCodPostalEditarEmpleado.Text = empleadoActual.CodigoPostal.ToString(); // Convertir int a string
                CBPaisEditarEmpleado.SelectedValue = empleadoActual.IdLocalidad;
            }
        }

        private void BEditarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrWhiteSpace(TBNombreEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBApellidoEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBDniEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBCuilEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBEmailEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBCelularEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBCalleEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBNumCalleEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBNumPisoEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBDptoEditarEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(TBCodPostalEditarEmpleado.Text))
                {
                    MessageBox.Show("Todos los campos deben estar completos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validar y convertir los campos numéricos
                if (!int.TryParse(TBNumCalleEditarEmpleado.Text, out int numeroCalle) ||
                    !int.TryParse(TBNumPisoEditarEmpleado.Text, out int piso) ||
                    !int.TryParse(TBDptoEditarEmpleado.Text, out int dpto) ||
                    !int.TryParse(TBCodPostalEditarEmpleado.Text, out int codigoPostal))
                {
                    MessageBox.Show("Los campos numéricos (Número de Calle, Piso, Dpto, Código Postal) deben contener valores válidos.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Actualiza el objeto empleadoActual con los datos editados
                empleadoActual.Nombre = TBNombreEditarEmpleado.Text;
                empleadoActual.Apellido = TBApellidoEditarEmpleado.Text;
                empleadoActual.DNI = TBDniEditarEmpleado.Text;
                empleadoActual.CUIL = TBCuilEditarEmpleado.Text;
                empleadoActual.Email = TBEmailEditarEmpleado.Text;
                empleadoActual.Celular = TBCelularEditarEmpleado.Text;
                empleadoActual.FechaNacimiento = DTPFechaNacimiento.Value;
                empleadoActual.Calle = TBCalleEditarEmpleado.Text;
                empleadoActual.NumeroCalle = numeroCalle;
                empleadoActual.Piso = piso;
                empleadoActual.Dpto = TBDptoEditarEmpleado.Text;
                empleadoActual.CodigoPostal = codigoPostal;

                // Llamar a la capa de datos para actualizar el empleado
                var empleadoDAL = new EmpleadoDAL();
                empleadoDAL.ActualizarEmpleado(empleadoActual);

                MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        // Validar formato de correo electrónico
        private bool VerificarEmail()
        {
            string email = TBEmailEditarEmpleado.Text;
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
            if (TBDniEditarEmpleado.Text.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 dígitos.");
                return false;
            }
            if (TBCuilEditarEmpleado.Text.Length != 11)
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

        private void BSalirEditarEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
