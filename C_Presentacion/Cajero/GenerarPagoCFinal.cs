using AgMaGest.C_Datos;
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
    public partial class GenerarPagoCFinal : Form
    {

        public GenerarPagoCFinal()
        {
            InitializeComponent();
        }

        private void BSalirGenerarPago_Click(object sender, EventArgs e)
        {
            this.Close();  
        }
    }
}
