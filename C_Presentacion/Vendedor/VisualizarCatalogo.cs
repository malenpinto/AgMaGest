﻿using System;
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
    public partial class VisualizarCatalogo : Form
    {
        public VisualizarCatalogo()
        {
            InitializeComponent();
        }

        private void BGenerarPedido_Click(object sender, EventArgs e)
        {
            IngresarPedido formPedido = new IngresarPedido();
            formPedido.ShowDialog();
        }
    }
}
