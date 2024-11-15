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
            ClienteDAL clienteDAL = new ClienteDAL(); // Instancia para validar si es CUIL o CUIT

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener las facturas
                    string query = @"
                SELECT 
                    f.num_Factura, 
                    f.fecha_Factura, 
                    f.total_Factura, 
                    f.id_pago, 
                    e.cuil_Empleado AS CUIL_Empleado, 
                    CONCAT(e.nombre_Empleado, ' ', e.apellido_Empleado) AS NombreCompleto,
                    CONCAT(v.marca_Vehiculo, ' ', v.modelo_Vehiculo, ' ', v.anio_Vehiculo) AS DetallesVehiculo,
                    c.id_Cliente,
                    cf.nombre_CFinal, 
                    cf.apellido_CFinal, 
                    cf.cuil_CFinal,
                    ce.razon_Social_CEmpresa, 
                    ce.cuit_CEmpresa
                FROM Factura f
                INNER JOIN Pago p ON f.id_pago = p.id_pago
                INNER JOIN Pedido pe ON p.id_Pedido = pe.id_Pedido
                INNER JOIN Empleado e ON pe.cuil_Empleado = e.cuil_Empleado
                INNER JOIN Vehiculos v ON pe.id_Vehiculo = v.id_Vehiculo
                INNER JOIN Cliente c ON pe.id_Cliente = c.id_Cliente
                LEFT JOIN Cliente_Final cf ON c.id_Cliente = cf.id_Cliente
                LEFT JOIN Cliente_Empresa ce ON c.id_Cliente = ce.id_Cliente";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Determinar si es Cliente Final o Empresa
                                string nombreCliente;
                                string cuilCuitCliente;

                                if (!reader.IsDBNull(reader.GetOrdinal("nombre_CFinal")) &&
                                    !reader.IsDBNull(reader.GetOrdinal("apellido_CFinal")) &&
                                    !reader.IsDBNull(reader.GetOrdinal("cuil_CFinal")))
                                {
                                    // Es Cliente Final
                                    string nombre = reader.GetString(reader.GetOrdinal("nombre_CFinal"));
                                    string apellido = reader.GetString(reader.GetOrdinal("apellido_CFinal"));
                                    cuilCuitCliente = reader.GetString(reader.GetOrdinal("cuil_CFinal"));
                                    nombreCliente = $"{nombre} {apellido}";
                                }
                                else if (!reader.IsDBNull(reader.GetOrdinal("razon_Social_CEmpresa")) &&
                                         !reader.IsDBNull(reader.GetOrdinal("cuit_CEmpresa")))
                                {
                                    // Es Cliente Empresa
                                    cuilCuitCliente = reader.GetString(reader.GetOrdinal("cuit_CEmpresa"));
                                    nombreCliente = reader.GetString(reader.GetOrdinal("razon_Social_CEmpresa"));
                                }
                                else
                                {
                                    cuilCuitCliente = "N/A";
                                    nombreCliente = "Cliente desconocido";
                                }

                                // Crear la factura con los datos obtenidos
                                Factura factura = new Factura
                                {
                                    NumFactura = reader.GetInt32(reader.GetOrdinal("num_Factura")),
                                    FechaFactura = reader.GetDateTime(reader.GetOrdinal("fecha_Factura")),
                                    TotalFactura = reader.GetDouble(reader.GetOrdinal("total_Factura")),
                                    IdPago = reader.GetInt32(reader.GetOrdinal("id_pago")),
                                    CUIL_Empleado = reader.GetString(reader.GetOrdinal("CUIL_Empleado")),
                                    NombreCompleto = reader.IsDBNull(reader.GetOrdinal("NombreCompleto"))
                                        ? "N/A"
                                        : reader.GetString(reader.GetOrdinal("NombreCompleto")),
                                    DetallesVehiculo = reader.IsDBNull(reader.GetOrdinal("DetallesVehiculo"))
                                        ? "Sin detalles"
                                        : reader.GetString(reader.GetOrdinal("DetallesVehiculo")),
                                    CUIL_Cliente = cuilCuitCliente,
                                    NombreCliente = nombreCliente
                                };

                                listaFacturas.Add(factura);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al obtener las facturas: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al obtener las facturas: " + ex.Message);
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
