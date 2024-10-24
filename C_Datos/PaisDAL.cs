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
    }
}
