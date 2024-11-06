using AgMaGest.C_Datos;
using AgMaGest.C_Logica.Entidades;
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
    public partial class AsignarUsuario : Form
    {
        public AsignarUsuario()
        {
            InitializeComponent();
        }

        private void BAsignarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                CuilEmpleado = TBCuilUsuario.Text,
                PassswordUsuario = TBContraseñaUsuario.Text
            };

            UsuarioDAL usuarioDAL = new UsuarioDAL();
            usuarioDAL.AsignarUsuarioAEmpleado(usuario);

            MessageBox.Show("Usuario asignado correctamente.");
            this.Close(); // Cerrar el formulario después de guardar
        }
    }
}
