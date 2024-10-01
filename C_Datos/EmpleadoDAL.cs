using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;  // Referencia a la capa lógica donde está la clase Empleado

namespace AgMaGest.C_Datos
{
    public class EmpleadoDAL
    {
        private string connectionString = "Data Source=DESKTOP-TT9O6S1\\SQLEXPRESS;Initial Catalog=Agmagest;Integrated Security=True";


        // Método para obtener la lista de perfiles
        public List<PerfilEmpleado> ObtenerPerfiles()
        {
            List<PerfilEmpleado> perfiles = new List<PerfilEmpleado>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_perfil, nombre_Perfil FROM Perfil_Empleado", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PerfilEmpleado perfil = new PerfilEmpleado()
                    {
                        IdPerfil = reader.GetInt32(0), // Asumiendo que id_perfil es el primer campo
                        NombrePerfil = reader.GetString(1) // Asumiendo que nombre_perfil es el segundo campo
                    };

                    perfiles.Add(perfil);
                }
            }

            return perfiles;
        }

        // Método para obtener un nuevo ID para el empleado
        public int ObtenerNuevoIdEmpleado()
        {
            int nuevoId = 1; // Valor predeterminado en caso de que no existan empleados en la base de datos

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Consulta para obtener el máximo id_Empleado existente
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(id_Empleado), 0) FROM Empleado", conn);

                // Ejecutar la consulta y obtener el resultado
                object resultado = cmd.ExecuteScalar();
                if (resultado != null)
                {
                    // Sumar 1 al máximo id_Empleado encontrado
                    nuevoId = Convert.ToInt32(resultado) + 1;
                }
            }

            return nuevoId; // Retornar el nuevo id único
        }

        // Método para insertar un nuevo empleado en la base de datos
        public void InsertarEmpleado(Empleado empleado)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Cambiamos "Empleados" por "Empleado" para coincidir con el nombre de la tabla
                SqlCommand cmd = new SqlCommand(
                   "INSERT INTO Empleado (id_Empleado, nombre_Empleado, apellido_Empleado, dni_Empleado, cuil_Empleado, calle_Empleado, num_Calle_Empleado, " +
                    "piso_Empleado, dpto_Empleado, email_Empleado, celular_Empleado, codigo_PostalEmpleado, id_Localidad, id_perfil, id_Estado) " +
                    "VALUES (@IdEmpleado, @Nombre, @Apellido, @DNI, @CUIL, @Calle, @NumeroCalle, @Piso, @Dpto, @Email, @Celular, @CodigoPostal, @IdLocalidad, @IdPerfil, @IdEstado)", conn);

                // Añadir los parámetros al comando SQL
                cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado); // Asegúrate de que el IdEmpleado tenga un valor único
                cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                cmd.Parameters.AddWithValue("@DNI", empleado.DNI);
                cmd.Parameters.AddWithValue("@CUIL", empleado.CUIL);
                cmd.Parameters.AddWithValue("@Calle", empleado.Calle);
                cmd.Parameters.AddWithValue("@NumeroCalle", empleado.NumeroCalle);
                cmd.Parameters.AddWithValue("@Piso", empleado.Piso);
                cmd.Parameters.AddWithValue("@Dpto", empleado.Dpto);
                cmd.Parameters.AddWithValue("@Email", empleado.Email);
                cmd.Parameters.AddWithValue("@Celular", empleado.Celular);
                cmd.Parameters.AddWithValue("@CodigoPostal", empleado.CodigoPostal);
                cmd.Parameters.AddWithValue("@IdLocalidad", empleado.IdLocalidad);
                cmd.Parameters.AddWithValue("@IdPerfil", empleado.IdPerfil);
                cmd.Parameters.AddWithValue("@IdEstado", empleado.IdEstado);

                // Ejecutar el comando de inserción
                cmd.ExecuteNonQuery();
            }
        }
    }
}
