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
    public class UsuarioDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public bool AsignarUsuarioAEmpleado(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Usuario (cuil_Empleado, password_Usuario) VALUES (@CuilEmpleado, @PasswordUsuario)", conn);

                    cmd.Parameters.AddWithValue("@CuilEmpleado", usuario.CuilEmpleado);
                    cmd.Parameters.AddWithValue("@PasswordUsuario", usuario.PassswordUsuario);

                    cmd.ExecuteNonQuery();
                }
                return true; // Asignación exitosa
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"
                        SELECT 
                            u.id_Usuario, 
                            u.cuil_Empleado, 
                            u.password_Usuario,
                            e.dni_Empleado,
                            e.nombre_Empleado,
                            e.apellido_Empleado,
                            e.email_Empleado
                        FROM 
                            Usuario u
                        INNER JOIN Empleado e ON u.cuil_Empleado = e.cuil_Empleado", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            // Crear el objeto Empleado y llenarlo con los datos de la tabla Empleado
                            Empleado empleado = new Empleado
                            {
                                CUIL = reader.GetString(reader.GetOrdinal("cuil_Empleado")),
                                DNI = reader.GetString(reader.GetOrdinal("dni_Empleado")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre_Empleado")),
                                Apellido = reader.GetString(reader.GetOrdinal("apellido_Empleado")),
                                Email = reader.GetString(reader.GetOrdinal("email_Empleado"))
                            };

                            // Crear el objeto Usuario y asociarle el Empleado creado anteriormente
                            Usuario usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt32(reader.GetOrdinal("id_Usuario")),
                                CuilEmpleado = reader.GetString(reader.GetOrdinal("cuil_Empleado")),
                                PassswordUsuario = reader.GetString(reader.GetOrdinal("password_Usuario")),
                                Empleado = empleado // Asociar el empleado al usuario
                            };

                            usuarios.Add(usuario);
                        }
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
            return usuarios;
        }

        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = @"
                        SELECT u.id_Usuario, u.cuil_Empleado, u.password_Usuario,
                               e.dni_Empleado, e.nombre_Empleado, e.apellido_Empleado, e.email_Empleado, e.cuil_Empleado,
                               pr.nombre_Perfil
                        FROM Usuario u
                        INNER JOIN Empleado e ON u.cuil_Empleado = e.cuil_Empleado
                        INNER JOIN Perfil_Empleado pr ON e.id_perfil = pr.id_Perfil
                        WHERE u.id_Usuario = @IdUsuario";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = (int)reader["id_Usuario"],
                        CuilEmpleado = reader["cuil_Empleado"].ToString(),
                        PassswordUsuario = reader["password_Usuario"].ToString(),
                        Empleado = new Empleado
                        {
                            DNI = reader["dni_Empleado"].ToString(),
                            Nombre = reader["nombre_Empleado"].ToString(),
                            Apellido = reader["apellido_Empleado"].ToString(),
                            Email = reader["email_Empleado"].ToString(),
                            CUIL = reader["cuil_Empleado"].ToString()
                        },
                        PerfilNombre = reader["nombre_Perfil"].ToString()
                    };
                }
                return null;
            }
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"UPDATE Usuario 
                              SET cuil_Empleado = @CuilEmpleado, 
                                  password_Usuario = @PasswordUsuario 
                              WHERE id_Usuario = @IdUsuario", conn);

                    // Agrega los parámetros
                    cmd.Parameters.AddWithValue("@CuilEmpleado", usuario.CuilEmpleado ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PasswordUsuario", usuario.PassswordUsuario ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

                    // Ejecuta la consulta
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Verifica si se actualizó alguna fila
                    if (filasAfectadas > 0)
                    {
                        return true; // Éxito
                    }
                    else
                    {
                        Console.WriteLine("No se actualizó ninguna fila. Verifica el idUsuario.");
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool EliminarUsuario(int idUsuario)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"DELETE FROM Usuario WHERE id_Usuario = @IdUsuario", conn);

                    // Agrega el parámetro
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                    // Ejecuta la consulta
                    int filasAfectadas = cmd.ExecuteNonQuery();

                    // Verifica si se eliminó alguna fila
                    if (filasAfectadas > 0)
                    {
                        return true; // Eliminación exitosa
                    }
                    else
                    {
                        Console.WriteLine("No se eliminó ninguna fila. Verifica el idUsuario.");
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public List<Usuario> FiltrarUsuarios(string texto)
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Consulta SQL con filtro
                    SqlCommand cmd = new SqlCommand(@"
                        SELECT u.id_Usuario, 
                               u.cuil_Empleado, 
                               u.password_Usuario,
                               e.dni_Empleado,
                               e.nombre_Empleado,
                               e.apellido_Empleado,
                               e.email_Empleado,
                               pr.nombre_Perfil AS PerfilNombre
                        FROM Usuario u
                        INNER JOIN Empleado e ON u.cuil_Empleado = e.cuil_Empleado
                        INNER JOIN Perfil_Empleado pr ON e.id_perfil = pr.id_Perfil
                        WHERE u.cuil_Empleado LIKE @texto
                           OR e.dni_Empleado LIKE @texto
                           OR e.nombre_Empleado LIKE @texto
                           OR e.apellido_Empleado LIKE @texto
                           OR e.email_Empleado LIKE @texto", conn);

                    cmd.Parameters.AddWithValue("@texto", $"%{texto}%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Crear y llenar el objeto Empleado
                            Empleado empleado = new Empleado
                            {
                                CUIL = reader.GetString(reader.GetOrdinal("cuil_Empleado")),
                                DNI = reader.GetString(reader.GetOrdinal("dni_Empleado")),
                                Nombre = reader.GetString(reader.GetOrdinal("nombre_Empleado")),
                                Apellido = reader.GetString(reader.GetOrdinal("apellido_Empleado")),
                                Email = reader.GetString(reader.GetOrdinal("email_Empleado"))
                            };

                            // Crear y llenar el objeto Usuario
                            Usuario usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt32(reader.GetOrdinal("id_Usuario")),
                                CuilEmpleado = reader.GetString(reader.GetOrdinal("cuil_Empleado")),
                                PassswordUsuario = reader.GetString(reader.GetOrdinal("password_Usuario")),
                                Empleado = empleado,
                                PerfilNombre = reader.GetString(reader.GetOrdinal("PerfilNombre"))
                            };

                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return usuarios;
        }
    }
}
