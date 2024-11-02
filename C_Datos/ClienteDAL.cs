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
    public class ClienteDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para obtener todos los clientes
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente()
                        {
                            IdCliente = reader.GetInt32(0),
                            EmailCliente = reader.GetString(1),
                            CelularCliente = reader.GetString(2),
                            CalleCliente = reader.GetString(3),
                            NumCalle = reader.GetInt32(4),
                            PisoCliente = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                            DptoCliente = reader.IsDBNull(6) ? null : reader.GetString(6),
                            CodigoPostalCliente = reader.GetInt32(7),
                            IdEstadoCliente = reader.GetInt32(8),
                            IdLocalidad = reader.GetInt32(9)
                        };
                        clientes.Add(cliente);
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

            return clientes;
        }

        // Método para obtener un cliente por ID
        public Cliente ObtenerClientePorId(int idCliente)
        {
            Cliente cliente = null;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM Cliente WHERE id_Cliente = @idCliente", connection);
                command.Parameters.AddWithValue("@idCliente", idCliente);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        cliente = new Cliente
                        {
                            IdCliente = reader.GetInt32(0),
                            EmailCliente = reader.GetString(1),
                            CelularCliente = reader.GetString(2),
                            CalleCliente = reader.GetString(3),
                            NumCalle = reader.GetInt32(4),
                            PisoCliente = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5),
                            DptoCliente = reader.GetString(6),
                            CodigoPostalCliente = reader.GetInt32(7),
                            IdEstadoCliente = reader.GetInt32(8),
                            IdLocalidad = reader.GetInt32(9)
                        };
                    }
                }
            }
            return cliente;
        }

        // Método para insertar un nuevo cliente
        public bool InsertarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Cliente (email_Cliente, celular_Cliente, calle_Cliente, num_Calle, piso_Cliente, dpto_Cliente, " +
                        "codigo_PostalCliente, id_Estado_Cliente, id_Localidad) " +
                        "VALUES (@Email, @Celular, @Calle, @NumCalle, @Piso, @Dpto, @CodigoPostal, @Estado, @Localidad)", conn);

                    // Añadir los parámetros al comando SQL
                    cmd.Parameters.AddWithValue("@Email", cliente.EmailCliente);
                    cmd.Parameters.AddWithValue("@Celular", cliente.CelularCliente);
                    cmd.Parameters.AddWithValue("@Calle", cliente.CalleCliente);
                    cmd.Parameters.AddWithValue("@NumCalle", cliente.NumCalle);
                    cmd.Parameters.AddWithValue("@Piso", cliente.PisoCliente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Dpto", cliente.DptoCliente ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CodigoPostal", cliente.CodigoPostalCliente);
                    cmd.Parameters.AddWithValue("@Estado", cliente.IdEstadoCliente);
                    cmd.Parameters.AddWithValue("@Localidad", cliente.IdLocalidad);

                    // Ejecutar el comando de inserción
                    cmd.ExecuteNonQuery();
                }

                return true; // Inserción exitosa
            }
            catch (SqlException ex)
            {
                // Verificar si el error es por duplicado (clave única violada)
                if (ex.Number == 2627 || ex.Number == 2601) // Violación de índice único
                {
                    throw new Exception("Ya existe un cliente con este email o número de celular.");
                }
                throw;
            }
        }

        // Método para actualizar un cliente existente
        public void ActualizarCliente(Cliente cliente)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE Cliente SET email_Cliente = @Email, celular_Cliente = @Celular, calle_Cliente = @Calle, num_Calle = @NumCalle, piso_Cliente = @Piso, dpto_Cliente = @Dpto, " +
                                                    "codigo_PostalCliente = @CodigoPostal, id_Estado_Cliente = @Estado, id_Localidad = @Localidad WHERE id_Cliente = @Id", connection);

                command.Parameters.AddWithValue("@Email", cliente.EmailCliente);
                command.Parameters.AddWithValue("@Celular", cliente.CelularCliente);
                command.Parameters.AddWithValue("@Calle", cliente.CalleCliente);
                command.Parameters.AddWithValue("@NumCalle", cliente.NumCalle);
                command.Parameters.AddWithValue("@Piso", cliente.PisoCliente ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Dpto", cliente.DptoCliente);
                command.Parameters.AddWithValue("@CodigoPostal", cliente.CodigoPostalCliente);
                command.Parameters.AddWithValue("@Estado", cliente.IdEstadoCliente);
                command.Parameters.AddWithValue("@Localidad", cliente.IdLocalidad);
                command.Parameters.AddWithValue("@Id", cliente.IdCliente);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Método para eliminar un cliente por ID
        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Cliente WHERE id_Cliente = @Id", connection);
                command.Parameters.AddWithValue("@Id", idCliente);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
