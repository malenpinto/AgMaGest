﻿using System;
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
    public partial class IngresarEmpleado : Form
    {
        public IngresarEmpleado()
        {
            InitializeComponent();
        }

        private void BSalirEmpleado_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}