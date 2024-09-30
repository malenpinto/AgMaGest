using AgMaGest.C_Presentacion.Vendedor;
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
    public partial class VisualizarEmpleados : Form
    {
        public VisualizarEmpleados()
        {
            InitializeComponent();
        }

        private void BAgregarEmpleado_Click(object sender, EventArgs e)
        {
            IngresarEmpleado formEmpleado = new IngresarEmpleado();
            formEmpleado.ShowDialog();
        }

        private void BEditar_Click(object sender, EventArgs e)
        {
            EditarEmpleado formEditarEmpleado = new EditarEmpleado();
            formEditarEmpleado.ShowDialog();
        }
    }
}
