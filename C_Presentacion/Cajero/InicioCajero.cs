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

        private void personalizarDiseño ()
        {
            PSubMenuPagos.Visible = false;
            PSubMenuFacturas.Visible = false;
            PSubMenuInformes.Visible = false;
        }

        private void ocultarSubMenu()
        {
            if (PSubMenuPagos.Visible == true)
                PSubMenuPagos.Visible = false;
            if (PSubMenuFacturas.Visible == true)
                PSubMenuFacturas.Visible = false;
            if (PSubMenuInformes.Visible == true)
                PSubMenuInformes.Visible = false;
        }

        private void mostrarSubMenu (Panel subMenu)
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
            mostrarSubMenu(PSubMenuFacturas);
        }

        private void BInformes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(PSubMenuInformes);
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
