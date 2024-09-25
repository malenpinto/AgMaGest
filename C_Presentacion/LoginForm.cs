using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Define los colores del gradiente
            Color startColor = Color.FromArgb(18, 112, 198); // Color RGB(174,221,237)
            Color endColor = Color.FromArgb(174, 221, 237);    // Color RGB(18,112,198)

            // Define el rectángulo de fondo
            Rectangle rect = this.ClientRectangle;

            // Crea un gradiente lineal de arriba hacia abajo
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, startColor, endColor, 90F))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }
    

        private void BIniciarSesion_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
