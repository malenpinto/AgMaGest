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
    public partial class VisualizarImagen : Form
    {
        public VisualizarImagen(Image imagen)
        {
            InitializeComponent();

            // Configurar el PictureBox para mostrar la imagen
            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill,
                Image = imagen,
                SizeMode = PictureBoxSizeMode.Zoom // Ajustar la imagen al tamaño del formulario
            };

            this.Controls.Add(pictureBox);
            this.Size = new Size(800, 600); // Tamaño inicial del formulario
        }
    }
}
