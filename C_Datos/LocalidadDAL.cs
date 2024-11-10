using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class LocalidadDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public List<Localidad> ObtenerTodasLasLocalidades()
        {
            List<Localidad> localidades = new List<Localidad>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                // Consulta para obtener todas las localidades
                using (SqlCommand cmd = new SqlCommand("SELECT id_Localidad, nombre_Localidad, id_Provincia FROM Localidad", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Localidad localidad = new Localidad()
                            {
                                IdLocalidad = reader.GetInt32(0), // id_Localidad
                                NombreLocalidad = reader.GetString(1), // nombre_Localidad
                                IdProvincia = reader.GetInt32(2) // id_Provincia
                            };
                            localidades.Add(localidad);
                        }
                    }
                }
            }

            return localidades;
        }


        // Método para obtener las localidades de una provincia específica
        public List<Localidad> ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            List<Localidad> localidades = new List<Localidad>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                // Consulta para obtener localidades filtradas por el id de la provincia
                using (SqlCommand cmd = new SqlCommand("SELECT id_Localidad, nombre_Localidad FROM Localidad WHERE id_Provincia = @IdProvincia", conn))
                {
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvincia); // Añadiendo el parámetro para la consulta

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Llenando la lista de localidades
                            Localidad localidad = new Localidad()
                            {
                                IdLocalidad = reader.GetInt32(0), // id_Localidad
                                NombreLocalidad = reader.GetString(1) // nombre_Localidad
                            };
                            localidades.Add(localidad);
                        }
                    }
                }
            }

            return localidades; // Retornando la lista de localidades
        }
        public Localidad ObtenerLocalidadPorId(int idLocalidad)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id_Localidad, nombre_Localidad, id_Provincia FROM Localidad WHERE id_Localidad = @IdLocalidad", conn))
                {
                    cmd.Parameters.AddWithValue("@IdLocalidad", idLocalidad);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Localidad
                            {
                                IdLocalidad = reader.GetInt32(0),
                                NombreLocalidad = reader.GetString(1),
                                IdProvincia = reader.GetInt32(2)
                            };
                        }
                    }
                }
            }
            return null; // Si no se encuentra, retorna null.
        }

        public List<KeyValuePair<int, string>> ObtenerLocalidadesPorProvincia2(int idProvincia)
        {
            List<KeyValuePair<int, string>> localidades = new List<KeyValuePair<int, string>>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_Localidad, nombre_Localidad FROM Localidad WHERE id_Provincia = @idProvincia", conn);
                cmd.Parameters.AddWithValue("@idProvincia", idProvincia);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        localidades.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }

            return localidades;
        }

        public List<Localidad> ObtenerLocalidades(string nombreLocalidad = null, int? idProvincia = null)
        {
            List<Localidad> localidades = new List<Localidad>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // Construimos la consulta de manera dinámica según los parámetros
                StringBuilder query = new StringBuilder("SELECT id_Localidad, nombre_Localidad, id_Provincia FROM Localidad WHERE 1=1");

                if (!string.IsNullOrEmpty(nombreLocalidad))
                {
                    query.Append(" AND nombre_Localidad LIKE @NombreLocalidad");
                }
                if (idProvincia.HasValue)
                {
                    query.Append(" AND id_Provincia = @IdProvincia");
                }

                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    // Añadiendo parámetros a la consulta si es necesario
                    if (!string.IsNullOrEmpty(nombreLocalidad))
                    {
                        cmd.Parameters.AddWithValue("@NombreLocalidad", "%" + nombreLocalidad + "%");  // Búsqueda parcial (LIKE)
                    }
                    if (idProvincia.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdProvincia", idProvincia.Value);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            localidades.Add(new Localidad
                            {
                                IdLocalidad = reader.GetInt32(0),
                                NombreLocalidad = reader.GetString(1),
                                IdProvincia = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            return localidades;
        }
    }
}
