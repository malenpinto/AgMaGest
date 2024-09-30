using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgMaGest.C_Presentacion.Vendedor;


namespace AgMaGest.C_Presentacion.Vendedor
{
    public partial class VisualizarClientes : Form
    {
        public VisualizarClientes()
        {
            InitializeComponent();
        }

        private void BAgregarCliente_Click_1(object sender, EventArgs e)
        {
            if (BAgregarEmpresa.Visible && BAgregarPersona.Visible)
            {
                BAgregarPersona.Visible = false;
                BAgregarEmpresa.Visible = false;
            }
            else
            {
                BAgregarPersona.Visible = true;
                BAgregarEmpresa.Visible = true;
            }
        }

        private void BAgregarPersona_Click(object sender, EventArgs e)
        {
            IngresarClienteFinal formPersona = new IngresarClienteFinal();
            formPersona.ShowDialog();
            BAgregarPersona.Visible = false;
            BAgregarEmpresa.Visible = false;
        }

        private void BAgregarEmpresa_Click(object sender, EventArgs e)
        {
            IngresarClienteEmpresa formEmpresa = new IngresarClienteEmpresa();
            formEmpresa.ShowDialog();
            BAgregarPersona.Visible = false;
            BAgregarEmpresa.Visible = false;
        }

        private void BEditarEmpresa_Click(object sender, EventArgs e)
        {
            EditarClienteEmpresa formEditarEmpresa = new EditarClienteEmpresa();
            formEditarEmpresa.ShowDialog();
        }
    }
}
