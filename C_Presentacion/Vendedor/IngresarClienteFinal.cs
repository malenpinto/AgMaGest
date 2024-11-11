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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using AgMaGest.C_Logica.Entidades;  // Importa la clase
using AgMaGest.C_Datos;  // Importa la capa de datos

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class IngresarClienteFinal : Form
    {
        public IngresarClienteFinal()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.Load += IngresarClienteFinal_Load; // Suscribirse al evento Load
            CBEstadoCFinal.DataSource = null;// Asegurar de que esté vacío al principio
        }

        private void IngresarClienteFinal_Load(object sender, EventArgs e)
        {
            CargarPaises(); // Asegura de cargar los países
            CargarEstados(); // Cargar Estados
        }

        private void CargarPaises()
        {
            // Obtener la lista de paises desde la base de datos
            PaisDAL paisDAL = new PaisDAL();
            List<Pais> paises = paisDAL.ObtenerPaises();

            // Agregar una opción por defecto "Seleccione un País"
            paises.Insert(0, new Pais { IdPais = 0, NombrePais = "Seleccione un País" });

            // Asignar la lista de países al ComboBox
            CBPaisCFinal.DataSource = paises;
            CBPaisCFinal.DisplayMember = "NombrePais";
            CBPaisCFinal.ValueMember = "IdPais";

            // Seleccionar la opción por defecto
            CBPaisCFinal.SelectedIndex = 0;

            // Desvincular el evento antes de volver a asignarlo
            CBPaisCFinal.SelectedIndexChanged -= CBPaisCFinal_SelectedIndexChanged;
            CBPaisCFinal.SelectedIndexChanged += CBPaisCFinal_SelectedIndexChanged;
        }

        private void CBPaisCFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPaisCFinal.SelectedValue != null)
            {
                int idPaisSeleccionado = (int)CBPaisCFinal.SelectedValue;

                if (idPaisSeleccionado != 0)
                {
                    // Lógica cuando hay un valor seleccionado
                    CargarProvincias(idPaisSeleccionado);
                }
                else
                {
                    // Limpiar las provincias si se selecciona "Seleccione un País"
                    CBProvinciaCFinal.DataSource = null;
                    CBProvinciaCFinal.Items.Clear();
                    CBProvinciaCFinal.Items.Add("Seleccione una Provincia");
                    CBProvinciaCFinal.SelectedIndex = 0;
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
            CBProvinciaCFinal.DataSource = provincias;
            CBProvinciaCFinal.DisplayMember = "NombreProvincia";
            CBProvinciaCFinal.ValueMember = "IdProvincia";

            // Seleccionar la opción por defecto
            CBProvinciaCFinal.SelectedIndex = 0;

            // Desvincular el evento antes de volver a asignarlo
            CBProvinciaCFinal.SelectedIndexChanged -= CBProvinciaCFinal_SelectedIndexChanged;
            CBProvinciaCFinal.SelectedIndexChanged += CBProvinciaCFinal_SelectedIndexChanged;
        }

        private void CBProvinciaCFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProvinciaCFinal.SelectedValue != null)
            {
                int idProvinciaSeleccionada = (int)CBProvinciaCFinal.SelectedValue;

                if (idProvinciaSeleccionada != 0)
                {
                    // Lógica cuando hay un valor seleccionado
                    CargarLocalidades(idProvinciaSeleccionada);
                }
                else
                {
                    // Limpiar las localidades si se selecciona "Seleccione una Provincia"
                    CBLocalidadCFinal.DataSource = null;
                    CBLocalidadCFinal.Items.Clear();
                    CBLocalidadCFinal.Items.Add("Seleccione una Localidad");
                    CBLocalidadCFinal.SelectedIndex = 0;
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
            CBLocalidadCFinal.DataSource = localidades; // Asignar la lista de localidades al ComboBox
            CBLocalidadCFinal.DisplayMember = "NombreLocalidad"; // Campo que se mostrará en el ComboBox
            CBLocalidadCFinal.ValueMember = "IdLocalidad"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBLocalidadCFinal.SelectedIndex = 0;
        }

        private void CargarEstados()
        {
            // Obtener la lista de estados de cliente desde la base de datos
            EstadoClienteDAL estadoClienteDAL = new EstadoClienteDAL();
            List<EstadoCliente> estados = estadoClienteDAL.ObtenerEstadosCliente();

            // Agregar una opción por defecto "Seleccione un estado"
            estados.Insert(0, new EstadoCliente { IdEstadoCliente = 0, NombreEstadoCliente = "Seleccione un estado" });


            // Asignar la lista al ComboBox
            CBEstadoCFinal.DataSource = estados; // Asignar la lista de perfiles al ComboBox
            CBEstadoCFinal.DisplayMember = "NombreEstadoCliente"; // Campo que se mostrará en el ComboBox
            CBEstadoCFinal.ValueMember = "IdEstadoCliente"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBEstadoCFinal.SelectedIndex = 0;
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
            // Verificar que no haya campos vacíos
            if (CBEstadoCFinal.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar un estado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBPaisCFinal.SelectedValue == null || CBPaisCFinal.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar un país.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBProvinciaCFinal.SelectedValue == null || CBProvinciaCFinal.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar una provincia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (CBLocalidadCFinal.SelectedValue == null || CBLocalidadCFinal.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Debe seleccionar una localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(TBNombreCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBDniCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCuilCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCelularCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBEmailCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCalleCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBNumCalleCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCodPostalCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBPaisCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBProvinciaCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBLocalidadCFinal.Text) ||
                string.IsNullOrWhiteSpace(CBEstadoCFinal.Text) ||
                CBPaisCFinal.SelectedIndex == -1 ||
                CBProvinciaCFinal.SelectedIndex == -1 ||
                CBLocalidadCFinal.SelectedIndex == -1 ||
                CBEstadoCFinal.SelectedIndex == -1)
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar si el email y los documentos son válidos
            if (!VerificarEmail() || !VerificarDNIyCUIL())
            {
                return; // Si no son válidos, salimos de la función
            }

            // Crear un objeto ClienteFinal con los datos del formulario
            ClienteFinal nuevoClienteFinal = new ClienteFinal()
            {
                CuilCFinal = TBCuilCFinal.Text.Trim(),
                DniCFinal = TBDniCFinal.Text.Trim(),
                NombreCFinal = ToTitleCase(TBNombreCFinal.Text.Trim()),
                ApellidoCFinal = ToTitleCase(TBApellidoCFinal.Text.Trim()),
                EmailCliente = TBEmailCFinal.Text.Trim(),
                CelularCliente = TBCelularCFinal.Text.Trim(),
                FechaNacCFinal = DTFechaNacAgregarCFinal.Value,
                CalleCliente = ToTitleCase(TBCalleCFinal.Text.Trim()),
                NumCalle = int.Parse(TBNumCalleCFinal.Text.Trim()),
                PisoCliente = string.IsNullOrWhiteSpace(TBPisoCFinal.Text) ? (int?)0 : int.Parse(TBPisoCFinal.Text.Trim()),
                DptoCliente = string.IsNullOrWhiteSpace(TBDptoCFinal.Text) ? "" : TBDptoCFinal.Text.Trim(),
                CodigoPostalCliente = int.Parse(TBCodPostalCFinal.Text.Trim()),
                IdEstadoCliente = Convert.ToInt32(CBEstadoCFinal.SelectedValue),
                IdLocalidad = Convert.ToInt32(CBLocalidadCFinal.SelectedValue),
            };

            // Insertar el ClienteFinal en la base de datos
            ClienteFinalDAL clienteDAL = new ClienteFinalDAL();
            clienteDAL.InsertarClienteFinal(nuevoClienteFinal);

            // Mostrar mensaje de éxito
            MessageBox.Show("Cliente Final agregado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiar los campos
            LimpiarCampos();
        }

    // Función para convertir la primera letra de cada palabra a mayúscula
    private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        // Función para limpiar todos los campos del formulario
        private void LimpiarCampos()
        {
            TBNombreCFinal.Text = "";
            TBApellidoCFinal.Text = "";
            TBDniCFinal.Text = "";
            TBCuilCFinal.Text = "";
            DTFechaNacAgregarCFinal.Value = DateTime.Now;
            TBCelularCFinal.Text = "";
            TBEmailCFinal.Text = "";
            TBCalleCFinal.Text = "";
            TBNumCalleCFinal.Text = "";
            TBPisoCFinal.Text = "";
            TBDptoCFinal.Text = "";
            TBCodPostalCFinal.Text = "";
            CBPaisCFinal.SelectedIndex = -1; 
            CBProvinciaCFinal.SelectedIndex = -1;
            
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
