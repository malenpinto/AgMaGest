using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using AgMaGest.C_Logica.Entidades;
using System.Security.Cryptography;

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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Empleado WHERE cuil_Empleado = @CUIL", conn);
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
                                IdEstado = reader.GetInt32(14)
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
    }
}