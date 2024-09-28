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
            string usuario = TBUsuario.Text.Trim();    // Campo Usuario (DNI)
            string contrasena = TBContrasenia.Text.Trim();    // Campo Contraseña

            // Validar si ambos campos están vacíos
            if (string.IsNullOrEmpty(usuario) && string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del campo Usuario (DNI) - no vacío
            if (string.IsNullOrEmpty(usuario))
            {
                MessageBox.Show("Por favor, ingrese su DNI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validación del campo Contraseña - no vacío
            if (string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Simulación de la verificación del rol del usuario
            // Definimos usuarios y contraseñas estáticos
            string usuarioVendedor = "1234";
            string contraseñaVendedor = "asdf";

            string usuarioAdministrador = "12345";
            string contraseñaAdministrador = "asdfg";

            string usuarioCajero = "123456";
            string contraseñaCajero = "asdfgh";

            // Obtenemos los valores ingresados
            string usuarioIngresado = TBUsuario.Text;
            string contraseñaIngresada = TBContrasenia.Text;

            // Verificación para usuario Vendedor
            if (usuarioIngresado == usuarioVendedor && contraseñaIngresada == contraseñaVendedor)
            {
                // Abre el formulario de InicioVendedor
                InicioVendedor formVendedor = new InicioVendedor();
                formVendedor.Show();
                this.Hide(); // Oculta el formulario de login
            }
            // Verificación para usuario Administrador
            else if (usuarioIngresado == usuarioAdministrador && contraseñaIngresada == contraseñaAdministrador)
            {
                // Abre el formulario de InicioAdministrador
                InicioAdministrador formAdmin = new InicioAdministrador();
                formAdmin.Show();
                this.Hide(); // Oculta el formulario de login
            }
            //Verificacion para usuario Cajero
            else if (usuarioIngresado == usuarioCajero && contraseñaIngresada == contraseñaCajero)
            {
                // Abre el formulario de InicioAdministrador
                InicioCajero formCajero = new InicioCajero();
                formCajero.Show();
                this.Hide(); // Oculta el formulario de login
            }
            else
            {
                // Si los datos no coinciden, mostramos un mensaje de error
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            this.Close();
        }
    }
}
