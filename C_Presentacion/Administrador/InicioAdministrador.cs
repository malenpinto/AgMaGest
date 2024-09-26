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
    public partial class InicioAdministrador : Form
    {
        public InicioAdministrador()
        {
            InitializeComponent();
        }

        private void BEmpleadosAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarEmpleados(), "Empleados");
        }

        private void BInventarioAdmin_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarInventario(), "Inventario");
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

        private void BAtrasAdmin_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
                formularioActivo.Close();

            // Ocultar el botón de retroceso cuando regreses al menú principal
            BAtrasAdmin.Visible = false;
            LTituloInicioAdmin.Text = " ";  // Cambia al título del menú principal
        }

        private void BSalirVistaAdm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
