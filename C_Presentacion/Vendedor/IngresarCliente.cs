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
    public partial class IngresarCliente : Form
    {
        public IngresarCliente()
        {
            InitializeComponent();
        }

        private void BSalirForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BAtras_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
