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
    public partial class IngresarPedido : Form
    {
        public IngresarPedido()
        {
            InitializeComponent();
        }

        private void BSalirPedido_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BConfirmarPedido_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
