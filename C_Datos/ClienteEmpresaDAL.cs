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

        // Método para insertar un nuevo cliente empresa
        public bool InsertarClienteEmpresa(ClienteEmpresa clienteEmpresa)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Cliente_Empresa (cuit_CEmpresa, razon_Social_CEmpresa, id_Cliente) " +
                        "VALUES (@Cuit, @RazonSocial, @IdCliente)", conn);

                    // Añadir los parámetros al comando SQL
                    cmd.Parameters.AddWithValue("@Cuit", clienteEmpresa.CuitCEmpresa);
                    cmd.Parameters.AddWithValue("@RazonSocial", clienteEmpresa.RazonSocialCEmpresa);
                    cmd.Parameters.AddWithValue("@IdCliente", clienteEmpresa.IdCliente);

                    cmd.ExecuteNonQuery();
                }

                return true; // Inserción exitosa
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601) // Violación de índice único
                {
                    throw new Exception("Ya existe un cliente empresa con este CUIT.");
                }
                throw;
            }
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
                        "UPDATE Cliente_Empresa SET cuit_CEmpresa = @Cuit, razon_Social_CEmpresa = @RazonSocial, " +
                        "id_Cliente = @IdCliente WHERE id_CEmpresa = @IdCEmpresa", conn);

                    cmd.Parameters.AddWithValue("@Cuit", clienteEmpresa.CuitCEmpresa);
                    cmd.Parameters.AddWithValue("@RazonSocial", clienteEmpresa.RazonSocialCEmpresa);
                    cmd.Parameters.AddWithValue("@IdCliente", clienteEmpresa.IdCliente);
                    cmd.Parameters.AddWithValue("@IdCEmpresa", clienteEmpresa.IdCEmpresa);

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
    }
}

