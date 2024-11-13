using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgMaGest.C_Presentacion.Vendedor;
using AgMaGest.C_Presentacion.Administrador;


namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class VisualizarClientes : Form
    {
        public VisualizarClientes()
        {
            InitializeComponent();
            this.Load += new EventHandler(VisualizarClientes_Load);
            dataGridClientes.CellFormatting += DataGridClientes_CellFormatting;

            panel4.Click += new EventHandler(Panel4_Click);
            panel4.Leave += new EventHandler(Panel4_Leave);
        }

        private void VisualizarClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            // Configurar el DataGridView y establecer AutoGenerateColumns a false
            ConfigurarDataGridView();
            dataGridClientes.AutoGenerateColumns = false;

            // Obtener los clientes desde la base de datos
            ClienteDAL clienteDAL = new ClienteDAL();
            List<Cliente> clientes = clienteDAL.ObtenerClientes();

            if (clientes != null && clientes.Count > 0)
            {
                dataGridClientes.DataSource = clientes;

                // Verificar y ocultar columnas innecesarias si existen
                if (dataGridClientes.Columns["Calle"] != null) dataGridClientes.Columns["Calle"].Visible = false;
                if (dataGridClientes.Columns["NumeroCalle"] != null) dataGridClientes.Columns["NumeroCalle"].Visible = false;
                if (dataGridClientes.Columns["Piso"] != null) dataGridClientes.Columns["Piso"].Visible = false;
                if (dataGridClientes.Columns["Dpto"] != null) dataGridClientes.Columns["Dpto"].Visible = false;
                if (dataGridClientes.Columns["IdLocalidad"] != null) dataGridClientes.Columns["IdLocalidad"].Visible = false;
                if (dataGridClientes.Columns["IdEstado"] != null) dataGridClientes.Columns["IdEstado"].Visible = false;
            }
            else
            {
                MessageBox.Show("No se encontraron clientes.");
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar cualquier configuración previa
            dataGridClientes.Columns.Clear();

            // Columnas comunes a ambos tipos de cliente
            dataGridClientes.Columns.Add("EstadoNombre", "Estado");
            dataGridClientes.Columns["EstadoNombre"].DataPropertyName = "EstadoNombre";

            dataGridClientes.Columns.Add("CuilCuit", "CUIL/CUIT");
            dataGridClientes.Columns["CuilCuit"].DataPropertyName = "CuilCuit";

            dataGridClientes.Columns.Add("NombreCompletoRazonSocial", "Nombre/Razón Social");
            dataGridClientes.Columns["NombreCompletoRazonSocial"].DataPropertyName = "NombreCompletoRazonSocial";

            dataGridClientes.Columns.Add("EmailCliente", "Email");
            dataGridClientes.Columns["EmailCliente"].DataPropertyName = "EmailCliente";

            dataGridClientes.Columns.Add("CelularCliente", "Celular");
            dataGridClientes.Columns["CelularCliente"].DataPropertyName = "CelularCliente";

            dataGridClientes.Columns.Add("DireccionCompleta", "Dirección");
            dataGridClientes.Columns["DireccionCompleta"].DataPropertyName = "DireccionCompleta";

            dataGridClientes.Columns.Add("CodigoPostalCliente", "Código Postal");
            dataGridClientes.Columns["CodigoPostalCliente"].DataPropertyName = "CodigoPostalCliente";

            dataGridClientes.Columns.Add("LocalidadNombre", "Localidad");
            dataGridClientes.Columns["LocalidadNombre"].DataPropertyName = "LocalidadNombre";

            dataGridClientes.Columns.Add("ProvinciaNombre", "Provincia");
            dataGridClientes.Columns["ProvinciaNombre"].DataPropertyName = "ProvinciaNombre";

            dataGridClientes.Columns.Add("PaisNombre", "País");
            dataGridClientes.Columns["PaisNombre"].DataPropertyName = "PaisNombre";
        }

        // Establece el orden de las columnas
        // dataGridClientes.Columns["DireccionCompleta"].DisplayIndex = 9;
        // dataGridClientes.Columns["CodigoPostal"].DisplayIndex = 10;
        // dataGridClientes.Columns["LocalidadNombre"].DisplayIndex = 11;
        // dataGridClientes.Columns["ProvinciaNombre"].DisplayIndex = 12;
        // dataGridClientes.Columns["PaisNombre"].DisplayIndex = 13;


        private void DataGridClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var cliente = dataGridClientes.Rows[e.RowIndex].DataBoundItem;

            // Verificar si estamos en la columna "CUIL/CUIT" 
            if (dataGridClientes.Columns[e.ColumnIndex].Name == "cuilCuit")
            {
                if (cliente is ClienteEmpresa clienteEmpresa)
                {
                    e.Value = clienteEmpresa.CuitCEmpresa;
                }
                else if (cliente is ClienteFinal clienteFinal)
                {
                    e.Value = clienteFinal.CuilCFinal;
                }
            }

            // Verificar si estamos en la columna "Nombre"
            else if (dataGridClientes.Columns[e.ColumnIndex].Name == "nombreCliente")
            {
                if (cliente is ClienteEmpresa clienteEmpresa)
                {
                    e.Value = clienteEmpresa.RazonSocialCEmpresa;
                }
                else if (cliente is ClienteFinal clienteFinal)
                {
                    e.Value = $"{clienteFinal.NombreCFinal} {clienteFinal.ApellidoCFinal}";
                }
            }


            // Verificar si estamos en la columna "EstadoCliente" (o el nombre que tenga en tu DataGrid)
            if (dataGridClientes.Columns[e.ColumnIndex].Name == "EstadoNombre")
            {
                // Obtener el valor de la celda de estado
                string estadoCliente = e.Value as string;

                if (estadoCliente == "Vendido")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (estadoCliente == "Contactado para cerrar")
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (estadoCliente == "Visita al salon")
                {
                    e.CellStyle.BackColor = Color.LightBlue;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (estadoCliente == "Cliente interesado")
                {
                    e.CellStyle.BackColor = Color.LightCoral;
                    e.CellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void FiltrarClientes(string texto)
        {
            ClienteDAL clienteDAL = new ClienteDAL();

            // Filtrar clientes con el texto de búsqueda
            List<Cliente> clientesFiltrados = clienteDAL.FiltrarClientes(texto);

            if (clientesFiltrados != null && clientesFiltrados.Count > 0)
            {
                // Si se encuentran resultados, asignarlos al DataGridView
                dataGridClientes.DataSource = clientesFiltrados;
            }
            else
            {
                // Si no hay resultados, mostrar mensaje y recargar todos los clientes
                MessageBox.Show("No se encontraron clientes con el criterio de búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar todos los clientes
                CargarClientes();
            }
        }

        private void DataGridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridClientes.SelectedRows.Count > 0)
            {
                BEditarCliente.Visible = true;
                BEliminarCliente.Visible = true;
            }
            else
            {
                // Opcionalmente, ocultar los botones si no hay selección
                BEditarCliente.Visible = false;
                BEliminarCliente.Visible = false;
            }
        }


        private void BAgregarCliente_Click_1(object sender, EventArgs e)
        {
            if (BAgregarEmpresa.Visible && BAgregarPersona.Visible)
            {
                BAgregarPersona.Visible = false;
                BAgregarEmpresa.Visible = false;
            }
            else
            {
                BAgregarPersona.Visible = true;
                BAgregarEmpresa.Visible = true;
            }
        }

        private void BAgregarPersona_Click(object sender, EventArgs e)
        {
            IngresarClienteFinal formPersona = new IngresarClienteFinal();
            formPersona.ShowDialog();
            BAgregarPersona.Visible = false;
            BAgregarEmpresa.Visible = false;
        }

        private void BAgregarEmpresa_Click(object sender, EventArgs e)
        {
            IngresarClienteEmpresa formEmpresa = new IngresarClienteEmpresa();
            formEmpresa.ShowDialog();
            BAgregarPersona.Visible = false;
            BAgregarEmpresa.Visible = false;
        }

        private void BBuscarEmpleado_Click(object sender, EventArgs e)
        {
            string textoBusqueda = TBBuscarCliente.Text.Trim();
                if (!string.IsNullOrEmpty(textoBusqueda))
                {
                    FiltrarClientes(textoBusqueda);
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un texto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
        }

        private void BEditarCliente_Click(object sender, EventArgs e)
        {
            // Verificar si hay un cliente seleccionado en el DataGridView
            if (dataGridClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un cliente para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el CUIL/CUIT del cliente seleccionado desde el DataGridView
            var selectedRow = dataGridClientes.SelectedRows[0];
            string cuilCuit = selectedRow.Cells["CuilCuit"].Value.ToString();

            // Determinar el tipo de cliente basado en el formato de CUIL/CUIT
            if (EsCuit(cuilCuit))
            {
                // Obtener los datos del cliente empresa (puedes adaptarlo si tienes más propiedades)
                ClienteEmpresa clienteEmpresa = (ClienteEmpresa)selectedRow.DataBoundItem;

                // Abrir formulario de edición para Cliente Empresa
                EditarClienteEmpresa formEditarEmpresa = new EditarClienteEmpresa(clienteEmpresa);
                formEditarEmpresa.ShowDialog();
            }
            else
            {
                // Obtener los datos del cliente final (puedes adaptarlo si tienes más propiedades)
                ClienteFinal clienteFinal = (ClienteFinal)selectedRow.DataBoundItem;

                // Abrir formulario de edición para Cliente Final
                EditarClienteFinal formEditarCFinal = new EditarClienteFinal(clienteFinal);
                formEditarCFinal.ShowDialog();
            }
        }

        // Método auxiliar para verificar si es CUIT (empresa) o CUIL (cliente final)
        private bool EsCuit(string cuilCuit)
        {
            // En Argentina, el CUIT tiene prefijos de 30, o 33 (por ejemplo, para personas jurídicas)
            // Mientras que el CUIL tiene prefijos típicos de 20, 27, 23 para personas físicas.
            // Ajustar la lógica según el criterio para diferenciar CUIT y CUIL
            // Un CUIT de empresa suele empezar con 30 o 33 y tiene longitud de 11 caracteres

            return cuilCuit.Length == 11 && (cuilCuit.StartsWith("30") || cuilCuit.StartsWith("33"));
        }

        private void Panel4_Click(object sender, EventArgs e)
        {
            // Ocultar todos los botones solo si están visibles
            OcultarBotones();
        }

        private void Panel4_Leave(object sender, EventArgs e)
        {
            // Ocultar todos los botones solo si están visibles cuando el panel pierde el foco
            OcultarBotones();
        }

        // Método para ocultar todos los botones
        private void OcultarBotones()
        {
            if (BAgregarPersona.Visible || BAgregarEmpresa.Visible || BEditarCliente.Visible || BEliminarCliente.Visible)
            {
                BAgregarPersona.Visible = false;
                BAgregarEmpresa.Visible = false;
                BEditarCliente.Visible = false;
                BEliminarCliente.Visible = false;
            }
        }
    }
}