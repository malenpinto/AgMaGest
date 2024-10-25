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
    public class CondicionVehiculoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public List<CondicionVehiculo> ObtenerEstadoVehiculo()
        {
            List<CondicionVehiculo> condiciones = new List<CondicionVehiculo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_Condicion, nombre_Condicion FROM Condicion", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        CondicionVehiculo condicion = new CondicionVehiculo()
                        {
                            IdCondicion = reader.GetInt32(0),
                            NombreCondicion = reader.GetString(1)
                        };

                        condiciones.Add(condicion);
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

            return condiciones;
        }
    }
}
