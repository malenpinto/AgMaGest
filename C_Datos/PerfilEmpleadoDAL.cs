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
    public class PerfilEmpleadoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para obtener la lista de perfiles
        public List<PerfilEmpleado> ObtenerPerfiles()
        {
            List<PerfilEmpleado> perfiles = new List<PerfilEmpleado>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_perfil, nombre_Perfil FROM Perfil_Empleado", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PerfilEmpleado perfil = new PerfilEmpleado()
                        {
                            IdPerfil = reader.GetInt32(0),  // Asumiendo que id_perfil es el primer campo
                            NombrePerfil = reader.GetString(1)  // Asumiendo que nombre_Perfil es el segundo campo
                        };

                        perfiles.Add(perfil);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores relacionados con SQL
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;  // Lanza la excepción nuevamente para que pueda ser manejada en niveles superiores si es necesario
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return perfiles;
        }
        public string ObtenerNombrePerfil(int idPerfil)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT nombre_Perfil FROM Perfil_Empleado WHERE id_Perfil = @IdPerfil", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPerfil", idPerfil);

                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? resultado.ToString() : "Desconocido"; // Devuelve "Desconocido" si no encuentra el perfil.
                }
            }
        }
    }
}
