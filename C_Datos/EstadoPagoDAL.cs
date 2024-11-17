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
    public class EstadoPagoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;


        // Método para obtener la lista de perfiles
        public List<EstadoPago> ObtenerTipoPago()
        {
            List<EstadoPago> estadosPago = new List<EstadoPago>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_EstadoPago, nombre_EstadoPago FROM Estado_Pago", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EstadoPago estadoPago = new EstadoPago()
                        {
                            IdEstadoPago = reader.GetInt32(0),
                            NombreEstadoPago = reader.GetString(1)
                        };

                        estadosPago.Add(estadoPago);
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

            return estadosPago;
        }
    }
}
