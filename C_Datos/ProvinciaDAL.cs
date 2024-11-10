using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class ProvinciaDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para obtener las provincias de un país específico
        public List<Provincia> ObtenerProvinciasPorPais(int idPais)
        {
            List<Provincia> provincias = new List<Provincia>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                // Consulta para obtener provincias filtradas por el id del país
                using (SqlCommand cmd = new SqlCommand("SELECT id_Provincia, nombre_Provincia FROM Provincia WHERE id_Pais = @IdPais", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPais", idPais); // Añadiendo el parámetro para la consulta

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Llenando la lista de provincias
                            Provincia provincia = new Provincia()
                            {
                                IdProvincia = reader.GetInt32(0), // id_Provincia
                                NombreProvincia = reader.GetString(1), // Nombre_Provincia
                            };
                            provincias.Add(provincia);
                        }
                    }
                }
            }

            return provincias; // Retornando la lista de provincias
        }
        public Provincia ObtenerProvinciaPorId(int idProvincia)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id_Provincia, nombre_Provincia, id_Pais FROM Provincia WHERE id_Provincia = @IdProvincia", conn))
                {
                    cmd.Parameters.AddWithValue("@IdProvincia", idProvincia);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Provincia
                            {
                                IdProvincia = reader.GetInt32(0),
                                NombreProvincia = reader.GetString(1),
                                IdPais = reader.GetInt32(2)
                            };
                        }
                    }
                }
            }
            return null; // Si no se encuentra, retorna null.
        }

        public List<KeyValuePair<int, string>> ObtenerProvinciasPorPais2(int idPais)
        {
            List<KeyValuePair<int, string>> provincias = new List<KeyValuePair<int, string>>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_Provincia, nombre_Provincia FROM Provincia WHERE id_Pais = @idPais", conn);
                cmd.Parameters.AddWithValue("@idPais", idPais);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        provincias.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }

            return provincias;
        }


        public List<Provincia> ObtenerProvincias(string nombreProvincia = null, int? idPais = null)
        {
            List<Provincia> provincias = new List<Provincia>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                // Construimos la consulta de manera dinámica según los parámetros
                StringBuilder query = new StringBuilder("SELECT id_Provincia, nombre_Provincia, id_Pais FROM Provincia WHERE 1=1");

                if (!string.IsNullOrEmpty(nombreProvincia))
                {
                    query.Append(" AND nombre_Provincia LIKE @NombreProvincia");
                }
                if (idPais.HasValue)
                {
                    query.Append(" AND id_Pais = @IdPais");
                }

                using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                {
                    // Añadiendo parámetros a la consulta si es necesario
                    if (!string.IsNullOrEmpty(nombreProvincia))
                    {
                        cmd.Parameters.AddWithValue("@NombreProvincia", "%" + nombreProvincia + "%");  // Búsqueda parcial (LIKE)
                    }
                    if (idPais.HasValue)
                    {
                        cmd.Parameters.AddWithValue("@IdPais", idPais.Value);
                    }

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            provincias.Add(new Provincia
                            {
                                IdProvincia = reader.GetInt32(0),
                                NombreProvincia = reader.GetString(1),
                                IdPais = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            return provincias;
        }

    }
}
