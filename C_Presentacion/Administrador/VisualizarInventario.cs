using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class VisualizarInventario : Form
    {
        public VisualizarInventario()
        {
            InitializeComponent();
        }

        private void BAgregarVehiculo_Click(object sender, EventArgs e)
        {
            IngresarVehiculo formVehiculo = new IngresarVehiculo();
            formVehiculo.ShowDialog();
        }

        private void BEditarVehiculo_Click_1(object sender, EventArgs e)
        {
            EditarVehiculo formVehiculo = new EditarVehiculo();
            formVehiculo.ShowDialog();
        }
    }
}
