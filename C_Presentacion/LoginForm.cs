using AgMaGest.C_Presentacion.Administrador;
using AgMaGest.C_Presentacion.Vendedor;
using AgMaGest.C_Presentacion.Cajero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using AgMaGest.C_Logica;

namespace AgMaGest.C_Presentacion
{
    public partial class LoginForm : Form
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();
        public LoginForm()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
            BSalir.Paint += new PaintEventHandler(DrawRoundButton);
            BIniciarSesion.Paint += new PaintEventHandler(DrawRoundButton);


            this.KeyPreview = true; // Permite que el formulario capture el evento KeyDown
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

        private void IniciarSesion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BIniciarSesion_Click(sender, e); // Llamar al evento que ejecuta la acción de agregar
                e.Handled = true; // Indica que el evento fue manejado
                e.SuppressKeyPress = true; // Evita que la tecla Enter haga otra acción
            }
        }

        private void BIniciarSesion_Click(object sender, EventArgs e)
        {
            string cuil = TBUsuario.Text.Trim();    // Campo Usuario (CUIL)
            string contrasena = TBContrasenia.Text.Trim();    // Campo Contraseña

            // Validar si ambos campos están vacíos
            if (string.IsNullOrEmpty(cuil) && string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del campo Usuario (CUIL) - no vacío
            if (string.IsNullOrEmpty(cuil))
            {
                MessageBox.Show("Por favor, ingrese su CUIL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del campo Contraseña - no vacío
            if (string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Verificar las credenciales del usuario contra la base de datos
            string rol = usuarioDAL.VerificarCredenciales(cuil, contrasena);
            if (rol != null)
            {
                Form form;
                switch (rol)
                {
                    case "Vendedor":
                        form = new InicioVendedor();
                        break;
                    case "Administrador":
                        form = new InicioAdministrador();
                        break;
                    case "Cajero":
                        form = new InicioCajero();
                        break;
                    default:
                        MessageBox.Show("Rol desconocido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                form.Show();
                this.Hide(); // Oculta el formulario de login
            }
            else
            {
                // Si los datos no coinciden, mostramos un mensaje de error
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Ocultar los caracteres de la contraseña
            TBContrasenia.PasswordChar = '●';
        }

        // Método para dibujar botones redondeados
        private void DrawRoundButton(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            Graphics g = e.Graphics;

            // Crear un rectángulo con bordes redondeados
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            GraphicsPath path = new GraphicsPath();
            int radius = 20; // Ajusta el radio según necesites
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            // Dibujar el fondo del botón
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (SolidBrush brush = new SolidBrush(btn.BackColor))
            {
                g.FillPath(brush, path);
            }

            // Dibujar el texto del botón
            TextRenderer.DrawText(g, btn.Text, btn.Font, rect, btn.ForeColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Establecer la región del botón a la forma redondeada
            btn.Region = new Region(path);
        }

        // Validar que solo se puedan ingresar números en el campo usuario (KeyPress Event)
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Este campo solo puede contener números.");
            }
        }

        private void BSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
