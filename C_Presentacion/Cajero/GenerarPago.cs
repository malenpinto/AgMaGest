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
    public partial class GenerarPago : Form
    {
        public GenerarPago()
        {
            InitializeComponent();
        }

        private void BSalirGenerarPago_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void GenerarPago_Load(object sender, EventArgs e)
        {
            // Agregar opciones al ComboBox de Medios de Pago
            CBMediosPagos.Items.Add("Tarjeta de Crédito");
            CBMediosPagos.Items.Add("Tarjeta de Débito");
            CBMediosPagos.Items.Add("Efectivo");
            CBMediosPagos.Items.Add("Transferencia Bancaria");

            // Opción predeterminada (opcional)
            CBMediosPagos.SelectedIndex = 0; // Selecciona la primera opción por defecto
        }

        private void BConfirmarGenerarPago_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBDescPagoCliente.Text) ||
                string.IsNullOrWhiteSpace(CBMediosPagos.Text))
            {
                // Mostrar mensaje de error si falta algún campo
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
