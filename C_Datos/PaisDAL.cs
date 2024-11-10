using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class PaisDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public List<Pais> ObtenerPaises()
        {
            List<Pais> paises = new List<Pais>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_Pais, nombre_Pais FROM Pais", conn);
                SqlDataReader reader = cmd.ExecuteReader(); //Lee datos cargados en la tabla Pais

                while (reader.Read())
                {
                    Pais pais = new Pais()
                    {
                        IdPais = reader.GetInt32(0), // id_pais
                        NombrePais = reader.GetString(1) // nombre_pais
                    };
                    paises.Add(pais);
                }
            }
            return paises;
        }
        public Pais ObtenerPaisPorId(int idPais)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT id_Pais, nombre_Pais FROM Pais WHERE id_Pais = @IdPais", conn))
                {
                    cmd.Parameters.AddWithValue("@IdPais", idPais);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Pais
                            {
                                IdPais = reader.GetInt32(0),
                                NombrePais = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null; // Si no se encuentra, retorna null.
        }

        public List<KeyValuePair<int, string>> ObtenerPaises2()
        {
            List<KeyValuePair<int, string>> paises = new List<KeyValuePair<int, string>>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_Pais, nombre_Pais FROM Pais", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        paises.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                    }
                }
            }

            return paises;
        }

    }
}
