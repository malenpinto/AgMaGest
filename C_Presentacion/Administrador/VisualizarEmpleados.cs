using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using AgMaGest.C_Presentacion.Vendedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class VisualizarEmpleados : Form
    {
        public VisualizarEmpleados()
        {
            InitializeComponent();
            this.Load += new EventHandler(VisualizarEmpleados_Load);
        }

        private void VisualizarEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void ConfigurarDataGridView()
        {
            // Limpiar cualquier configuración previa
            dataGridEmpleados.Columns.Clear();

            // Configurar las columnas manualmente
            dataGridEmpleados.Columns.Add("cuil_Empleado", "CUIL");
            dataGridEmpleados.Columns["cuil_Empleado"].DataPropertyName = "CUIL";

            dataGridEmpleados.Columns.Add("dni_Empleado", "DNI");
            dataGridEmpleados.Columns["dni_Empleado"].DataPropertyName = "DNI";

            dataGridEmpleados.Columns.Add("nombre_Empleado", "Nombre");
            dataGridEmpleados.Columns["nombre_Empleado"].DataPropertyName = "Nombre";

            dataGridEmpleados.Columns.Add("apellido_Empleado", "Apellido");
            dataGridEmpleados.Columns["apellido_Empleado"].DataPropertyName = "Apellido";

            dataGridEmpleados.Columns.Add("fechaNac_Empleado", "Fecha Nacimiento");
            dataGridEmpleados.Columns["fechaNac_Empleado"].DataPropertyName = "FechaNacimiento";

            dataGridEmpleados.Columns.Add("email_Empleado", "Email");
            dataGridEmpleados.Columns["email_Empleado"].DataPropertyName = "Email";

            dataGridEmpleados.Columns.Add("celular_Empleado", "Celular");
            dataGridEmpleados.Columns["celular_Empleado"].DataPropertyName = "Celular";

            dataGridEmpleados.Columns.Add("DireccionCompleta", "Dirección");
            dataGridEmpleados.Columns["DireccionCompleta"].DataPropertyName = "DireccionCompleta";

            dataGridEmpleados.Columns.Add("CodigoPostal", "Código Postal");
            dataGridEmpleados.Columns["CodigoPostal"].DataPropertyName = "CodigoPostal";

            dataGridEmpleados.Columns.Add("LocalidadNombre", "Localidad");
            dataGridEmpleados.Columns["LocalidadNombre"].DataPropertyName = "LocalidadNombre";

            dataGridEmpleados.Columns.Add("ProvinciaNombre", "Provincia");
            dataGridEmpleados.Columns["ProvinciaNombre"].DataPropertyName = "ProvinciaNombre";

            dataGridEmpleados.Columns.Add("PaisNombre", "País");
            dataGridEmpleados.Columns["PaisNombre"].DataPropertyName = "PaisNombre";

            dataGridEmpleados.Columns.Add("PerfilNombre", "Perfil");
            dataGridEmpleados.Columns["PerfilNombre"].DataPropertyName = "PerfilNombre";

            dataGridEmpleados.Columns.Add("EstadoNombre", "Estado");
            dataGridEmpleados.Columns["EstadoNombre"].DataPropertyName = "EstadoNombre";

            // Establece el orden de las columnas
            dataGridEmpleados.Columns["DireccionCompleta"].DisplayIndex = 7;
            dataGridEmpleados.Columns["CodigoPostal"].DisplayIndex = 8;
            dataGridEmpleados.Columns["LocalidadNombre"].DisplayIndex = 9;
            dataGridEmpleados.Columns["ProvinciaNombre"].DisplayIndex = 10;
            dataGridEmpleados.Columns["PaisNombre"].DisplayIndex = 11;
            dataGridEmpleados.Columns["PerfilNombre"].DisplayIndex = 12;
            dataGridEmpleados.Columns["EstadoNombre"].DisplayIndex = 13;
        }

        private void CargarEmpleados()
        {
            // Configurar el DataGridView y establecer AutoGenerateColumns a false
            ConfigurarDataGridView();
            dataGridEmpleados.AutoGenerateColumns = false;

            // Obtener los empleados desde la base de datos
            EmpleadoDAL empleadoDAL = new EmpleadoDAL();
            List<Empleado> empleados = empleadoDAL.ObtenerTodosLosEmpleados();

            if (empleados != null && empleados.Count > 0)
            {
                dataGridEmpleados.DataSource = empleados;

                // Verificar y ocultar columnas innecesarias si existen
                if (dataGridEmpleados.Columns["Calle"] != null) dataGridEmpleados.Columns["Calle"].Visible = false;
                if (dataGridEmpleados.Columns["NumeroCalle"] != null) dataGridEmpleados.Columns["NumeroCalle"].Visible = false;
                if (dataGridEmpleados.Columns["Piso"] != null) dataGridEmpleados.Columns["Piso"].Visible = false;
                if (dataGridEmpleados.Columns["Dpto"] != null) dataGridEmpleados.Columns["Dpto"].Visible = false;
                if (dataGridEmpleados.Columns["IdLocalidad"] != null) dataGridEmpleados.Columns["IdLocalidad"].Visible = false;
                if (dataGridEmpleados.Columns["IdPerfil"] != null) dataGridEmpleados.Columns["IdPerfil"].Visible = false;
                if (dataGridEmpleados.Columns["IdEstado"] != null) dataGridEmpleados.Columns["IdEstado"].Visible = false;
            }
            else
            {
                MessageBox.Show("No se encontraron empleados.");
            }
        }


        private void BAgregarEmpleado_Click(object sender, EventArgs e)
        {
            IngresarEmpleado formEmpleado = new IngresarEmpleado();
            formEmpleado.ShowDialog();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            EditarEmpleado formEditarEmpleado = new EditarEmpleado();
            formEditarEmpleado.ShowDialog();
        }
    }
}
