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
        private UbicacionDAL controlador = new UbicacionDAL();
        private Empleado empleadoActual;

        public EditarEmpleado(Empleado empleado)
        {
            InitializeComponent();
            empleadoActual = empleado;

            // Evento Load para inicializar los datos
            this.Load += new System.EventHandler(this.EditarEmpleado_Load);
        }


        private void EditarEmpleado_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar los datos de los ComboBox
                CargarComboBox();
                CargarPaises();
                // Cargar datos del empleado seleccionado
                CargarDatosEmpleado(empleadoActual.CUIL);

                this.CBPaisEditarEmpleado.SelectedIndexChanged += new System.EventHandler(this.CBPaisEditarEmpleado_SelectedIndexChanged);
                this.CBProvinciaEditarEmpleado.SelectedIndexChanged += new System.EventHandler(this.CBProvinciaEditarEmpleado_SelectedIndexChanged);


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarEmpleado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BEditarEmpleado_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void CargarComboBox()
        {      
            try
            {
                // Cargar perfiles
                PerfilEmpleadoDAL perfilDAL = new PerfilEmpleadoDAL();
                CBPerfilEditarEmpleado.DataSource = perfilDAL.ObtenerPerfiles();
                CBPerfilEditarEmpleado.DisplayMember = "NombrePerfil";
                CBPerfilEditarEmpleado.ValueMember = "IdPerfil";

                // Cargar estados
                EstadoEmpleadoDAL estadoDAL = new EstadoEmpleadoDAL();
                CBEstadoEditarEmpleado.DataSource = estadoDAL.ObtenerEstadoEmpleado();
                CBEstadoEditarEmpleado.DisplayMember = "NombreEstadoEmpleado";
                CBEstadoEditarEmpleado.ValueMember = "IdEstadoEmpleado";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de los ComboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPaises()
        {
            List<Pais> paises = controlador.ObtenerPaises();
            CBPaisEditarEmpleado.DisplayMember = "NombrePais";
            CBPaisEditarEmpleado.ValueMember = "IdPais";
            CBPaisEditarEmpleado.DataSource = paises;
        }

        private void CBPaisEditarEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPaisEditarEmpleado.SelectedValue != null)
            {
                int idPais = (int)CBPaisEditarEmpleado.SelectedValue;
                CargarProvincias(idPais);
            }
        }

        private void CargarProvincias(int idPais)
        {
            List<Provincia> provincias = controlador.ObtenerProvinciasPorPais(idPais);
            CBProvinciaEditarEmpleado.DisplayMember = "NombreProvincia";
            CBProvinciaEditarEmpleado.ValueMember = "IdProvincia";
            CBProvinciaEditarEmpleado.DataSource = provincias;
        }

        private void CBProvinciaEditarEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que el valor seleccionado sea un int
            if (CBProvinciaEditarEmpleado.SelectedValue != null)
            {
                int idProvincia = (int)CBProvinciaEditarEmpleado.SelectedValue;
                CargarLocalidades(idProvincia);
            }
        }

        private void CargarLocalidades(int idProvincia)
        {
            List<Localidad> localidades = controlador.ObtenerLocalidadesPorProvincia(idProvincia);
            CBLocalidadEditarEmpleado.DisplayMember = "NombreLocalidad";
            CBLocalidadEditarEmpleado.ValueMember = "IdLocalidad";
            CBLocalidadEditarEmpleado.DataSource = localidades;
        }

        private void CargarDatosEmpleado(string cuil)
        {
            try
            {
                // Obtener los datos del empleado
                EmpleadoDAL empleadoDAL = new EmpleadoDAL();
                Empleado empleado = empleadoDAL.ObtenerEmpleadoPorCUIL(cuil);

                if (empleado != null)
                {
                    // Cargar datos en los TextBox
                    TBNombreEditarEmpleado.Text = empleado.Nombre;
                    TBApellidoEditarEmpleado.Text = empleado.Apellido;
                    TBDniEditarEmpleado.Text = empleado.DNI;
                    TBCuilEditarEmpleado.Text = empleado.CUIL;
                    TBEmailEditarEmpleado.Text = empleado.Email;
                    TBCelularEditarEmpleado.Text = empleado.Celular;
                    DTPFechaNacimiento.Value = empleado.FechaNacimiento;

                    TBCalleEditarEmpleado.Text = empleado.Calle;
                    TBNumCalleEditarEmpleado.Text = empleado.NumeroCalle.ToString();
                    TBNumPisoEditarEmpleado.Text = empleado.Piso?.ToString() ?? "";
                    TBDptoEditarEmpleado.Text = empleado.Dpto ?? "";
                    TBCodPostalEditarEmpleado.Text = empleado.CodigoPostal.ToString();

                    // Cargar y seleccionar los valores de Localidad, Provincia y País
                    SeleccionarUbicacionEmpleado(empleado.IdLocalidad);

                    // Seleccionar valores en los ComboBox de Perfil y Estado
                    CBPerfilEditarEmpleado.SelectedValue = empleado.IdPerfil;
                    CBEstadoEditarEmpleado.SelectedValue = empleado.IdEstado;
                }
                else
                {
                    MessageBox.Show("Empleado no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarUbicacionEmpleado(int idLocalidad)
        {
            try
            {
                // Obtener la localidad, provincia y país asociados al empleado
                UbicacionDAL ubicacionDAL = new UbicacionDAL();
                LocalidadDAL localidadDAL = new LocalidadDAL();
                Localidad localidad = localidadDAL.ObtenerLocalidadPorId(idLocalidad);

                if (localidad != null)
                {
                    ProvinciaDAL provinciaDAL = new ProvinciaDAL();
                    PaisDAL paisDAL = new PaisDAL();
                    Provincia provincia = provinciaDAL.ObtenerProvinciaPorId(localidad.IdProvincia);
                    Pais pais = paisDAL.ObtenerPaisPorId(provincia.IdPais);

                    // Cargar países y seleccionar el correspondiente
                    List<Pais> paises = ubicacionDAL.ObtenerPaises();
                    CBPaisEditarEmpleado.DisplayMember = "NombrePais";
                    CBPaisEditarEmpleado.ValueMember = "IdPais";
                    CBPaisEditarEmpleado.DataSource = paises;
                    CBPaisEditarEmpleado.SelectedValue = pais.IdPais;

                    // Cargar provincias y seleccionar la correspondiente
                    List<Provincia> provincias = ubicacionDAL.ObtenerProvinciasPorPais(pais.IdPais);
                    CBProvinciaEditarEmpleado.DisplayMember = "NombreProvincia";
                    CBProvinciaEditarEmpleado.ValueMember = "IdProvincia";
                    CBProvinciaEditarEmpleado.DataSource = provincias;
                    CBProvinciaEditarEmpleado.SelectedValue = provincia.IdProvincia;

                    // Cargar localidades y seleccionar la correspondiente
                    List<Localidad> localidades = ubicacionDAL.ObtenerLocalidadesPorProvincia(provincia.IdProvincia);
                    CBLocalidadEditarEmpleado.DisplayMember = "NombreLocalidad";
                    CBLocalidadEditarEmpleado.ValueMember = "IdLocalidad";
                    CBLocalidadEditarEmpleado.DataSource = localidades;
                    CBLocalidadEditarEmpleado.SelectedValue = localidad.IdLocalidad;
                }
                else
                {
                    MessageBox.Show("No se encontró la localidad asociada al empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la ubicación del empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEditarEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                // Actualizar los datos del empleado
                empleadoActual.CUIL = TBCuilEditarEmpleado.Text;
                empleadoActual.DNI = TBDniEditarEmpleado.Text;
                empleadoActual.Nombre = ToTitleCase(TBNombreEditarEmpleado.Text);
                empleadoActual.Apellido = ToTitleCase(TBApellidoEditarEmpleado.Text);
                empleadoActual.Email = TBEmailEditarEmpleado.Text;
                empleadoActual.Celular = TBCelularEditarEmpleado.Text;
                empleadoActual.FechaNacimiento = DTPFechaNacimiento.Value;

                empleadoActual.Calle = ToTitleCase(TBCalleEditarEmpleado.Text);
                empleadoActual.NumeroCalle = int.Parse(TBNumCalleEditarEmpleado.Text);
                empleadoActual.Piso = int.Parse(TBNumPisoEditarEmpleado.Text);
                empleadoActual.Dpto = TBDptoEditarEmpleado.Text;
                empleadoActual.CodigoPostal = int.Parse(TBCodPostalEditarEmpleado.Text);

                empleadoActual.IdLocalidad = (int)CBLocalidadEditarEmpleado.SelectedValue;
                empleadoActual.IdPerfil = (int)CBPerfilEditarEmpleado.SelectedValue;
                empleadoActual.IdEstado = (int)CBEstadoEditarEmpleado.SelectedValue;

                // Llamar al método para guardar los cambios en la base de datos
                EmpleadoDAL empleadoDAL = new EmpleadoDAL();
                bool actualizado = empleadoDAL.ActualizarEmpleado(empleadoActual);

                if (actualizado)
                {
                    MessageBox.Show("Empleado actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBNombreEditarEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoEditarEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBDniEditarEmpleado.Text) ||
                string.IsNullOrWhiteSpace(TBCuilEditarEmpleado.Text))
            {
                MessageBox.Show("Los campos Nombre, Apellido, DNI y CUIL son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(TBEmailEditarEmpleado.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TBDniEditarEmpleado.Text.Length != 8 || !long.TryParse(TBDniEditarEmpleado.Text, out _))
            {
                MessageBox.Show("El DNI debe tener 8 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TBCuilEditarEmpleado.Text.Length != 11 || !long.TryParse(TBCuilEditarEmpleado.Text, out _))
            {
                MessageBox.Show("El CUIL debe tener 11 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBCalleEditarEmpleado.Text) ||
                !int.TryParse(TBNumCalleEditarEmpleado.Text, out _) ||
                !int.TryParse(TBCodPostalEditarEmpleado.Text, out _))
            {
                MessageBox.Show("Verifique que los campos de dirección sean válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
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
