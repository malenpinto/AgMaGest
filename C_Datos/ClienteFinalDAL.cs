using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class ClienteFinalDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para obtener todos los clientes finales
        public List<ClienteFinal> ObtenerClientesFinales()
        {
            List<ClienteFinal> clientesFinales = new List<ClienteFinal>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente_Final", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteFinal clienteFinal = new ClienteFinal
                        {
                            IdClienteFinal = reader.GetInt32(0),
                            NombreCFinal = reader.GetString(1),
                            ApellidoCFinal = reader.GetString(2),
                            DniCFinal = reader.GetString(3),
                            CuilCFinal = reader.GetString(4),
                            FechaNacCFinal = reader.GetDateTime(5),
                            IdCliente = reader.GetInt32(6)
                        };
                        clientesFinales.Add(clienteFinal);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return clientesFinales;
        }

        // Método para obtener un cliente final por ID
        public ClienteFinal ObtenerClienteFinalPorId(int idClienteFinal)
        {
            ClienteFinal clienteFinal = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Cliente_Final WHERE id_ClienteFinal = @idClienteFinal", connection);
                command.Parameters.AddWithValue("@idClienteFinal", idClienteFinal);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        clienteFinal = new ClienteFinal
                        {
                            IdClienteFinal = reader.GetInt32(0),
                            NombreCFinal = reader.GetString(1),
                            ApellidoCFinal = reader.GetString(2),
                            DniCFinal = reader.GetString(3),
                            CuilCFinal = reader.GetString(4),
                            FechaNacCFinal = reader.GetDateTime(5),
                            IdCliente = reader.GetInt32(6)
                        };
                    }
                }
            }
            return clienteFinal;
        }

        // Método para actualizar un cliente final existente
        public bool ActualizarClienteFinal(ClienteFinal clienteFinal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Cliente_Final SET nombre_CFinal = @Nombre, apellido_CFinal = @Apellido, dni_CFinal = @DNI, " +
                        "cuil_CFinal = @CUIL, fechaNac_CFinal = @FechaNac, id_Cliente = @IdCliente WHERE id_ClienteFinal = @IdClienteFinal", conn);

                    // Añadir los parámetros al comando SQL
                    cmd.Parameters.AddWithValue("@Nombre", clienteFinal.NombreCFinal);
                    cmd.Parameters.AddWithValue("@Apellido", clienteFinal.ApellidoCFinal);
                    cmd.Parameters.AddWithValue("@DNI", clienteFinal.DniCFinal);
                    cmd.Parameters.AddWithValue("@CUIL", clienteFinal.CuilCFinal);
                    cmd.Parameters.AddWithValue("@FechaNac", clienteFinal.FechaNacCFinal);
                    cmd.Parameters.AddWithValue("@IdCliente", clienteFinal.IdCliente);
                    cmd.Parameters.AddWithValue("@IdClienteFinal", clienteFinal.IdClienteFinal);

                    // Ejecutar el comando de actualización
                    cmd.ExecuteNonQuery();
                }

                return true; // Actualización exitosa
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

        // Método para eliminar un cliente final por ID
        public bool EliminarClienteFinal(int idClienteFinal)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Cliente_Final WHERE id_ClienteFinal = @IdClienteFinal", conn);
                    cmd.Parameters.AddWithValue("@IdClienteFinal", idClienteFinal);

                    // Ejecutar el comando de eliminación
                    cmd.ExecuteNonQuery();
                }

                return true; // Eliminación exitosa
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
        }

    }
}
