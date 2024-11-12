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
    public class ClienteEmpresaDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para obtener todos los clientes empresa
        public List<ClienteEmpresa> ObtenerClientesEmpresa()
        {
            List<ClienteEmpresa> clientesEmpresa = new List<ClienteEmpresa>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente_Empresa", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ClienteEmpresa clienteEmpresa = new ClienteEmpresa
                        {
                            IdCEmpresa = reader.GetInt32(0),
                            CuitCEmpresa = reader.GetString(1),
                            RazonSocialCEmpresa = reader.GetString(2),
                            IdCliente = reader.GetInt32(3)
                        };
                        clientesEmpresa.Add(clienteEmpresa);
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

            return clientesEmpresa;
        }



        // Método para actualizar un cliente empresa existente
        public bool ActualizarClienteEmpresa(ClienteEmpresa clienteEmpresa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Cliente_Empresa SET razon_Social_CEmpresa = @RazonSocial, celular_Cliente = @Telefono, " +
                        "email_Cliente = @Email, calle_Cliente = @Calle, num_Calle = @NumeroCalle, " +
                        "piso_Cliente = @Piso, dpto_Cliente = @Dpto, codigo_PostalCliente = @CodigoPostal, " +
                        "id_Localidad = @IdLocalidad, id_Estado_Cliente = @IdEstado WHERE cuit_CEmpresa = @CUIT", conn);

                    cmd.Parameters.AddWithValue("@CUIT", clienteEmpresa.CuitCEmpresa);
                    cmd.Parameters.AddWithValue("@RazonSocial", clienteEmpresa.RazonSocialCEmpresa);
                    cmd.Parameters.AddWithValue("@Telefono", clienteEmpresa.CelularCliente);
                    cmd.Parameters.AddWithValue("@Email", clienteEmpresa.EmailCliente);
                    cmd.Parameters.AddWithValue("@Calle", clienteEmpresa.CalleCliente);
                    cmd.Parameters.AddWithValue("@NumeroCalle", clienteEmpresa.NumCalle);
                    cmd.Parameters.AddWithValue("@Piso", clienteEmpresa.PisoCliente);
                    cmd.Parameters.AddWithValue("@Dpto", clienteEmpresa.DptoCliente);
                    cmd.Parameters.AddWithValue("@CodigoPostal", clienteEmpresa.CodigoPostalCliente);
                    cmd.Parameters.AddWithValue("@IdLocalidad", clienteEmpresa.IdLocalidad);
                    cmd.Parameters.AddWithValue("@IdEstado", clienteEmpresa.IdEstadoCliente);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
        }


        // Método para eliminar un cliente empresa por ID
        public bool EliminarClienteEmpresa(int idCEmpresa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Cliente_Empresa WHERE id_CEmpresa = @IdCEmpresa", conn);
                    cmd.Parameters.AddWithValue("@IdCEmpresa", idCEmpresa);

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

        public ClienteEmpresa ObtenerClienteEmpresaPorCUIT(string cuit)
        {
            ClienteEmpresa clienteEmpresa = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    ce.cuit_CEmpresa, ce.razon_Social_CEmpresa,
                    c.email_Cliente, c.celular_Cliente, 
                    c.calle_Cliente, c.num_Calle, c.piso_Cliente, c.dpto_Cliente,
                    c.codigo_PostalCliente, c.id_Localidad, c.id_Estado_Cliente,
                    l.nombre_Localidad, p.nombre_Provincia
                FROM Cliente_Empresa ce
                INNER JOIN Cliente c ON ce.id_Cliente = c.id_Cliente
                INNER JOIN Localidad l ON c.id_Localidad = l.id_Localidad
                INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                WHERE ce.cuit_CEmpresa = @CUIT";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CUIT", cuit);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            clienteEmpresa = new ClienteEmpresa
                            {
                                CuitCEmpresa = reader.GetString(0),
                                RazonSocialCEmpresa = reader.GetString(1),
                                EmailCliente = reader.GetString(2),
                                CelularCliente = reader.GetString(3),
                                CalleCliente = reader.GetString(4),
                                NumCalle = reader.GetInt32(5),
                                PisoCliente = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6),
                                DptoCliente = reader.IsDBNull(7) ? null : reader.GetString(7),
                                CodigoPostalCliente = reader.GetInt32(8),
                                IdLocalidad = reader.GetInt32(9),
                                IdEstadoCliente = reader.GetInt32(10),
                                LocalidadNombre = reader.GetString(11),  // Nombre de la Localidad
                                ProvinciaNombre = reader.GetString(12)  // Nombre de la Provincia
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

            return clienteEmpresa;
        }

    }
}

