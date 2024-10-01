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
        public InicioVendedor()
        {
            InitializeComponent();
        }

        private void BCliente_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarClientes(), "Clientes");
        }

        private void BVentas_Click(object sender, EventArgs e)
        {
            // Obtener el mes actual en formato largo (por ejemplo, "Septiembre")
            string mesActual = DateTime.Now.ToString("MMMM");

            // Convertir la primera letra del mes en mayúscula y el resto en minúscula
            mesActual = char.ToUpper(mesActual[0]) + mesActual.Substring(1).ToLower();

            // Concatenar "Ventas" con el mes actual
            string titulo = "Ventas " + mesActual;

            AbrirFormularioHijo(new VisualizarVentas(), titulo);
            OcultarSubmenu();
        }

        private void BCatalogo_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarCatalogo(), "Catálogo");
        }

        #region Estadísticas
        private void BEstadisticasVendedor_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(panelSubMenuEstadisticas);
        }

        private void BEstadistMesVend_Click(object sender, EventArgs e)
        {
            // Obtener el mes actual en formato largo (por ejemplo, "Septiembre")
            string mesActual = DateTime.Now.ToString("MMMM");

            // Convertir la primera letra del mes en mayúscula y el resto en minúscula
            mesActual = char.ToUpper(mesActual[0]) + mesActual.Substring(1).ToLower();

            // Concatenar "Estadísticas" con el mes actual
            string titulo = "Estadísticas de " + mesActual;

            AbrirFormularioHijo(new VisualizarEstadisticaMensual(), titulo);
            OcultarSubmenu();
        }

        private void BEstadistTrimVend_Click(object sender, EventArgs e)
        {
            // Obtener el mes actual y los dos meses anteriores
            DateTime mesActual = DateTime.Now;
            DateTime mesAnterior1 = mesActual.AddMonths(-1);
            DateTime mesAnterior2 = mesActual.AddMonths(-2);

            // Convertir los nombres de los meses a formato largo (por ejemplo, "Septiembre")
            string mesActualNombre = mesActual.ToString("MMMM");
            string mesAnterior1Nombre = mesAnterior1.ToString("MMMM");
            string mesAnterior2Nombre = mesAnterior2.ToString("MMMM");

            // Convertir la primera letra de cada mes en mayúscula y el resto en minúscula
            mesActualNombre = char.ToUpper(mesActualNombre[0]) + mesActualNombre.Substring(1).ToLower();
            mesAnterior1Nombre = char.ToUpper(mesAnterior1Nombre[0]) + mesAnterior1Nombre.Substring(1).ToLower();
            mesAnterior2Nombre = char.ToUpper(mesAnterior2Nombre[0]) + mesAnterior2Nombre.Substring(1).ToLower();

            // Concatenar "Estadísticas" con los últimos tres meses
            string titulo = $"Estadísticas de {mesAnterior2Nombre}, {mesAnterior1Nombre} y {mesActualNombre}";

            // Llamar a la función para abrir el formulario con el título generado
            AbrirFormularioHijo(new VisualizarEstadisticaTrimestral(), titulo);
            OcultarSubmenu();
        }
        #endregion

        private void BAcercaDeVendedor_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VisualizarAcercaDe(), "Acerca de AgMaGest");
        }

        private void OcultarSubmenu()
        {
            if (panelSubMenuEstadisticas.Visible)
                panelSubMenuEstadisticas.Visible = false;
        }

        private void MostrarSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                OcultarSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
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
