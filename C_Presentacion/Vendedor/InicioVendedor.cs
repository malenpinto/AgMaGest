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

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ocultarSubmenu()
        {
            if (panelSubMenuCliente.Visible)
                panelSubMenuCliente.Visible = false;
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
            mostrarSubMenu(panelSubMenuCliente);
        }

        private void BNuevoCliente_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new IngresarCliente());
            ocultarSubmenu();
        }

        private void BModificarCliente_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private void BClientes_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }
        #endregion Cliente

        #region Venta
        private void BVentas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMenuVentas);
        }

        private void BNuevaVenta_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private void BVerVentas_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
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
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private void BAyuda_Click(object sender, EventArgs e)
        {
            //Nuestro Codigo
            //
            ocultarSubmenu();
        }

        private void BExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Form formularioActivo = null;
        private void abrirFormularioHijo(Form formHijo)
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
        }

        private void BMaximizar_Click(object sender, EventArgs e)
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

        private void BMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
