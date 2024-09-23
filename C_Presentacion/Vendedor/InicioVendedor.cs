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
        // Verifica que solo haya una definición de estos elementos

        public InicioVendedor()
        {
            InitializeComponent();
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ocultarSubmenu()
        {
            if (panelSubMenuVentas.Visible)
                panelSubMenuVentas.Visible = false;
            if (panelSubMenuTestDrive.Visible)
                panelSubMenuTestDrive.Visible = false;
            if (panelSubMenuInformes.Visible)
                panelSubMenuInformes.Visible = false;
        }

        private void mostrarSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                ocultarSubmenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        #region Cliente
        private void BCliente_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new VisualizarClientes(), "Clientes");
        }
        #endregion Cliente

        #region Venta        
        private void BVentas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuVentas);
        }
        private void BVentasMensuales_Click(object sender, EventArgs e)
        {
            // Obtener el mes actual en formato largo (por ejemplo, "Septiembre")
            string mesActual = DateTime.Now.ToString("MMMM");

            // Convertir la primera letra del mes en mayúscula y el resto en minúscula
            mesActual = char.ToUpper(mesActual[0]) + mesActual.Substring(1).ToLower();

            // Concatenar "Ventas" con el mes actual
            string titulo = "Ventas " + mesActual; 

            abrirFormularioHijo(new VisualizarVentas(), titulo);
            ocultarSubmenu();
        }
        private void BNuevaVenta_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new IngresarVenta(), "Ingresar Venta"); 
            ocultarSubmenu();
        }

        #endregion

        #region Test Drive
        private void BTestDrive_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuTestDrive);
        }

        private void BNuevoTurno_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private void BModificarReserva_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private void BVerReservas_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }
        #endregion

        #region Informes
        private void BInformes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuInformes);
        }

        private void BInformesMensuales_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private void BInformesTrimestrales_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }
        #endregion

        private void BCatalogo_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new VisualizarCatalogo(), "Catálogo");
            ocultarSubmenu();
        }

        private void BAyuda_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private Form formularioActivo = null;

        private void abrirFormularioHijo(Form formHijo, string titulo)
        {
            if(formularioActivo != null)
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
            this.Close();
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
    }
}
