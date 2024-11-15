using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgMaGest.C_Presentacion.Administrador
{
    public partial class AsignarUsuario : Form
    {
        public AsignarUsuario(string cuil, string nombre, string apellido, string dni, string perfil)
        {
            InitializeComponent();
            // Asigna los valores a los campos de texto
            TBCuilEmpleado.Text = cuil;
            TBNombreEmpleado.Text = nombre;
            TBApellidoEmpleado.Text = apellido;
            TBDniEmpleado.Text = dni;
            TBPerfilEmpleado.Text = perfil;

            // Deshabilitar los campos de datos del empleado para que no sean editables
            TBCuilEmpleado.ReadOnly = true;
            TBNombreEmpleado.ReadOnly = true;
            TBApellidoEmpleado.ReadOnly = true;
            TBDniEmpleado.ReadOnly = true;
            TBPerfilEmpleado.ReadOnly = true;
        }

        private void BAsignarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioDAL usuarioDAL = new UsuarioDAL();

            // Verifica si el usuario ya existe
            if (usuarioDAL.UsuarioExiste(TBCuilUsuario.Text))
            {
                MessageBox.Show("Este usuario ya está registrado.");
                return; // Detiene el proceso si el usuario ya existe
            }

            // Crea y asigna el usuario si no existe
            Usuario usuario = new Usuario
            {
                CuilEmpleado = TBCuilUsuario.Text,
                PassswordUsuario = TBContraseñaUsuario.Text
            };

            usuarioDAL.AsignarUsuarioAEmpleado(usuario);
            MessageBox.Show("Usuario asignado correctamente.");
            this.Close(); // Cerrar el formulario después de guardar
        }


        private void BSalirUsuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
