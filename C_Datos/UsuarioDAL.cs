using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Datos
{
    public class UsuarioDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_Usuario, cuil_Empleado, password_Usuario FROM Usuario", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Usuario usuario = new Usuario()
                        {
                            IdUsuario = reader.GetInt32(0),
                            CuilEmpleado = reader.GetString(1),
                            PassswordUsuario = reader.GetString(2)
                        };

                        usuarios.Add(usuario);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores relacionados con SQL
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
            return usuarios;
        }

        public bool AsignarUsuarioAEmpleado(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Usuario (cuil_Empleado, password_Usuario) VALUES (@CuilEmpleado, @PasswordUsuario)", conn);

                    cmd.Parameters.AddWithValue("@CuilEmpleado", usuario.CuilEmpleado);
                    cmd.Parameters.AddWithValue("@PasswordUsuario", usuario.PassswordUsuario);

                    cmd.ExecuteNonQuery();
                }
                return true; // Asignación exitosa
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
        }

    }
}
