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
    public partial class RegistrarPago : Form
    {
        public RegistrarPago()
        {
            InitializeComponent();
        }

        private void BVolverMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BGenerarVenta_Click(object sender, EventArgs e)
        {
            GenerarPago formPago = new GenerarPago();
            formPago.ShowDialog();
        }
    }
}
