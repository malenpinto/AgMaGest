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
            // Obtener la lista de paises desde la base de datos
            PaisDAL paisDAL = new PaisDAL();
            List<Pais> paises = paisDAL.ObtenerPaises();

            // Agregar una opción por defecto "Seleccione un País"
            paises.Insert(0, new Pais { IdPais = 0, NombrePais = "Seleccione un País" });

            // Asignar la lista de países al ComboBox
            CBPaisEmpleado.DataSource = paises;
            CBPaisEmpleado.DisplayMember = "NombrePais";
            CBPaisEmpleado.ValueMember = "IdPais";

            // Seleccionar la opción por defecto
            CBPaisEmpleado.SelectedIndex = 0;

            // Desvincular el evento antes de volver a asignarlo
            CBPaisEmpleado.SelectedIndexChanged -= CBPaisEmpleado_SelectedIndexChanged;
            CBPaisEmpleado.SelectedIndexChanged += CBPaisEmpleado_SelectedIndexChanged;
        }

        private void CBPaisEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPaisEmpleado.SelectedValue != null)
            {
                int idPaisSeleccionado = (int)CBPaisEmpleado.SelectedValue;

                if (idPaisSeleccionado != 0)
                {
                    // Lógica cuando hay un valor seleccionado
                    CargarProvincias(idPaisSeleccionado);
                }
                else
                {
                    // Limpiar las provincias si se selecciona "Seleccione un País"
                    CBProvinciaEmpleado.DataSource = null;
                    CBProvinciaEmpleado.Items.Clear();
                    CBProvinciaEmpleado.Items.Add("Seleccione una Provincia");
                    CBProvinciaEmpleado.SelectedIndex = 0;
                }
            }
        }

        private void CargarProvincias(int idPais)
        {
            // Obtener la lista de provincias desde la base de datos
            ProvinciaDAL provinciaDAL = new ProvinciaDAL();
            List<Provincia> provincias = provinciaDAL.ObtenerProvinciasPorPais(idPais);

            // Agregar una opción por defecto "Seleccione una Provincia"
            provincias.Insert(0, new Provincia { IdProvincia = 0, NombreProvincia = "Seleccione una Provincia" });

            // Asignar la lista de provincias al ComboBox
            CBProvinciaEmpleado.DataSource = provincias;
            CBProvinciaEmpleado.DisplayMember = "NombreProvincia";
            CBProvinciaEmpleado.ValueMember = "IdProvincia";

            // Seleccionar la opción por defecto
            CBProvinciaEmpleado.SelectedIndex = 0;

            // Desvincular el evento antes de volver a asignarlo
            CBProvinciaEmpleado.SelectedIndexChanged -= CBProvinciaEmpleado_SelectedIndexChanged;
            CBProvinciaEmpleado.SelectedIndexChanged += CBProvinciaEmpleado_SelectedIndexChanged;
        }

        private void CBProvinciaEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProvinciaEmpleado.SelectedValue != null)
            {
                int idProvinciaSeleccionada = (int)CBProvinciaEmpleado.SelectedValue;

                if (idProvinciaSeleccionada != 0)
                {
                    // Lógica cuando hay un valor seleccionado
                    CargarLocalidades(idProvinciaSeleccionada);
                }
                else
                {
                    // Limpiar las localidades si se selecciona "Seleccione una Provincia"
                    CBLocalidadEmpleado.DataSource = null;
                    CBLocalidadEmpleado.Items.Clear();
                    CBLocalidadEmpleado.Items.Add("Seleccione una Localidad");
                    CBLocalidadEmpleado.SelectedIndex = 0;
                }
            }
        }

        private void CargarLocalidades(int idProvincia)
        {
            // Obtener la lista de localidades desde la base de datos
            LocalidadDAL localidadDAL = new LocalidadDAL();
            List<Localidad> localidades = localidadDAL.ObtenerLocalidadesPorProvincia(idProvincia);

            // Agregar una opción por defecto "Seleccione una Provincia"
            localidades.Insert(0, new Localidad { IdProvincia = 0, NombreLocalidad = "Seleccione una Localidad" });

            // Asignar la lista de localidades al ComboBox
            CBLocalidadEmpleado.DataSource = localidades; // Asignar la lista de localidades al ComboBox
            CBLocalidadEmpleado.DisplayMember = "NombreLocalidad"; // Campo que se mostrará en el ComboBox
            CBLocalidadEmpleado.ValueMember = "IdLocalidad"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBLocalidadEmpleado.SelectedIndex = 0;
        }

        private void CargarPerfiles()
        {
            // Obtener la lista de perfiles desde la base de datos
            EmpleadoDAL empleadoDAL = new EmpleadoDAL();
            List<PerfilEmpleado> perfiles = empleadoDAL.ObtenerPerfiles();
            
            // Agregar una opción por defecto "Seleccione una"
            perfiles.Insert(0, new PerfilEmpleado { IdPerfil = 0, NombrePerfil = "Seleccione un perfil" });

            // Asignar la lista al ComboBox
            CBPerfilEmpleado.DataSource = perfiles; // Asignar la lista de perfiles al ComboBox
            CBPerfilEmpleado.DisplayMember = "NombrePerfil"; // Campo que se mostrará en el ComboBox
            CBPerfilEmpleado.ValueMember = "IdPerfil"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBPerfilEmpleado.SelectedIndex = 0;
        }


        private void BAgregarEmpleado_Click(object sender, EventArgs e)
        {
            // Verificar formato de Email, DNI y CUIL
            if (!VerificarEmail() || !VerificarDNIyCUIL())
            {
                MessageBox.Show("Por favor, revise los formatos de Email, DNI o CUIL.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación de la fecha de nacimiento
            DateTime fechaMinimaSQL = new DateTime(1924, 1, 1);
            if (DTFechaNacEmpleado.Value < fechaMinimaSQL)
            {
                MessageBox.Show("La fecha de nacimiento no es válida. Debe ser posterior al 01/01/1924.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si se ha seleccionado un perfil
            if (CBPerfilEmpleado.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar un perfil.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si se ha seleccionado un país
            if (CBPaisEmpleado.SelectedValue == null || CBPaisEmpleado.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar un país.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si se ha seleccionado una provincia
            if (CBProvinciaEmpleado.SelectedValue == null || CBProvinciaEmpleado.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar una provincia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar si se ha seleccionado una localidad
            if (CBLocalidadEmpleado.SelectedValue == null || CBLocalidadEmpleado.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar una localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar que todos los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(TBNombreEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBDniEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCuilEmpleado.Text) ||
                CBPerfilEmpleado.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(TBCelularEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBEmailEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCalleEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBNumCalleEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCodPostalEmpleado.Text) ||
                CBPaisEmpleado.SelectedIndex == -1 ||
                CBProvinciaEmpleado.SelectedIndex == -1 ||
                CBLocalidadEmpleado.SelectedIndex == -1)
            {
                // Mostrar mensaje de error si falta algún campo
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Crear una instancia de EmpleadoDAL
                EmpleadoDAL empleadoDAL = new EmpleadoDAL();

                // Crear un objeto Empleado con los datos del formulario
                Empleado nuevoEmpleado = new Empleado()
                {
                    CUIL = TBCuilEmpleado.Text.Trim(),
                    DNI = TBDniEmpleado.Text.Trim(),
                    Nombre = ToTitleCase(TBNombreEmpleado.Text.Trim()), // Usar ToTitleCase
                    Apellido = ToTitleCase(TBApellidoEmpleado.Text.Trim()), // Usar ToTitleCase
                    Email = TBEmailEmpleado.Text.Trim(),
                    Celular = TBCelularEmpleado.Text.Trim(),
                    FechaNacimiento = DTFechaNacEmpleado.Value,
                    Calle = ToTitleCase(TBCalleEmpleado.Text.Trim()), // Usar ToTitleCase
                    NumeroCalle = int.Parse(TBNumCalleEmpleado.Text.Trim()), // Convertir a int
                    Piso = string.IsNullOrWhiteSpace(TBNumPisoEmpleado.Text) ? (int?)null : int.Parse(TBNumPisoEmpleado.Text.Trim()),
                    Dpto = string.IsNullOrWhiteSpace(TBDptoEmpleado.Text) ? null : TBDptoEmpleado.Text.Trim(),
                    CodigoPostal = int.Parse(TBCodPostalEmpleado.Text.Trim()), // Convertir a int
                    IdPerfil = Convert.ToInt32(CBPerfilEmpleado.SelectedValue), // Asumiendo que tenemos una lista de perfiles
                    IdEstado = 1, // 1 estado activo
                    IdLocalidad = Convert.ToInt32(CBLocalidadEmpleado.SelectedValue) // Asignar ID de la localidad
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
                MessageBox.Show($"Ocurrió un error al agregar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.ToString()); // Imprimir el error detallado en la consola
            }
        }

        // Función para limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            // Limpiar campos de texto
            LimpiarTextBoxes(this);

            // Restablecer ComboBox de perfil
            CBPerfilEmpleado.SelectedIndex = 0;

            // Restablecer Fecha de Nacimiento a la fecha actual
            DTFechaNacEmpleado.Value = DateTime.Now;

            // Restablecer País, Provincia y Localidad
            RestablecerComboBox(CBPaisEmpleado, "Seleccione un País");
            RestablecerComboBox(CBProvinciaEmpleado, "Seleccione una Provincia");
            RestablecerComboBox(CBLocalidadEmpleado, "Seleccione una Localidad");
        }

        // Función para limpiar todos los TextBox dentro de un contenedor (puede ser el formulario u otro panel)
        private void LimpiarTextBoxes(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control.HasChildren)
                {
                    LimpiarTextBoxes(control); // Llamada recursiva para limpiar TextBox en contenedores anidados
                }
            }
        }

        // Función para restablecer un ComboBox con un mensaje predeterminado
        private void RestablecerComboBox(ComboBox comboBox, string mensajeDefault)
        {
            comboBox.DataSource = null; // Limpiar el ComboBox
            comboBox.Items.Clear();
            comboBox.Items.Add(mensajeDefault);
            comboBox.SelectedIndex = 0;
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
            if (TBDniEmpleado.Text.Length != 8 || !TBDniEmpleado.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe tener 8 dígitos y solo contener números.");
                return false;
            }

            if (TBCuilEmpleado.Text.Length != 11 || !TBCuilEmpleado.Text.All(char.IsDigit))
            {
                MessageBox.Show("El CUIL debe tener 11 dígitos y solo contener números.");
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

        //Funcion para poner mayusculas las primeras letras
        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        private void BSalirEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
