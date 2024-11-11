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

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class IngresarClienteEmpresa : Form
    {
        public IngresarClienteEmpresa()
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.Load += IngresarClienteEmpresa_Load; // Suscribirse al evento Load
            CBEstadoEmpresa.DataSource = null;// Asegurar de que esté vacío al principio
        }

        private void IngresarClienteEmpresa_Load(object sender, EventArgs e)
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
            CBPaisEmpresa.DataSource = paises;
            CBPaisEmpresa.DisplayMember = "NombrePais";
            CBPaisEmpresa.ValueMember = "IdPais";

            // Seleccionar la opción por defecto
            CBPaisEmpresa.SelectedIndex = 0;

            // Desvincular el evento antes de volver a asignarlo
            CBPaisEmpresa.SelectedIndexChanged -= CBPaisEmpresa_SelectedIndexChanged;
            CBPaisEmpresa.SelectedIndexChanged += CBPaisEmpresa_SelectedIndexChanged;
        }

        private void CBPaisEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPaisEmpresa.SelectedValue != null)
            {
                int idPaisSeleccionado = (int)CBPaisEmpresa.SelectedValue;

                if (idPaisSeleccionado != 0)
                {
                    // Lógica cuando hay un valor seleccionado
                    CargarProvincias(idPaisSeleccionado);
                }
                else
                {
                    // Limpiar las provincias si se selecciona "Seleccione un País"
                    CBProvinciaEmpresa.DataSource = null;
                    CBProvinciaEmpresa.Items.Clear();
                    CBProvinciaEmpresa.Items.Add("Seleccione una Provincia");
                    CBProvinciaEmpresa.SelectedIndex = 0;
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
            CBProvinciaEmpresa.DataSource = provincias;
            CBProvinciaEmpresa.DisplayMember = "NombreProvincia";
            CBProvinciaEmpresa.ValueMember = "IdProvincia";

            // Seleccionar la opción por defecto
            CBProvinciaEmpresa.SelectedIndex = 0;

            // Desvincular el evento antes de volver a asignarlo
            CBProvinciaEmpresa.SelectedIndexChanged -= CBProvinciaEmpresa_SelectedIndexChanged;
            CBProvinciaEmpresa.SelectedIndexChanged += CBProvinciaEmpresa_SelectedIndexChanged;
        }

        private void CBProvinciaEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProvinciaEmpresa.SelectedValue != null)
            {
                int idProvinciaSeleccionada = (int)CBProvinciaEmpresa.SelectedValue;

                if (idProvinciaSeleccionada != 0)
                {
                    // Lógica cuando hay un valor seleccionado
                    CargarLocalidades(idProvinciaSeleccionada);
                }
                else
                {
                    // Limpiar las localidades si se selecciona "Seleccione una Provincia"
                    CBLocalidadEmpresa.DataSource = null;
                    CBLocalidadEmpresa.Items.Clear();
                    CBLocalidadEmpresa.Items.Add("Seleccione una Localidad");
                    CBLocalidadEmpresa.SelectedIndex = 0;
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
            CBLocalidadEmpresa.DataSource = localidades; // Asignar la lista de localidades al ComboBox
            CBLocalidadEmpresa.DisplayMember = "NombreLocalidad"; // Campo que se mostrará en el ComboBox
            CBLocalidadEmpresa.ValueMember = "IdLocalidad"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBLocalidadEmpresa.SelectedIndex = 0;
        }

        private void CargarEstados()
        {
            // Obtener la lista de estados de cliente desde la base de datos
            EstadoClienteDAL estadoClienteDAL = new EstadoClienteDAL();
            List<EstadoCliente> estados = estadoClienteDAL.ObtenerEstadosCliente();

            // Agregar una opción por defecto "Seleccione un estado"
            estados.Insert(0, new EstadoCliente { IdEstadoCliente = 0, NombreEstadoCliente = "Seleccione un estado" });


            // Asignar la lista al ComboBox
            CBEstadoEmpresa.DataSource = estados; // Asignar la lista de estados de clientes al ComboBox
            CBEstadoEmpresa.DisplayMember = "NombreEstadoCliente"; // Campo que se mostrará en el ComboBox
            CBEstadoEmpresa.ValueMember = "IdEstadoCliente"; // Campo que se utilizará como valor

            // Seleccionar la opción por defecto
            CBEstadoEmpresa.SelectedIndex = 0;
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
                string.IsNullOrWhiteSpace(CBLocalidadEmpresa.Text) ||
                string.IsNullOrWhiteSpace(CBEstadoEmpresa.Text))

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
