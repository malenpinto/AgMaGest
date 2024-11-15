using AgMaGest.C_Logica;
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

namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class InicioVendedor : Form
    {
        public InicioVendedor(Empleado empleado)
        {
            InitializeComponent();
            LNombreUsuario.Text = $"{empleado.Nombre}";

        }

        private void BCliente_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarClientes(), "Clientes");
        }

        private void BPedidoVendedor_Click(object sender, EventArgs e)
        {
            // Obtener el mes actual en formato largo (por ejemplo, "Septiembre")
            string mesActual = DateTime.Now.ToString("MMMM");

            // Convertir la primera letra del mes en mayúscula y el resto en minúscula
            mesActual = char.ToUpper(mesActual[0]) + mesActual.Substring(1).ToLower();

            // Concatenar "Ventas" con el mes actual
            string titulo = "Pedidos " + mesActual;

            AbrirFormularioHijo(new VisualizarPedidos(), titulo);
        }

        private void BCatalogo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarCatalogo(), "Catálogo");
        }

        private void BEstadisticasVendedor_Click(object sender, EventArgs e)
        {

            // Obtener el mes actual en formato largo (por ejemplo, "Septiembre")
            string mesActual = DateTime.Now.ToString("MMMM");

            // Convertir la primera letra del mes en mayúscula y el resto en minúscula
            mesActual = char.ToUpper(mesActual[0]) + mesActual.Substring(1).ToLower();

            // Concatenar "Estadísticas" con el mes actual
            string titulo = "Estadísticas de " + mesActual;

            AbrirFormularioHijo(new VisualizarEstadisticas(), titulo);
        }

        private void BAcercaDeVendedor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarAcercaDe(), "Acerca de AgMaGest");
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
            panelContenedor.Controls.Add(formHijo);
            panelContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();

            // Cambia el título dinámicamente
            LTituloInicioCliente.Text = titulo;

            // Muestra el botón de retroceso
            BAtrasCliente.Visible = true;
        }
        private void BExitCliente_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BMaximizarCliente_Click(object sender, EventArgs e)
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

        private void BMinimizarCliente_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BAtrasCliente_Click(object sender, EventArgs e)
        {
            if (formularioActivo != null)
                formularioActivo.Close();

            // Ocultar el botón de retroceso cuando regreses al menú principal
            BAtrasCliente.Visible = false;
            LTituloInicioCliente.Text = " ";  // Cambia al título del menú principal
        }

        private void BCerrarSesionVendedor_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de Login
            LoginForm loginForm = new LoginForm();

            // Mostrar el formulario de Login
            loginForm.Show();

            // Cerrar el formulario actual (InicioVendedor)
            this.Close();
        }
    }
}
