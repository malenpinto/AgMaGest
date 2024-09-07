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

namespace AgMaGest.C_Presentacion
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(Form1_Paint);
            BSalir.Paint += new PaintEventHandler(DrawRoundButton);
            BIniciarSesion.Paint += new PaintEventHandler(DrawRoundButton);
            // Asociar evento KeyPress para el campo de usuario
            TBUsuario.KeyPress += TBUsuario_KeyPress;
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
            string usuario = TBUsuario.Text.Trim();    // Campo Usuario (DNI)
            string contrasena = TBContrasenia.Text.Trim();    // Campo Contraseña

            // Validar si ambos campos están vacíos
            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del campo Usuario (DNI) - no vacío y solo números
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, ingrese su DNI.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que el usuario solo contenga números
            if (!EsSoloNumeros(usuario))
            {
                MessageBox.Show("El campo Usuario debe contener solo números (DNI).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del campo Contraseña - no vacío
            if (string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Guardar usuario si la casilla "Recordar" está marcada
            if (CBRecordar.Checked)
            {
                Properties.Settings.Default.UsuarioGuardado = usuario;
                Properties.Settings.Default.RecordarUsuario = true;
            }
            else
            {
                // Si la casilla no está marcada, limpiar los valores guardados
                Properties.Settings.Default.UsuarioGuardado = string.Empty;
                Properties.Settings.Default.RecordarUsuario = false;
            }

            // Guardar los cambios en las configuraciones
            Properties.Settings.Default.Save();

            // En este punto, las validaciones han sido exitosas
            MessageBox.Show("Login exitoso", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aca continuar con la lógica del inicio de sesión (conexión a BD)
        }

        // Método para validar si un string contiene solo números
        private bool EsSoloNumeros(string input)
        {
            // TryParse validará si el string contiene solo números
            return long.TryParse(input, out _);
        }


        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Ocultar los caracteres de la contraseña
            TBContrasenia.PasswordChar = '●';

            // Cargar el usuario guardado si la casilla de "Recordar" estaba marcada
            if (Properties.Settings.Default.RecordarUsuario)
            {
                TBUsuario.Text = Properties.Settings.Default.UsuarioGuardado;
                CBRecordar.Checked = true;  // Marcar la casilla de "Recordar Usuario"
            }
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

        private void BSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Validar que solo se puedan ingresar números en el campo usuario (KeyPress Event)
        private void TBUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Si no es un dígito y no es una tecla de control (como backspace), cancelar el evento
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Bloquear la entrada
                MessageBox.Show("Solo se permiten números en el campo Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
