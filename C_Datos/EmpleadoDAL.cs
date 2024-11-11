using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using AgMaGest.C_Logica.Entidades;
using System.Security.Cryptography;
using System.Text;

namespace AgMaGest.C_Datos
{
    public class EmpleadoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para insertar un nuevo empleado en la base de datos
        public bool InsertarEmpleado(Empleado empleado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Empleado (cuil_Empleado, dni_Empleado, nombre_Empleado, apellido_Empleado, email_Empleado, celular_Empleado, " +
                        "fechaNac_Empleado, calle_Empleado, num_Calle_Empleado, piso_Empleado, dpto_Empleado, codigo_PostalEmpleado, id_Localidad, id_perfil, id_Estado) " +
                        "VALUES (@CUIL, @DNI, @Nombre, @Apellido, @Email, @Celular, @FechaNacimiento, @Calle, @NumeroCalle, @Piso, @Dpto, @CodigoPostal, @IdLocalidad, @IdPerfil, @IdEstado)", conn);


                    // Añadir los parámetros al comando SQL
                    cmd.Parameters.AddWithValue("@CUIL", empleado.CUIL);
                    cmd.Parameters.AddWithValue("@DNI", empleado.DNI);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Email", empleado.Email);
                    cmd.Parameters.AddWithValue("@Celular", empleado.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Calle", empleado.Calle);
                    cmd.Parameters.AddWithValue("@NumeroCalle", empleado.NumeroCalle);
                    cmd.Parameters.AddWithValue("@Piso", empleado.Piso);
                    cmd.Parameters.AddWithValue("@Dpto", empleado.Dpto);
                    cmd.Parameters.AddWithValue("@CodigoPostal", empleado.CodigoPostal);
                    cmd.Parameters.AddWithValue("@IdLocalidad", empleado.IdLocalidad);
                    cmd.Parameters.AddWithValue("@IdPerfil", empleado.IdPerfil);
                    cmd.Parameters.AddWithValue("@IdEstado", empleado.IdEstado);

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
                    throw new Exception("Ya existe un empleado con este DNI, CUIL o email.");
                }
                throw;
            }
        }

        // Método para actualizar un empleado existente
        public bool ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE Empleado SET cuil_Empleado = @CUIL, dni_Empleado = @DNI, nombre_Empleado = @Nombre, apellido_Empleado = @Apellido, " +
                        "email_Empleado = @Email, celular_Empleado = @Celular, fechaNac_Empleado = @FechaNacimiento, calle_Empleado = @Calle, " +
                        "num_Calle_Empleado = @NumeroCalle, piso_Empleado = @Piso, dpto_Empleado = @Dpto, codigo_PostalEmpleado = @CodigoPostal, " +
                        "id_Localidad = @IdLocalidad, id_perfil = @IdPerfil, id_Estado = @IdEstado WHERE cuil_Empleado = @CUIL", conn);

                    cmd.Parameters.AddWithValue("@CUIL", empleado.CUIL);
                    cmd.Parameters.AddWithValue("@DNI", empleado.DNI);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Email", empleado.Email);
                    cmd.Parameters.AddWithValue("@Celular", empleado.Celular);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", empleado.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Calle", empleado.Calle);
                    cmd.Parameters.AddWithValue("@NumeroCalle", empleado.NumeroCalle);
                    cmd.Parameters.AddWithValue("@Piso", empleado.Piso);
                    cmd.Parameters.AddWithValue("@Dpto", empleado.Dpto);
                    cmd.Parameters.AddWithValue("@CodigoPostal", empleado.CodigoPostal);
                    cmd.Parameters.AddWithValue("@IdLocalidad", empleado.IdLocalidad);
                    cmd.Parameters.AddWithValue("@IdPerfil", empleado.IdPerfil);
                    cmd.Parameters.AddWithValue("@IdEstado", empleado.IdEstado);

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

        // Método para eliminar un empleado por ID
        public bool EliminarEmpleado(string cuil)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Empleado WHERE cuil_Empleado = @CUIL", conn);
                    cmd.Parameters.AddWithValue("@CUIL", cuil);

                    cmd.ExecuteNonQuery();
                }

                return true; // Eliminación exitosa
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
        }

        // Método para obtener un empleado por su CUIL
        public Empleado ObtenerEmpleadoPorCUIL(string cuil)
        {
            Empleado empleado = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            e.cuil_Empleado, e.dni_Empleado, e.nombre_Empleado, e.apellido_Empleado,
                            e.email_Empleado, e.celular_Empleado, e.fechaNac_Empleado, 
                            e.calle_Empleado, e.num_Calle_Empleado, e.piso_Empleado, e.dpto_Empleado,
                            e.codigo_PostalEmpleado, e.id_Localidad, e.id_perfil, e.id_Estado,
                            l.nombre_Localidad, p.nombre_Provincia
                        FROM Empleado e
                        INNER JOIN Localidad l ON e.id_Localidad = l.id_Localidad
                        INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                        WHERE e.cuil_Empleado = @CUIL";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CUIL", cuil);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            empleado = new Empleado
                            {
                                CUIL = reader.GetString(0),
                                DNI = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                Apellido = reader.GetString(3),
                                Email = reader.GetString(4),
                                Celular = reader.GetString(5),
                                FechaNacimiento = reader.GetDateTime(6),
                                Calle = reader.GetString(7),
                                NumeroCalle = reader.GetInt32(8),
                                Piso = reader.IsDBNull(9) ? (int?)null : reader.GetInt32(9),
                                Dpto = reader.IsDBNull(10) ? null : reader.GetString(10),
                                CodigoPostal = reader.GetInt32(11),
                                IdLocalidad = reader.GetInt32(12),
                                IdPerfil = reader.GetInt32(13),
                                IdEstado = reader.GetInt32(14),
                                LocalidadNombre = reader.GetString(15),  // Nombre de la Localidad
                                ProvinciaNombre = reader.GetString(16)  // Nombre de la Provincia
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

            return empleado;
        }


        public List<Empleado> ObtenerTodosLosEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL con joins para obtener localidad, provincia, país, estado, perfil y dirección completa
                    SqlCommand cmd = new SqlCommand(@"
                        SELECT e.cuil_Empleado, e.dni_Empleado, e.nombre_Empleado, e.apellido_Empleado, e.email_Empleado, 
                               e.celular_Empleado, e.fechaNac_Empleado, 
                               e.calle_Empleado AS Calle, e.num_Calle_Empleado AS NumeroCalle, 
                               e.piso_Empleado AS Piso, e.dpto_Empleado AS Dpto,
                               e.codigo_PostalEmpleado AS CodigoPostal,
                               l.nombre_Localidad AS LocalidadNombre, 
                               p.nombre_Provincia AS ProvinciaNombre, 
                               pa.nombre_Pais AS PaisNombre,
                               pr.nombre_Perfil AS PerfilNombre,
                               es.nombre_EstadoEmpleado AS EstadoNombre
                        FROM Empleado e
                        INNER JOIN Localidad l ON e.id_Localidad = l.id_Localidad
                        INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                        INNER JOIN Pais pa ON p.id_Pais = pa.id_Pais
                        INNER JOIN Perfil_Empleado pr ON e.id_perfil = pr.id_Perfil
                        INNER JOIN Estado_Empleado es ON e.id_Estado = es.id_EstadoEmpleado", conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado
                            {
                                CUIL = reader.GetString(0),
                                DNI = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                Apellido = reader.GetString(3),
                                Email = reader.GetString(4),
                                Celular = reader.GetString(5),
                                FechaNacimiento = reader.GetDateTime(6),

                                // Campos de dirección
                                Calle = reader.GetString(7),
                                NumeroCalle = reader.GetInt32(8),
                                Piso = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                                Dpto = reader.IsDBNull(10) ? null : reader.GetString(10),

                                CodigoPostal = reader.IsDBNull(11) ? 0 : reader.GetInt32(11),

                                // Otros campos
                                LocalidadNombre = reader.GetString(12),
                                ProvinciaNombre = reader.GetString(13),
                                PaisNombre = reader.GetString(14),
                                PerfilNombre = reader.GetString(15),
                                EstadoNombre = reader.GetString(16)
                            };

                            empleados.Add(empleado);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return empleados;
        }

        public List<Empleado> FiltrarEmpleados(string texto)
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    // Consulta SQL con joins y filtro
                    SqlCommand cmd = new SqlCommand(@"
                        SELECT e.cuil_Empleado, e.dni_Empleado, e.nombre_Empleado, e.apellido_Empleado, e.email_Empleado, 
                               e.celular_Empleado, e.fechaNac_Empleado, 
                               e.calle_Empleado AS Calle, e.num_Calle_Empleado AS NumeroCalle, 
                               e.piso_Empleado AS Piso, e.dpto_Empleado AS Dpto,
                               e.codigo_PostalEmpleado AS CodigoPostal,
                               l.nombre_Localidad AS LocalidadNombre, 
                               p.nombre_Provincia AS ProvinciaNombre, 
                               pa.nombre_Pais AS PaisNombre,
                               pr.nombre_Perfil AS PerfilNombre,
                               es.nombre_EstadoEmpleado AS EstadoNombre
                        FROM Empleado e
                        INNER JOIN Localidad l ON e.id_Localidad = l.id_Localidad
                        INNER JOIN Provincia p ON l.id_Provincia = p.id_Provincia
                        INNER JOIN Pais pa ON p.id_Pais = pa.id_Pais
                        INNER JOIN Perfil_Empleado pr ON e.id_perfil = pr.id_Perfil
                        INNER JOIN Estado_Empleado es ON e.id_Estado = es.id_EstadoEmpleado
                        WHERE e.cuil_Empleado LIKE @texto
                           OR e.dni_Empleado LIKE @texto
                           OR e.nombre_Empleado LIKE @texto
                           OR e.apellido_Empleado LIKE @texto
                           OR e.email_Empleado LIKE @texto", conn);

                            cmd.Parameters.AddWithValue("@texto", $"%{texto}%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado empleado = new Empleado
                            {
                                CUIL = reader.GetString(0),
                                DNI = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                Apellido = reader.GetString(3),
                                Email = reader.GetString(4),
                                Celular = reader.GetString(5),
                                FechaNacimiento = reader.GetDateTime(6),

                                // Campos de dirección
                                Calle = reader.GetString(7),
                                NumeroCalle = reader.GetInt32(8),
                                Piso = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                                Dpto = reader.IsDBNull(10) ? null : reader.GetString(10),

                                CodigoPostal = reader.IsDBNull(11) ? 0 : reader.GetInt32(11),

                                // Otros campos
                                LocalidadNombre = reader.GetString(12),
                                ProvinciaNombre = reader.GetString(13),
                                PaisNombre = reader.GetString(14),
                                PerfilNombre = reader.GetString(15),
                                EstadoNombre = reader.GetString(16)
                            };

                            empleados.Add(empleado);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return empleados;
        }        
    }
}