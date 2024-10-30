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
    public class TipoVehiculoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;


        // Método para obtener la lista de perfiles
        public List<TipoVehiculo> ObtenerTipoVehiculo()
        {
            List<TipoVehiculo> tiposVehiculo = new List<TipoVehiculo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_tipoVehiculo, nombre_tipoVehiculo FROM Tipo_Vehiculo", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoVehiculo tipoVehiculo = new TipoVehiculo()
                        {
                            IdTipoVehiculo = reader.GetInt32(0),
                            NombreTipoVehiculo = reader.GetString(1)
                        };

                        tiposVehiculo.Add(tipoVehiculo);
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

            return tiposVehiculo;
        }

    }
}
