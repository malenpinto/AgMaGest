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
    public class EstadoVehiculoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public List<EstadoVehiculo> ObtenerEstadoVehiculo()
        {
            List<EstadoVehiculo> estados = new List<EstadoVehiculo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_Estado, nombre_Estado FROM Estado_Vehiculo", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EstadoVehiculo estado = new EstadoVehiculo()
                        {
                            IdEstado = reader.GetInt32(0),
                            NombreEstado = reader.GetString(1)
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
    }
}
