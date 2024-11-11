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

            // Obtener y añadir los clientes finales
            clientes.AddRange(ObtenerClientesFinales());

            // Obtener y añadir los clientes de empresa
            clientes.AddRange(ObtenerClientesEmpresas());

            return clientes;
        }

        private List<ClienteFinal> ObtenerClientesFinales()
        {
            List<ClienteFinal> clientesFinales = new List<ClienteFinal>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"
                SELECT c.id_Cliente, c.email_Cliente, c.celular_Cliente, 
                       c.calle_Cliente, c.num_Calle, c.piso_Cliente, 
                       c.dpto_Cliente, c.codigo_PostalCliente, 
                       l.nombre_Localidad AS LocalidadNombre, 
                       p.nombre_Provincia AS ProvinciaNombre, 
                       pa.nombre_Pais AS PaisNombre,
                       cf.dni_CFinal, cf.cuil_CFinal, cf.nombre_CFinal, 
                       cf.apellido_CFinal, cf.fechaNac_CFinal,
                       ec.nombre_EstadoCliente AS EstadoCliente
                FROM Cliente c
                INNER JOIN Cliente_Final cf ON c.id_Cliente = cf.id_Cliente
                INNER JOIN Localidad l ON c.id_Localidad = l.id_Localidad
                INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                INNER JOIN Pais pa ON p.id_Pais = pa.id_Pais
                INNER JOIN Estado_Cliente ec ON c.id_Estado_Cliente = ec.id_Estado_Cliente", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClienteFinal clienteFinal = new ClienteFinal
                            {
                                IdCliente = reader.GetInt32(reader.GetOrdinal("id_Cliente")),
                                EmailCliente = reader.GetString(reader.GetOrdinal("email_Cliente")),
                                CelularCliente = reader.GetString(reader.GetOrdinal("celular_Cliente")),
                                CalleCliente = reader.GetString(reader.GetOrdinal("calle_Cliente")),
                                NumCalle = reader.GetInt32(reader.GetOrdinal("num_Calle")),
                                PisoCliente = reader.IsDBNull(reader.GetOrdinal("piso_Cliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("piso_Cliente")),
                                DptoCliente = reader.IsDBNull(reader.GetOrdinal("dpto_Cliente")) ? null : reader.GetString(reader.GetOrdinal("dpto_Cliente")),
                                CodigoPostalCliente = reader.GetInt32(reader.GetOrdinal("codigo_PostalCliente")),
                                LocalidadNombre = reader.GetString(reader.GetOrdinal("LocalidadNombre")),
                                ProvinciaNombre = reader.GetString(reader.GetOrdinal("ProvinciaNombre")),
                                PaisNombre = reader.GetString(reader.GetOrdinal("PaisNombre")),
                                DniCFinal = reader.GetString(reader.GetOrdinal("dni_CFinal")),
                                CuilCFinal = reader.GetString(reader.GetOrdinal("cuil_CFinal")),
                                NombreCFinal = reader.GetString(reader.GetOrdinal("nombre_CFinal")),
                                ApellidoCFinal = reader.GetString(reader.GetOrdinal("apellido_CFinal")),
                                FechaNacCFinal = reader.GetDateTime(reader.GetOrdinal("fechaNac_CFinal")),
                                EstadoNombre = reader.GetString(reader.GetOrdinal("EstadoCliente"))
                            };
                            clientesFinales.Add(clienteFinal);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL al obtener clientes finales: {ex.Message}");
                throw;
            }

            return clientesFinales;
        }

        private List<ClienteEmpresa> ObtenerClientesEmpresas()
        {
            List<ClienteEmpresa> clientesEmpresas = new List<ClienteEmpresa>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(@"
                SELECT c.id_Cliente, c.email_Cliente, c.celular_Cliente, 
                       c.calle_Cliente, c.num_Calle, c.piso_Cliente, 
                       c.dpto_Cliente, c.codigo_PostalCliente, 
                       l.nombre_Localidad AS LocalidadNombre, 
                       p.nombre_Provincia AS ProvinciaNombre, 
                       pa.nombre_Pais AS PaisNombre,
                       ce.cuit_CEmpresa, ce.razon_Social_CEmpresa,
                       ec.nombre_EstadoCliente AS EstadoCliente
                FROM Cliente c
                INNER JOIN Cliente_Empresa ce ON c.id_Cliente = ce.id_Cliente
                INNER JOIN Localidad l ON c.id_Localidad = l.id_Localidad
                INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                INNER JOIN Pais pa ON p.id_Pais = pa.id_Pais
                INNER JOIN Estado_Cliente ec ON c.id_Estado_Cliente = ec.id_Estado_Cliente", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClienteEmpresa clienteEmpresa = new ClienteEmpresa
                            {
                                IdCliente = reader.GetInt32(reader.GetOrdinal("id_Cliente")),
                                EmailCliente = reader.GetString(reader.GetOrdinal("email_Cliente")),
                                CelularCliente = reader.GetString(reader.GetOrdinal("celular_Cliente")),
                                CalleCliente = reader.GetString(reader.GetOrdinal("calle_Cliente")),
                                NumCalle = reader.GetInt32(reader.GetOrdinal("num_Calle")),
                                PisoCliente = reader.IsDBNull(reader.GetOrdinal("piso_Cliente")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("piso_Cliente")),
                                DptoCliente = reader.IsDBNull(reader.GetOrdinal("dpto_Cliente")) ? null : reader.GetString(reader.GetOrdinal("dpto_Cliente")),
                                CodigoPostalCliente = reader.GetInt32(reader.GetOrdinal("codigo_PostalCliente")),
                                LocalidadNombre = reader.GetString(reader.GetOrdinal("LocalidadNombre")),
                                ProvinciaNombre = reader.GetString(reader.GetOrdinal("ProvinciaNombre")),
                                PaisNombre = reader.GetString(reader.GetOrdinal("PaisNombre")),
                                CuitCEmpresa = reader.GetString(reader.GetOrdinal("cuit_CEmpresa")),
                                RazonSocialCEmpresa = reader.GetString(reader.GetOrdinal("razon_Social_CEmpresa")),
                                EstadoNombre = reader.GetString(reader.GetOrdinal("EstadoCliente"))
                            };
                            clientesEmpresas.Add(clienteEmpresa);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL al obtener clientes empresas: {ex.Message}");
                throw;
            }

            return clientesEmpresas;
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

        public List<Cliente> FiltrarClientes(string texto)
        {
            List<Cliente> clientes = new List<Cliente>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL con joins y filtro
                    SqlCommand cmd = new SqlCommand(@"
                SELECT c.cuil_Cliente, c.dni_Cliente, c.nombre_Cliente, c.apellido_Cliente, c.razon_Social_Cliente, c.email_Cliente, 
                        c.celular_Cliente, c.fechaNac_Cliente, 
                        c.calle_Cliente AS Calle, c.num_Calle_Cliente AS NumeroCalle, 
                        c.piso_Cliente AS Piso, c.dpto_Cliente AS Dpto,
                        c.codigo_PostalCliente AS CodigoPostal,
                        l.nombre_Localidad AS LocalidadNombre, 
                        p.nombre_Provincia AS ProvinciaNombre, 
                        pa.nombre_Pais AS PaisNombre
                FROM Cliente c
                INNER JOIN Localidad l ON c.id_Localidad = l.id_Localidad
                INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                INNER JOIN Pais pa ON p.id_Pais = pa.id_Pais
                WHERE (c.cuil_Cliente LIKE @texto OR c.dni_Cliente LIKE @texto OR c.razon_Social_Cliente LIKE @texto)
                   OR c.nombre_Cliente LIKE @texto
                   OR c.apellido_Cliente LIKE @texto
                   OR c.email_Cliente LIKE @texto", conn);

                    cmd.Parameters.AddWithValue("@texto", $"%{texto}%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente cliente;

                            if (reader.IsDBNull(4))  // Si no tiene razón social, es un ClienteFinal
                            {
                                cliente = new ClienteFinal
                                {
                                    CuilCFinal = reader.GetString(0),
                                    DniCFinal = reader.GetString(1),
                                    NombreCFinal = reader.GetString(2),
                                    ApellidoCFinal = reader.GetString(3),
                                    EmailCliente = reader.GetString(5),
                                    CelularCliente = reader.GetString(6),
                                    FechaNacCFinal = reader.GetDateTime(7),

                                    // Campos de dirección
                                    CalleCliente = reader.GetString(8),
                                    NumCalle = reader.GetInt32(9),
                                    PisoCliente = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                                    DptoCliente = reader.IsDBNull(11) ? null : reader.GetString(11),
                                    CodigoPostalCliente = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                                    LocalidadNombre = reader.GetString(13),
                                    ProvinciaNombre = reader.GetString(14),
                                    PaisNombre = reader.GetString(15)
                                };
                            }
                            else  // Si tiene razón social, es un ClienteEmpresa
                            {
                                cliente = new ClienteEmpresa
                                {
                                    CuitCEmpresa = reader.GetString(0),
                                    RazonSocialCEmpresa = reader.GetString(4), // Razón social
                                    EmailCliente = reader.GetString(5),
                                    CelularCliente = reader.GetString(6),

                                    // Campos de dirección
                                    CalleCliente = reader.GetString(8),
                                    NumCalle = reader.GetInt32(9),
                                    PisoCliente = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                                    DptoCliente = reader.IsDBNull(11) ? null : reader.GetString(11),
                                    CodigoPostalCliente = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                                    LocalidadNombre = reader.GetString(13),
                                    ProvinciaNombre = reader.GetString(14),
                                    PaisNombre = reader.GetString(15)
                                };
                            }

                            clientes.Add(cliente);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return clientes;
        }

    }
}
