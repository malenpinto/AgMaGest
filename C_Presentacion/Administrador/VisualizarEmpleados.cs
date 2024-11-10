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
            BBuscarEmpleado.Click += new EventHandler(BBuscarEmpleado_Click); 
        }

        private void VisualizarEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
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

        private void BBuscarEmpleado_Click(object sender, EventArgs e)
        {
            string textoBusqueda = TBBuscarEmpleado.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                FiltrarEmpleados(textoBusqueda);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un texto para buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void FiltrarEmpleados(string texto)
        {
            EmpleadoDAL empleadoDAL = new EmpleadoDAL();

            // Filtrar empleados con el texto de búsqueda
            List<Empleado> empleadosFiltrados = empleadoDAL.FiltrarEmpleados(texto);

            if (empleadosFiltrados != null && empleadosFiltrados.Count > 0)
            {
                // Si se encuentran resultados, asignarlos al DataGridView
                dataGridEmpleados.DataSource = empleadosFiltrados;
            }
            else
            {
                // Si no hay resultados, mostrar mensaje y recargar todos los empleados
                MessageBox.Show("No se encontraron empleados con el criterio de búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recargar todos los empleados
                CargarEmpleados();
            }
        }

        private void BAgregarEmpleado_Click(object sender, EventArgs e)
        {
            IngresarEmpleado formEmpleado = new IngresarEmpleado();
            formEmpleado.ShowDialog();
        }

        private void BEditarEmpleado_Click(object sender, EventArgs e)
        {
            if (dataGridEmpleados.SelectedRows.Count > 0)
            {
                int indiceSeleccionado = dataGridEmpleados.SelectedRows[0].Index;
                Empleado empleado = (Empleado)dataGridEmpleados.Rows[indiceSeleccionado].DataBoundItem;

                EditarEmpleado editarForm = new EditarEmpleado(empleado);
                if (editarForm.ShowDialog() == DialogResult.OK)
                {
                    CargarEmpleados(); // Recargar datos actualizados
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BEliminarEmpleado_Click(object sender, EventArgs e)
        {
            // Verifica que haya una fila seleccionada en el DataGridView
            if (dataGridEmpleados.SelectedRows.Count > 0)
            {
                // Obtén los valores de la fila seleccionada
                DataGridViewRow filaSeleccionada = dataGridEmpleados.SelectedRows[0];
                string cuilEmpleado = filaSeleccionada.Cells["cuil_Empleado"].Value.ToString();
                string apellidoEmpleado = filaSeleccionada.Cells["apellido_Empleado"].Value.ToString();
                string nombreEmpleado = filaSeleccionada.Cells["nombre_Empleado"].Value.ToString();

                // Mostrar mensaje de confirmación
                string mensaje = $"¿Estás seguro que deseas eliminar al usuario?\nCUIL: {cuilEmpleado}\nEmpleado/a: {apellidoEmpleado}, {nombreEmpleado}";
                DialogResult resultado = MessageBox.Show(mensaje, "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

                if (resultado == DialogResult.Yes)
                {
                    // Llama al método para eliminar al usuario
                    EmpleadoDAL empleadoDAL = new EmpleadoDAL();
                    if (empleadoDAL.EliminarEmpleado(cuilEmpleado))
                    {
                        MessageBox.Show("Empleado eliminado exitosamente.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Refresca los datos del DataGridView
                        CargarEmpleados();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un empleado para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BAsignarUsuario_Click(object sender, EventArgs e)
        {
            if (dataGridEmpleados.SelectedRows.Count > 0)
            {
                var filaSeleccionada = dataGridEmpleados.SelectedRows[0];
                string cuilEmpleado = filaSeleccionada.Cells["cuil_Empleado"].Value.ToString();
                string nombreEmpleado = filaSeleccionada.Cells["nombre_Empleado"].Value.ToString();
                string apellidoEmpleado = filaSeleccionada.Cells["apellido_Empleado"].Value.ToString();
                string dniEmpleado = filaSeleccionada.Cells["dni_Empleado"].Value.ToString();
                string perfilEmpleado = filaSeleccionada.Cells["PerfilNombre"].Value.ToString();

                // Crear y mostrar el formulario AsignarUsuario pasando los datos del empleado
                AsignarUsuario formAsignarUsuario = new AsignarUsuario(cuilEmpleado, nombreEmpleado, apellidoEmpleado, dniEmpleado, perfilEmpleado);
                formAsignarUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado.");
            }
        }

        private void DataGridViewEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridEmpleados.SelectedRows.Count > 0)
            {
                BAsignarUsuario.Visible = true;
                BEditarEmpleado.Visible = true;
                BEliminarEmpleado.Visible = true;
            }
            else
            {
                // Opcionalmente, ocultar los botones si no hay selección
                BAsignarUsuario.Visible = false;
                BEditarEmpleado.Visible = false;
                BEliminarEmpleado.Visible = false;
            }
        }

        
    }
}
