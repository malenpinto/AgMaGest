using AgMaGest.C_Logica.Entidades;
using AgMaGest.C_Presentacion.Vendedor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class InicioAdministrador : Form
    {
        public InicioAdministrador(Empleado empleado)
        {
            InitializeComponent();
            LUsuarioEmpleado.Text = $"{empleado.Nombre}";
        }

        private void BEmpleadosAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarEmpleados(), "Empleados");
        }

        private void BUsuariosAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarUsuarios(), "Usuarios");
        }
        private void BInventarioAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarInventario(), "Inventario");
        }

        private void BEstadisticasAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarEstadisticas(), "Estadísticas");
        }

        private void BFacturasAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarFacturas(), "Facturas");
        }

        private void BBackUpBD_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Agmagest.Properties.Settings.AgmagestConnectionString"].ConnectionString;
            string backupFilePath = @"C:\Respaldos\RespaldoBaseDatos.bak";

            try
            {
                // Comando SQL para realizar el respaldo
                string backupQuery = $"BACKUP DATABASE [Agmagest] TO DISK = '{backupFilePath}' WITH FORMAT, MEDIANAME = 'SQLServerBackups', NAME = 'Full Backup of Agmagest';";

                // Conexión a SQL Server
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(backupQuery, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show($"Copia de seguridad realizada exitosamente en: {backupFilePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrir ubicación del respaldo
                System.Diagnostics.Process.Start("explorer.exe", "/select," + backupFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al realizar la copia de seguridad: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BAcercaAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarAcercaDeAdmin(), "Acerca de AgMaGest");
        }

        private Form formularioActivo = null;

        private void AbrirFormularioHijo(Form formHijo, string titulo)
        {
            if (formularioActivo != null)
                formularioActivo.Close();
            formularioActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            panelContenedorAdmin.Controls.Add(formHijo);
            panelContenedorAdmin.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();

            // Cambia el título dinámicamente
            LTituloInicioAdmin.Text = titulo;

            // Muestra el botón de retroceso
            BAtrasAdmin.Visible = true;
        }
        private void BAtrasAdmin_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
                formularioActivo.Close();

            // Ocultar el botón de retroceso cuando regreses al menú principal
            BAtrasAdmin.Visible = false;
            LTituloInicioAdmin.Text = " ";  // Cambia al título del menú principal
        }

        private void BExitAdmin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BMaximizarAdmin_Click(object sender, EventArgs e)
        {
            // Si la ventana está maximizada, la restaura
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            // Si la ventana está en su estado normal, la maximiza
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void BMinimizarAdmin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BCerrarSesionAdmin_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de Login
            LoginForm loginForm = new LoginForm();

            // Mostrar el formulario de Login
            loginForm.Show();

            // Cerrar el formulario actual (InicioAdministrador)
            this.Close();
        }
    }
}
