using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;

namespace AgMaGest.C_Datos
{
    public class LocalidadDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

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
    }
}
