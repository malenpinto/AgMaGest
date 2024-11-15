using AgMaGest.C_Logica.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Datos
{
    public class FacturaDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public bool InsertarFactura(Factura factura)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Factura (fecha_Factura, total_Factura, id_Pago)
                        VALUES (@FechaFactura, @TotalFactura, @IdPago);
            
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FechaFactura", factura.FechaFactura);
                    cmd.Parameters.AddWithValue("@TotalFactura", factura.TotalFactura);
                    cmd.Parameters.AddWithValue("@IdPago", factura.IdPago);

                    // Ejecutar el comando y recuperar el ID de la nueva factura
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        factura.NumFactura = Convert.ToInt32(result);
                        resultado = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return resultado;
        }

        public List<Factura> ObtenerFacturas()
        {
            List<Factura> listaFacturas = new List<Factura>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT num_Factura, fecha_Factura, total_Factura, id_pago FROM Factura";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Factura factura = new Factura
                                {
                                    NumFactura = reader.GetInt32(reader.GetOrdinal("num_Factura")),
                                    FechaFactura = reader.GetDateTime(reader.GetOrdinal("fecha_Factura")),
                                    TotalFactura = reader.GetDouble(reader.GetOrdinal("total_Factura")),
                                    IdPago = reader.GetInt32(reader.GetOrdinal("id_pago"))
                                };

                                listaFacturas.Add(factura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo del error
                throw new Exception("Error al obtener las facturas: " + ex.Message);
            }

            return listaFacturas;
        }

        public List<Factura> BuscarFacturas(string criterio)
        {
            List<Factura> listaFacturas = new List<Factura>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT NumFactura, FechaFactura, TotalFactura, IdPago 
                                     FROM Facturas
                                     WHERE CAST(NumFactura AS NVARCHAR) LIKE @Criterio 
                                     OR CAST(TotalFactura AS NVARCHAR) LIKE @Criterio
                                     OR CAST(IdPago AS NVARCHAR) LIKE @Criterio";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Factura factura = new Factura
                                {
                                    NumFactura = reader.GetInt32(reader.GetOrdinal("NumFactura")),
                                    FechaFactura = reader.GetDateTime(reader.GetOrdinal("FechaFactura")),
                                    TotalFactura = reader.GetDouble(reader.GetOrdinal("TotalFactura")),
                                    IdPago = reader.GetInt32(reader.GetOrdinal("IdPago"))
                                };

                                listaFacturas.Add(factura);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar facturas: " + ex.Message);
            }

            return listaFacturas;
        }
    }
}
