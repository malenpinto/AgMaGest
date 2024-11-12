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

        public ClienteFinal ObtenerClienteFinalPorCUIL(string cuil)
        {
            ClienteFinal clienteFinal = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    cf.cuil_CFinal, cf.dni_CFinal, cf.nombre_CFinal, cf.apellido_CFinal,
                    cf.fechaNac_CFinal, c.email_Cliente, c.celular_Cliente, 
                    c.calle_Cliente, c.num_Calle, c.piso_Cliente, c.dpto_Cliente,
                    c.codigo_PostalCliente, c.id_Localidad, c.id_Estado_Cliente,
                    l.nombre_Localidad, p.nombre_Provincia
                FROM Cliente_Final cf
                INNER JOIN Cliente c ON cf.id_Cliente = c.id_Cliente
                INNER JOIN Localidad l ON c.id_Localidad = l.id_Localidad
                INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                WHERE cf.cuil_CFinal = @CUIL";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CUIL", cuil);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clienteFinal = new ClienteFinal
                            {
                                CuilCFinal = reader.GetString(0),
                                DniCFinal = reader.GetString(1),
                                NombreCFinal = reader.GetString(2),
                                ApellidoCFinal = reader.GetString(3),
                                FechaNacCFinal = reader.GetDateTime(4),
                                EmailCliente = reader.GetString(5),
                                CelularCliente = reader.GetString(6),
                                CalleCliente = reader.GetString(7),
                                NumCalle = reader.GetInt32(8),
                                PisoCliente = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9),
                                DptoCliente = reader.IsDBNull(10) ? null : reader.GetString(10),
                                CodigoPostalCliente = reader.GetInt32(11),
                                IdLocalidad = reader.GetInt32(12),
                                IdEstadoCliente = reader.GetInt32(13),
                                LocalidadNombre = reader.GetString(14),  // Nombre de la Localidad
                                ProvinciaNombre = reader.GetString(15)   // Nombre de la Provincia
                            };
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return clienteFinal;
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
