using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Cajero
{
    public partial class InicioCajero : Form
    {
        public InicioCajero()
        {
            InitializeComponent();
            personalizarDiseño();
        }

        private void personalizarDiseño()
        {
            PSubMenuPagos.Visible = false;
            //PSubMenuFacturas.Visible = false;
            PSubMenuInformes.Visible = false;
        }

        private void ocultarSubMenu()
        {
            if (PSubMenuPagos.Visible == true)
                PSubMenuPagos.Visible = false;
           // if (PSubMenuFacturas.Visible == true)
           //    PSubMenuFacturas.Visible = false;
            if (PSubMenuInformes.Visible == true)
                PSubMenuInformes.Visible = false;
        }

        private void mostrarSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;

        }

        private void BPagos_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(PSubMenuPagos);

        }

        private void BFacturas_Click(object sender, EventArgs e)
        {
          //mostrarSubMenu(PSubMenuFacturas);
        }

        private void BInformes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(PSubMenuInformes);
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

       //#region Pagos Poner las regiones
        private void BRegistrarPagos_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new RegistrarPago(), "Registrar Pago");
            ocultarSubMenu();
        }

        private void BControlCaja_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
        }

        private void BInformeDiario_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
        }

        private void BInformeMensual_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
        }

        private void BAyuda_Click(object sender, EventArgs e)
        {
            ocultarSubMenu();
        }

        private Form activeForm = null;
        private void abrirFormularioHijo(Form formularioHijo, string titulo)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;
            PFormHijo.Controls.Add(formularioHijo);
            PFormHijo.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();

            //Cambia el titulo dinamicamente
            LTituloInicioCajero.Text = titulo;

            //Muestra boton de retroceso
            BAtrasCajero.Visible = true;
        }

        private void BAtrasCajero_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            BAtrasCajero.Visible = false;
            LTituloInicioCajero.Text = " "; //Cambia el titulo del menu principal
        }

        private void BCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}