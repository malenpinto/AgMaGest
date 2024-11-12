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

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class EditarClienteEmpresa : Form
    {
        private UbicacionDAL controlador = new UbicacionDAL();
        private ClienteEmpresa clienteActual;

        public EditarClienteEmpresa(ClienteEmpresa cliente)
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.clienteActual = cliente;
            // Evento Load para inicializar los datos
            this.Load += new System.EventHandler(this.EditarClienteEmpresa_Load);
        }

        private void EditarClienteEmpresa_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar los datos de los ComboBox
                CargarComboBox();
                CargarPaises();
                // Cargar datos del cliente seleccionado
                CargarDatosCliente(clienteActual.CuitCEmpresa);

                this.CBPaisEditarEmpresa.SelectedIndexChanged += new System.EventHandler(this.CBPaisEditarEmpresa_SelectedIndexChanged);
                this.CBProvinciaEditarEmpresa.SelectedIndexChanged += new System.EventHandler(this.CBProvinciaEditarEmpresa_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditarClienteEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BEditarCEmpresa_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void CargarComboBox()
        {
            try
            {
                // Cargar estados
                EstadoClienteDAL estadoDAL = new EstadoClienteDAL();
                CBEditarEstadoEmpresa.DataSource = estadoDAL.ObtenerEstadosCliente();
                CBEditarEstadoEmpresa.DisplayMember = "NombreEstadoCliente";
                CBEditarEstadoEmpresa.ValueMember = "IdEstadoCliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de los ComboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPaises()
        {
            List<Pais> paises = controlador.ObtenerPaises();
            CBPaisEditarEmpresa.DisplayMember = "NombrePais";
            CBPaisEditarEmpresa.ValueMember = "IdPais";
            CBPaisEditarEmpresa.DataSource = paises;
        }

        private void CBPaisEditarEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPaisEditarEmpresa.SelectedValue != null)
            {
                int idPais = (int)CBPaisEditarEmpresa.SelectedValue;
                CargarProvincias(idPais);
            }
        }

        private void CargarProvincias(int idPais)
        {
            List<Provincia> provincias = controlador.ObtenerProvinciasPorPais(idPais);
            CBProvinciaEditarEmpresa.DisplayMember = "NombreProvincia";
            CBProvinciaEditarEmpresa.ValueMember = "IdProvincia";
            CBProvinciaEditarEmpresa.DataSource = provincias;
        }

        private void CBProvinciaEditarEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProvinciaEditarEmpresa.SelectedValue != null)
            {
                int idProvincia = (int)CBProvinciaEditarEmpresa.SelectedValue;
                CargarLocalidades(idProvincia);
            }
        }

        private void CargarLocalidades(int idProvincia)
        {
            List<Localidad> localidades = controlador.ObtenerLocalidadesPorProvincia(idProvincia);
            CBLocalidadEditarEmpresa.DisplayMember = "NombreLocalidad";
            CBLocalidadEditarEmpresa.ValueMember = "IdLocalidad";
            CBLocalidadEditarEmpresa.DataSource = localidades;
        }

        private void CargarDatosCliente(string cuit)
        {
            try
            {
                // Obtener los datos del cliente
                ClienteEmpresaDAL clienteDAL = new ClienteEmpresaDAL();
                ClienteEmpresa cliente = clienteDAL.ObtenerClienteEmpresaPorCUIT(cuit);

                if (cliente != null)
                {
                    // Cargar datos en los TextBox
                    TBRazonSocialEditar.Text = cliente.RazonSocialCEmpresa;
                    TBCuitEditarEmpresa.Text = cliente.CuitCEmpresa;
                    TBTelefonoEditarEmpresa.Text = cliente.CelularCliente;
                    TBEmailEditarEmpresa.Text = cliente.EmailCliente;

                    TBCalleEditarEmpresa.Text = cliente.CalleCliente;
                    TBNumCalleEditarEmpresa.Text = cliente.NumCalle.ToString();
                    TBNumPisoEditarEmpresa.Text = (cliente.PisoCliente ?? 0).ToString();
                    TBDptoEditarEmpresa.Text = cliente.DptoCliente ?? "";
                    TBCodPostalEditarEmpresa.Text = cliente.CodigoPostalCliente.ToString();

                    // Cargar y seleccionar los valores de Localidad, Provincia y País
                    SeleccionarUbicacionCliente(cliente.IdLocalidad);

                    // Seleccionar valores en el ComboBox de Estado
                    CBEditarEstadoEmpresa.SelectedValue = cliente.IdEstadoCliente;
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarUbicacionCliente(int idLocalidad)
        {
            try
            {
                // Obtener la localidad, provincia y país asociados al cliente
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
                    CBPaisEditarEmpresa.DisplayMember = "NombrePais";
                    CBPaisEditarEmpresa.ValueMember = "IdPais";
                    CBPaisEditarEmpresa.DataSource = paises;
                    CBPaisEditarEmpresa.SelectedValue = pais.IdPais;

                    // Cargar provincias y seleccionar la correspondiente
                    List<Provincia> provincias = ubicacionDAL.ObtenerProvinciasPorPais(pais.IdPais);
                    CBProvinciaEditarEmpresa.DisplayMember = "NombreProvincia";
                    CBProvinciaEditarEmpresa.ValueMember = "IdProvincia";
                    CBProvinciaEditarEmpresa.DataSource = provincias;
                    CBProvinciaEditarEmpresa.SelectedValue = provincia.IdProvincia;

                    // Cargar localidades y seleccionar la correspondiente
                    List<Localidad> localidades = ubicacionDAL.ObtenerLocalidadesPorProvincia(provincia.IdProvincia);
                    CBLocalidadEditarEmpresa.DisplayMember = "NombreLocalidad";
                    CBLocalidadEditarEmpresa.ValueMember = "IdLocalidad";
                    CBLocalidadEditarEmpresa.DataSource = localidades;
                    CBLocalidadEditarEmpresa.SelectedValue = localidad.IdLocalidad;
                }
                else
                {
                    MessageBox.Show("No se encontró la localidad asociada al cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la ubicación del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BEditarCEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                // Actualizar los datos del cliente
                clienteActual.CuitCEmpresa= TBCuitEditarEmpresa.Text;
                clienteActual.RazonSocialCEmpresa = TBRazonSocialEditar.Text;
                clienteActual.CelularCliente = TBTelefonoEditarEmpresa.Text;
                clienteActual.EmailCliente = TBEmailEditarEmpresa.Text;

                clienteActual.CalleCliente = TBCalleEditarEmpresa.Text;
                clienteActual.NumCalle = int.Parse(TBNumCalleEditarEmpresa.Text);
                clienteActual.PisoCliente = int.Parse(TBNumPisoEditarEmpresa.Text);
                clienteActual.DptoCliente = TBDptoEditarEmpresa.Text;
                clienteActual.CodigoPostalCliente = int.Parse(TBCodPostalEditarEmpresa.Text);

                clienteActual.IdLocalidad = (int)CBLocalidadEditarEmpresa.SelectedValue;
                clienteActual.IdEstadoCliente = (int)CBEditarEstadoEmpresa.SelectedValue;

                // Llamar al método para guardar los cambios en la base de datos
                ClienteEmpresaDAL clienteDAL = new ClienteEmpresaDAL();
                bool actualizado = clienteDAL.ActualizarClienteEmpresa(clienteActual);

                if (actualizado)
                {
                    MessageBox.Show("Cliente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los cambios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(TBRazonSocialEditar.Text) ||
                string.IsNullOrWhiteSpace(TBCuitEditarEmpresa.Text))
            {
                MessageBox.Show("Los campos Razon Social y CUIT son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(TBEmailEditarEmpresa.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TBCuitEditarEmpresa.Text.Length != 11 || !long.TryParse(TBCuitEditarEmpresa.Text, out _))
            {
                MessageBox.Show("El CUIT debe tener 11 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBCalleEditarEmpresa.Text) ||
                !int.TryParse(TBNumCalleEditarEmpresa.Text, out _) ||
                !int.TryParse(TBCodPostalEditarEmpresa.Text, out _))
            {
                MessageBox.Show("Verifique que los campos de dirección sean válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Función para convertir la primera letra de cada palabra a mayúscula
        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        // Validar formato de correo electrónico
        private bool VerificarEmail()
        {
            string email = TBEmailEditarEmpresa.Text;
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
            if (TBCuitEditarEmpresa.Text.Length != 11)
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

        private void BSalirEditarCEmpresa_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
