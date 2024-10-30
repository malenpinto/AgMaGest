using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class EmpleadoDAL
    {

        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;


        // Método para obtener la lista de perfiles
        public List<PerfilEmpleado> ObtenerPerfiles()
        {
            List<PerfilEmpleado> perfiles = new List<PerfilEmpleado>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_perfil, nombre_Perfil FROM Perfil_Empleado", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        PerfilEmpleado perfil = new PerfilEmpleado()
                        {
                            IdPerfil = reader.GetInt32(0),  // Asumiendo que id_perfil es el primer campo
                            NombrePerfil = reader.GetString(1)  // Asumiendo que nombre_Perfil es el segundo campo
                        };

                        perfiles.Add(perfil);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores relacionados con SQL
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;  // Lanza la excepción nuevamente para que pueda ser manejada en niveles superiores si es necesario
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return perfiles;
        }

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
    }
}