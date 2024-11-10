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
    public class EstadoEmpleadoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public List<EstadoEmpleado> ObtenerEstadoEmpleado()
        {
            List<EstadoEmpleado> estados = new List<EstadoEmpleado>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_EstadoEmpleado, nombre_EstadoEmpleado FROM Estado_Empleado", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EstadoEmpleado estado = new EstadoEmpleado()
                        {
                            IdEstadoEmpleado = reader.GetInt32(0),
                            NombreEstadoEmpleado = reader.GetString(1)
                        };

                        estados.Add(estado);
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

            return estados;
        }
        public string ObtenerNombreEstado(int idEstado)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT nombre_EstadoEmpleado FROM Estado_Empleado WHERE id_EstadoEmpleado = @IdEstado", conn))
                {
                    cmd.Parameters.AddWithValue("@IdEstado", idEstado);

                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? resultado.ToString() : "Desconocido"; // Devuelve "Desconocido" si no encuentra el estado.
                }
            }
        }

    }
}

