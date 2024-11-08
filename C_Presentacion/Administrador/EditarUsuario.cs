using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class EditarUsuario : Form
    {
        private int idUsuario;
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public EditarUsuario(int idUsuario, string cuilEmpleado, Empleado empleado)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            TBUsuario.Text = cuilEmpleado;
            CargarUsuario();
        }

        private void CargarUsuario()
        {
            // Obtener la información del usuario usando el idUsuario
            Usuario usuario = usuarioDAL.ObtenerUsuarioPorId(idUsuario);
            if (usuario != null)
            {
                // Mostrar los datos del usuario
                TBUsuario.Text = usuario.CuilEmpleado;
                TBContraseñaUsuario.Text = usuario.PassswordUsuario;

                // Mostrar los datos del empleado asociado
                TBCuilEmpleado.Text = usuario.Empleado?.CUIL ?? "N/A";
                TBDniEmpleado.Text = usuario.Empleado?.DNI ?? "N/A";
                TBNombreEmpleado.Text = usuario.Empleado?.Nombre ?? "N/A";
                TBApellidoEmpleado.Text = usuario.Empleado?.Apellido ?? "N/A";
                TBEmailEmpleado.Text = usuario.Empleado?.Email ?? "N/A"; 
                TBPerfilEmpleado.Text = usuario.PerfilNombre ?? "N/A";

                // Deshabilitar los campos de datos del empleado para que no sean editables
                TBCuilEmpleado.ReadOnly = true;
                TBDniEmpleado.ReadOnly = true;
                TBNombreEmpleado.ReadOnly = true;
                TBApellidoEmpleado.ReadOnly = true;
                TBEmailEmpleado.ReadOnly = true;
                TBPerfilEmpleado.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("No se encontró el usuario.");
                this.Close();
            }
        }

        private void BEditarUsuario_Click(object sender, EventArgs e)
        {
            // Crear el objeto Usuario con los nuevos datos
            Usuario usuarioActualizado = new Usuario
            {
                IdUsuario = idUsuario,
                CuilEmpleado = TBUsuario.Text,
                PassswordUsuario = TBContraseñaUsuario.Text
            };

            // Actualizar el usuario en la base de datos
            bool resultado = usuarioDAL.ActualizarUsuario(usuarioActualizado);

            if (resultado)
            {
                MessageBox.Show("Usuario actualizado exitosamente.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error al actualizar el usuario.");
            }
        }

        private void BSalirEditarUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}