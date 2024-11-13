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

namespace AgMaGest.C_Presentacion.Cajero
{
    public partial class InicioCajero : Form
    {
        public InicioCajero(Empleado empleado)
        {
            InitializeComponent();
            LNombreUsuario.Text = $"{empleado.Nombre}";
            personalizarDiseño();
        }

        private void personalizarDiseño()
        {
            
            //PSubMenuFacturas.Visible = false;
            PSubMenuInformes.Visible = false;
        }

        private void ocultarSubMenu()
        {
          
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
            abrirFormularioHijo(new RegistrarPago(), "Registrar Pago");
            ocultarSubMenu();
        }

        private void BFacturas_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new Facturas(), "Lista de Facturas");
        }

        private void BInformes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(PSubMenuInformes);
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

   

        private void BInformeDiario_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new InformeDiario(), "Estadísticas Diarias");
            ocultarSubMenu();
        }

        private void BInformeMensual_Click(object sender, EventArgs e)
        {

            abrirFormularioHijo(new InformeMensual(), "Estadísticas Mensuales");
            ocultarSubMenu();
        }

        private void BAcercaDeCajero_Click(object sender, EventArgs e)
        {
            abrirFormularioHijo(new VisualizarAcercaDeCajero(), "Acerca de AgMa Gest");
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

        private void BCerrarSesionCajero_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia del formulario de Login
            LoginForm loginForm = new LoginForm();

            // Mostrar el formulario de Login
            loginForm.Show();

            // Cerrar el formulario actual (InicioCajero)
            this.Close();
        }
    }
}