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
    public partial class EditarClienteFinal : Form
    {
        private UbicacionDAL controlador = new UbicacionDAL();
        private ClienteFinal clienteActual;
        public EditarClienteFinal(ClienteFinal cliente)
        {
            InitializeComponent();
            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
            this.clienteActual = cliente;
            // Evento Load para inicializar los datos
            this.Load += new System.EventHandler(this.EditarClienteFinal_Load);
        }

        private void EditarClienteFinal_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar los datos de los ComboBox
                CargarComboBox();
                CargarPaises();
                // Cargar datos del cliente seleccionado
                CargarDatosCliente(clienteActual.CuilCFinal);

                this.CBPaisEditarCFinal.SelectedIndexChanged += new System.EventHandler(this.CBPaisEditarCFinal_SelectedIndexChanged);
                this.CBProvinciaEditarCFinal.SelectedIndexChanged += new System.EventHandler(this.CBProvinciaEditarCFinal_SelectedIndexChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el formulario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void CargarComboBox()
        {
            try
            {
                // Cargar estados
                EstadoClienteDAL estadoDAL = new EstadoClienteDAL();
                CBEstadoEditarCFinal.DataSource = estadoDAL.ObtenerEstadosCliente();
                CBEstadoEditarCFinal.DisplayMember = "NombreEstadoCliente";
                CBEstadoEditarCFinal.ValueMember = "IdEstadoCliente";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de los ComboBox: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarPaises()
        {
            List<Pais> paises = controlador.ObtenerPaises();
            CBPaisEditarCFinal.DisplayMember = "NombrePais";
            CBPaisEditarCFinal.ValueMember = "IdPais";
            CBPaisEditarCFinal.DataSource = paises;
        }

        private void CBPaisEditarCFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBPaisEditarCFinal.SelectedValue != null)
            {
                int idPais = (int)CBPaisEditarCFinal.SelectedValue;
                CargarProvincias(idPais);
            }
        }

        private void CargarProvincias(int idPais)
        {
            List<Provincia> provincias = controlador.ObtenerProvinciasPorPais(idPais);
            CBProvinciaEditarCFinal.DisplayMember = "NombreProvincia";
            CBProvinciaEditarCFinal.ValueMember = "IdProvincia";
            CBProvinciaEditarCFinal.DataSource = provincias;
        }

        private void CBProvinciaEditarCFinal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBProvinciaEditarCFinal.SelectedValue != null)
            {
                int idProvincia = (int)CBProvinciaEditarCFinal.SelectedValue;
                CargarLocalidades(idProvincia);
            }
        }

        private void CargarLocalidades(int idProvincia)
        {
            List<Localidad> localidades = controlador.ObtenerLocalidadesPorProvincia(idProvincia);
            CBLocalidadEditarCFinal.DisplayMember = "NombreLocalidad";
            CBLocalidadEditarCFinal.ValueMember = "IdLocalidad";
            CBLocalidadEditarCFinal.DataSource = localidades;
        }

        private void CargarDatosCliente(string cuil)
        {
            try
            {
                // Obtener los datos del cliente
                ClienteFinalDAL clienteDAL = new ClienteFinalDAL();
                ClienteFinal cliente = clienteDAL.ObtenerClienteFinalPorCUIL(cuil);

                if (cliente != null)
                {
                    // Cargar datos en los TextBox
                    TBNombreEditarCFinal.Text = cliente.NombreCFinal;
                    TBApellidoEditarCFinal.Text = cliente.ApellidoCFinal;
                    TBDniEditarCFinal.Text = cliente.DniCFinal;
                    TBCuilEditarCFinal.Text = cliente.CuilCFinal;
                    DTPFechaNacEditarCFinal.Value = cliente.FechaNacCFinal;


                    TBCelularEditarCFinal.Text = cliente.CelularCliente;
                    TBEmailEditarCFinal.Text = cliente.EmailCliente;

                    TBCalleEditarCFinal.Text = cliente.CalleCliente;
                    TBNumCalleEditarCFinal.Text = cliente.NumCalle.ToString();
                    TBPisoEditarCFinal.Text = (cliente.PisoCliente ?? 0).ToString();
                    TBDptoEditarCFinal.Text = cliente.DptoCliente ?? "";
                    TBCodPostalEditarCFinal.Text = cliente.CodigoPostalCliente.ToString();

                    // Cargar y seleccionar los valores de Localidad, Provincia y País
                    SeleccionarUbicacionCliente(cliente.IdLocalidad);

                    // Seleccionar valores en el ComboBox de Estado
                    CBEstadoEditarCFinal.SelectedValue = cliente.IdEstadoCliente;
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
                    CBPaisEditarCFinal.DisplayMember = "NombrePais";
                    CBPaisEditarCFinal.ValueMember = "IdPais";
                    CBPaisEditarCFinal.DataSource = paises;
                    CBPaisEditarCFinal.SelectedValue = pais.IdPais;

                    // Cargar provincias y seleccionar la correspondiente
                    List<Provincia> provincias = ubicacionDAL.ObtenerProvinciasPorPais(pais.IdPais);
                    CBProvinciaEditarCFinal.DisplayMember = "NombreProvincia";
                    CBProvinciaEditarCFinal.ValueMember = "IdProvincia";
                    CBProvinciaEditarCFinal.DataSource = provincias;
                    CBProvinciaEditarCFinal.SelectedValue = provincia.IdProvincia;

                    // Cargar localidades y seleccionar la correspondiente
                    List<Localidad> localidades = ubicacionDAL.ObtenerLocalidadesPorProvincia(provincia.IdProvincia);
                    CBLocalidadEditarCFinal.DisplayMember = "NombreLocalidad";
                    CBLocalidadEditarCFinal.ValueMember = "IdLocalidad";
                    CBLocalidadEditarCFinal.DataSource = localidades;
                    CBLocalidadEditarCFinal.SelectedValue = localidad.IdLocalidad;
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

        private void BAgregarEditarCFinal_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos()) return;

                // Actualizar los datos del cliente
                clienteActual.NombreCFinal = TBNombreEditarCFinal.Text;
                clienteActual.ApellidoCFinal = TBApellidoEditarCFinal.Text;
                clienteActual.DniCFinal = TBDniEditarCFinal.Text;
                clienteActual.CuilCFinal = TBCuilEditarCFinal.Text;
                clienteActual.FechaNacCFinal = DTPFechaNacEditarCFinal.Value;

                clienteActual.CelularCliente = TBCelularEditarCFinal.Text;
                clienteActual.EmailCliente = TBEmailEditarCFinal.Text;

                clienteActual.CalleCliente = TBCalleEditarCFinal.Text;
                clienteActual.NumCalle = int.Parse(TBNumCalleEditarCFinal.Text);
                clienteActual.PisoCliente = int.Parse(TBNumCalleEditarCFinal.Text);
                clienteActual.DptoCliente = TBDptoEditarCFinal.Text;
                clienteActual.CodigoPostalCliente = int.Parse(TBCodPostalEditarCFinal.Text);

                clienteActual.IdLocalidad = (int)CBLocalidadEditarCFinal.SelectedValue;
                clienteActual.IdEstadoCliente = (int)CBEstadoEditarCFinal.SelectedValue;

                // Llamar al método para guardar los cambios en la base de datos
                ClienteFinalDAL clienteDAL = new ClienteFinalDAL();
                bool actualizado = clienteDAL.ActualizarClienteFinal(clienteActual);

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
            if (string.IsNullOrWhiteSpace(TBNombreEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBApellidoEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBDniEditarCFinal.Text) ||
                string.IsNullOrWhiteSpace(TBCuilEditarCFinal.Text))
            {
                MessageBox.Show("Los campos Nombre, Apellido, DNI y CUIL son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(TBEmailEditarCFinal.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (TBCuilEditarCFinal.Text.Length != 11 || !long.TryParse(TBCuilEditarCFinal.Text, out _))
            {
                MessageBox.Show("El CUIL debe tener 11 dígitos numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(TBCalleEditarCFinal.Text) ||
                !int.TryParse(TBNumCalleEditarCFinal.Text, out _) ||
                !int.TryParse(TBCodPostalEditarCFinal.Text, out _))
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
