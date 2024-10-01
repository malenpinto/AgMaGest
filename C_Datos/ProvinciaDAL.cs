using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class ProvinciaDAL
    {
        private string connectionString = "Data Source=DESKTOP-TT9O6S1\\SQLEXPRESS;Initial Catalog=Agmagest;Integrated Security=True"; // Reemplaza con tu cadena de conexión

        // Método para obtener las provincias de un país específico
        public List<Provincia> ObtenerProvinciasPorPais(int idPais)
        {
            List<Provincia> provincias = new List<Provincia>();

            using (SqlConnection conn = new SqlConnection(connectionString))
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

        // Método para obtener todas las provincias (si es necesario)
        public List<Provincia> ObtenerProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_Provincia, nombre_Provincia, id_Pais FROM Provincia", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                        {
                            Provincia provincia = new Provincia()
                            {
                                IdProvincia = reader.GetInt32(0), // id_Provincia
                                NombreProvincia = reader.GetString(1), // Nombre_Provincia
                                IdPais = reader.GetInt32(2) // id_Pais
                            };
                    provincias.Add(provincia);
                }
            }
            return provincias; // Retornando la lista de provincias
        }
    }
}
