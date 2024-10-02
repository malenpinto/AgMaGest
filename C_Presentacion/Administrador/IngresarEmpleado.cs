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
using AgMaGest.C_Logica.Entidades;  // Importa la clase
using AgMaGest.C_Datos;  // Importa la capa de datos


namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class IngresarEmpleado : Form
    {
        public IngresarEmpleado()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.Load += IngresarEmpleado_Load; // Suscribirse al evento Load
            CBPerfilEmpleado.DataSource = null; // Asegurar de que esté vacío al principio
            
        }

        private void IngresarEmpleado_Load(object sender, EventArgs e)
        {
            CargarPaises(); // Asegura de cargar los países
            CargarPerfiles(); // Cargar perfiles
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

        private void CargarPaises()
        {
            PaisDAL paisDAL = new PaisDAL();
            List<Pais> paises = paisDAL.ObtenerPaises();

            CBPaisEmpleado.DataSource = paises; // Asignar la lista de países al ComboBox
            CBPaisEmpleado.DisplayMember = "NombrePais"; // Campo que se mostrará en el ComboBox
            CBPaisEmpleado.ValueMember = "IdPais"; // Campo que se utilizará como valor

            CBPaisEmpleado.SelectedIndexChanged += CBPaisEmpleado_SelectedIndexChanged; // Suscribirse al evento SelectedIndexChanged
        }

        private void CBPaisEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que el país seleccionado no sea nulo
            if (CBPaisEmpleado.SelectedValue != null)
            {
                int idPais = Convert.ToInt32(CBPaisEmpleado.SelectedValue);
                CargarProvincias(idPais); // Cargar provincias según el país seleccionado
            }
        }


        private void CargarProvincias(int idPais)
        {
            ProvinciaDAL provinciaDAL = new ProvinciaDAL();
            List<Provincia> provincias = provinciaDAL.ObtenerProvinciasPorPais(idPais);

            CBProvinciaEmpleado.DataSource = provincias; // Asignar la lista de provincias al ComboBox
            CBProvinciaEmpleado.DisplayMember = "NombreProvincia"; // Campo que se mostrará en el ComboBox
            CBProvinciaEmpleado.ValueMember = "IdProvincia"; // Campo que se utilizará como valor
        }

        private void CargarPerfiles()
        {
            EmpleadoDAL empleadoDAL = new EmpleadoDAL();
            List<PerfilEmpleado> perfiles = empleadoDAL.ObtenerPerfiles();

            CBPerfilEmpleado.DataSource = perfiles; // Asignar la lista de perfiles al ComboBox
            CBPerfilEmpleado.DisplayMember = "NombrePerfil"; // Campo que se mostrará en el ComboBox
            CBPerfilEmpleado.ValueMember = "IdPerfil"; // Campo que se utilizará como valor
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
                try
                {
                    // Crear una instancia de EmpleadoDAL
                    EmpleadoDAL empleadoDAL = new EmpleadoDAL();

                    // Crear un objeto Empleado con los datos del formulario
                    Empleado nuevoEmpleado = new Empleado()
                    {
                        IdEmpleado = empleadoDAL.ObtenerNuevoIdEmpleado(), // Llamar al método para obtener un nuevo ID
                        Nombre = TBNombreEmpleado.Text,
                        Apellido = TBApellidoEmpleado.Text,
                        DNI = TBDniEmpleado.Text,
                        CUIL = TBCuilEmpleado.Text,
                        Celular = TBCelularEmpleado.Text,
                        Email = TBEmailEmpleado.Text,
                        Calle = TBCalleEmpleado.Text,
                        NumeroCalle = TBNumCalleEmpleado.Text,
                        Piso = TBNumPisoEmpleado.Text,
                        Dpto = TBDptoEmpleado.Text,
                        CodigoPostal = TBCodPostalEmpleado.Text,
                        IdLocalidad = Convert.ToInt32(CBPaisEmpleado.SelectedValue), // 
                        IdPerfil = Convert.ToInt32(CBPerfilEmpleado.SelectedValue), // Asumiendo que tenemos una lista de perfiles
                        IdEstado = 1, // 1 estado activo
                        Ciudad = TBCiudadEmpleado.Text,
                        Pais = CBPaisEmpleado.Text,
                        Provincia = CBProvinciaEmpleado.Text,
                        Localidad = TBLocalidadEmpleado.Text
                    };

                    // Insertar el empleado en la base de datos
                    empleadoDAL.InsertarEmpleado(nuevoEmpleado);

                    // Mostrar mensaje de éxito
                    MessageBox.Show("Empleado agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar todos los campos después de agregar
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    // Mostrar mensaje de error si se lanza alguna excepción
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
