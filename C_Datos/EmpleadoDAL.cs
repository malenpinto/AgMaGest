using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;  // Referencia a la capa lógica donde está la clase Empleado

namespace AgMaGest.C_Datos
{
    public class EmpleadoDAL
    {
        private string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Agmagest;Integrated Security=True";


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

        // Métodos para verificar si el DNI, CUIL o Email ya existen en la base de datos

        public bool ExisteDNI(string dni)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Empleado WHERE dni_Empleado = @DNI", conn);
                cmd.Parameters.AddWithValue("@DNI", dni);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;  // Devuelve true si el DNI ya existe
            }
        }

        public bool ExisteCUIL(string cuil)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Empleado WHERE cuil_Empleado = @CUIL", conn);
                cmd.Parameters.AddWithValue("@CUIL", cuil);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;  // Devuelve true si el CUIL ya existe
            }
        }

        public bool ExisteEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Empleado WHERE email_Empleado = @Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;  // Devuelve true si el email ya existe
            }
        }

        // Método para insertar un nuevo empleado en la base de datos
        public void InsertarEmpleado(Empleado empleado)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Verificar si DNI, CUIL o Email ya existen antes de la inserción
                if (ExisteDNI(empleado.DNI))
                {
                    throw new Exception("El DNI ingresado ya está registrado.");
                }

                if (ExisteCUIL(empleado.CUIL))
                {
                    throw new Exception("El CUIL ingresado ya está registrado.");
                }

                if (ExisteEmail(empleado.Email))
                {
                    throw new Exception("El correo electrónico ingresado ya está registrado.");
                }

                SqlCommand cmd = new SqlCommand(
                   "INSERT INTO Empleado (id_Empleado, nombre_Empleado, apellido_Empleado, dni_Empleado, cuil_Empleado, calle_Empleado, num_Calle_Empleado, " +
                    "piso_Empleado, dpto_Empleado, email_Empleado, celular_Empleado, codigo_PostalEmpleado, id_Localidad, id_perfil, id_Estado) " +
                    "VALUES (@IdEmpleado, @Nombre, @Apellido, @DNI, @CUIL, @Calle, @NumeroCalle, @Piso, @Dpto, @Email, @Celular, @CodigoPostal, @IdLocalidad, @IdPerfil, @IdEstado)", conn);

                // Añadir los parámetros al comando SQL
                cmd.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado); // Asegurar de que el IdEmpleado tenga un valor único
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
