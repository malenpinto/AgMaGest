using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace AgMaGest.C_Datos
{
    public class EstadoClienteDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para obtener todos los estados de cliente
        public List<EstadoCliente> ObtenerEstadosCliente()
        {
            List<EstadoCliente> estados = new List<EstadoCliente>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_Estado_Cliente, nombre_EstadoCliente FROM Estado_Cliente", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        EstadoCliente estado = new EstadoCliente()
                        {
                            IdEstadoCliente = reader.GetInt32(0),
                            NombreEstadoCliente = reader.GetString(1)
                        };

                        estados.Add(estado);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores de SQL
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return estados;
        }

        // Método para obtener el nombre de un estado de cliente por su ID
        public string ObtenerNombreEstadoCliente(int idEstadoCliente)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT nombre_EstadoCliente FROM Estado_Cliente WHERE id_Estado_Cliente = @IdEstadoCliente", conn))
                {
                    cmd.Parameters.AddWithValue("@IdEstadoCliente", idEstadoCliente);

                    object resultado = cmd.ExecuteScalar();
                    return resultado != null ? resultado.ToString() : "Desconocido"; // Devuelve "Desconocido" si no encuentra el estado.
                }
            }
        }
    }
}
