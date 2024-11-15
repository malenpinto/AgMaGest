using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;
using System.Configuration;
using System.Data;
using static AgMaGest.C_Logica.Entidades.Pedido;


namespace AgMaGest.C_Datos
{
    public class PedidoDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public bool InsertarPedido(string cuilEmpleado, int idCliente, int idVehiculo, DateTime fechaPedido, double montoPedido, int idEstadoPedido)
        {
            bool resultado = false;

            string query = @"
                INSERT INTO Pedido (cuil_Empleado, id_Cliente, id_Vehiculo, fecha_Pedido, monto_Pedido, id_EstadoPedido)
                VALUES (@CuilEmpleado, @IdCliente, @IdVehiculo, @FechaPedido, @MontoPedido, @IdEstadoPedido)";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CuilEmpleado", cuilEmpleado);
                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                        cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                        cmd.Parameters.AddWithValue("@FechaPedido", fechaPedido);
                        cmd.Parameters.AddWithValue("@MontoPedido", montoPedido);
                        cmd.Parameters.AddWithValue("@IdEstadoPedido", idEstadoPedido); // Nuevo parámetro

                        int rowsAffected = cmd.ExecuteNonQuery();
                        resultado = rowsAffected > 0;
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

        public bool ActualizarEstadoVehiculo(int idVehiculo, int nuevoEstado)
        {
            bool resultado = false;

            string query = @"
                UPDATE Vehiculos
                SET id_Estado = @NuevoEstado
                WHERE id_Vehiculo = @IdVehiculo";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        resultado = rowsAffected > 0;
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

        public List<Pedido> ObtenerPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            ClienteDAL clienteDAL = new ClienteDAL(); // Instancia de ClienteDAL para obtener los datos del cliente

            string query = @"
        SELECT 
            p.id_Pedido,
            p.cuil_Empleado,
            e.nombre_Empleado,
            e.apellido_Empleado,
            p.id_Cliente,
            p.id_Vehiculo,
            p.fecha_Pedido,
            p.monto_Pedido,
            p.id_EstadoPedido,
            ep.nombre_EstadoPedido
        FROM 
            Pedido p
        INNER JOIN 
            Empleado e ON p.cuil_Empleado = e.cuil_Empleado
        INNER JOIN 
            Estado_Pedido ep ON p.id_EstadoPedido = ep.id_EstadoPedido";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pedido pedido = new Pedido
                            {
                                IdPedido = reader.GetInt32(reader.GetOrdinal("id_Pedido")),
                                CUIL = reader.GetString(reader.GetOrdinal("cuil_Empleado")),
                                NombreEmpleado = reader.GetString(reader.GetOrdinal("nombre_Empleado")),
                                ApellidoEmpleado = reader.GetString(reader.GetOrdinal("apellido_Empleado")),
                                IdCliente = reader.GetInt32(reader.GetOrdinal("id_Cliente")),
                                IdVehiculo = reader.GetInt32(reader.GetOrdinal("id_Vehiculo")),
                                FechaPedido = reader.GetDateTime(reader.GetOrdinal("fecha_Pedido")),
                                MontoPedido = reader.GetDouble(reader.GetOrdinal("monto_Pedido")),
                                IdEstadoPedido = reader.GetInt32(reader.GetOrdinal("id_EstadoPedido")),
                                NombreEstadoPedido = reader.GetString(reader.GetOrdinal("nombre_EstadoPedido"))
                            };

                            // Obtener los detalles del vehículo
                            VehiculoDAL vehiculoDAL = new VehiculoDAL();
                            pedido.Vehiculo = vehiculoDAL.ObtenerVehiculoPorId(pedido.IdVehiculo);

                            // Obtener datos del cliente usando IdCliente
                            var cliente = clienteDAL.FiltrarClientePorId(pedido.IdCliente);
                            if (cliente != null)
                            {
                                pedido.DetallesCliente = cliente.CuilCuit; // Usa la propiedad CuilCuit del cliente
                            }

                            listaPedidos.Add(pedido);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return listaPedidos;
        }

        public List<Pedido> BuscarPedidos(string criterioBusqueda)
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            string query = @"
                SELECT 
                    p.id_Pedido,
                    p.cuil_Empleado,
                    p.id_Cliente,
                    p.id_Vehiculo,
                    p.fecha_Pedido,
                    p.monto_Pedido,
                    p.id_EstadoPedido,
                    e.nombre_Empleado,
                    e.apellido_Empleado
                FROM Pedido p
                INNER JOIN Empleado e ON p.cuil_Empleado = e.cuil_Empleado
                WHERE p.id_Pedido LIKE @CriterioBusqueda 
                   OR p.cuil_Empleado LIKE @CriterioBusqueda 
                   OR e.nombre_Empleado LIKE @CriterioBusqueda
                   OR e.apellido_Empleado LIKE @CriterioBusqueda";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CriterioBusqueda", $"%{criterioBusqueda}%");

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pedido pedido = new Pedido
                                {
                                    IdPedido = reader.GetInt32(reader.GetOrdinal("id_Pedido")),
                                    CUIL = reader.GetString(reader.GetOrdinal("cuil_Empleado")),
                                    IdCliente = reader.GetInt32(reader.GetOrdinal("id_Cliente")),
                                    IdVehiculo = reader.GetInt32(reader.GetOrdinal("id_Vehiculo")),
                                    FechaPedido = reader.GetDateTime(reader.GetOrdinal("fecha_Pedido")),
                                    MontoPedido = reader.GetDouble(reader.GetOrdinal("monto_Pedido")),
                                    IdEstadoPedido = reader.GetInt32(reader.GetOrdinal("id_EstadoPedido")),

                                    // Nuevos campos provenientes de la tabla Empleado
                                    NombreEmpleado = reader.GetString(reader.GetOrdinal("nombre_Empleado")),
                                    ApellidoEmpleado = reader.GetString(reader.GetOrdinal("apellido_Empleado"))
                                };
                                listaPedidos.Add(pedido);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return listaPedidos;
        }

        public int ContarPedidosPorEstado(int idEstadoPedido)
        {
            int cantidadPedidos = 0;

            string query = @"
                SELECT COUNT(*)
                FROM Pedido
                WHERE id_EstadoPedido = @IdEstadoPedido";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdEstadoPedido", idEstadoPedido);

                        cantidadPedidos = (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return cantidadPedidos;
        }

        public List<KeyValuePair<int, string>> ObtenerEstadosPedidos()
        {
            List<KeyValuePair<int, string>> estadosPedidos = new List<KeyValuePair<int, string>>();

            string query = @"
                SELECT id_EstadoPedido, nombre_EstadoPedido
                FROM Estado_Pedido";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idEstadoPedido = reader.GetInt32(reader.GetOrdinal("id_EstadoPedido"));
                            string nombreEstadoPedido = reader.GetString(reader.GetOrdinal("nombre_EstadoPedido"));

                            estadosPedidos.Add(new KeyValuePair<int, string>(idEstadoPedido, nombreEstadoPedido));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return estadosPedidos;
        }

        public List<VendedorEstadistica> ObtenerVendedorDelMes()
        {
            List<VendedorEstadistica> vendedores = new List<VendedorEstadistica>();

            string query = @"
                SELECT TOP 1
                    e.cuil_Empleado,
                    e.nombre_Empleado,
                    e.apellido_Empleado,
                    COUNT(p.id_Pedido) AS CantidadPedidos,
                    SUM(p.monto_Pedido) AS TotalVentas
                FROM 
                    Pedido p
                INNER JOIN 
                    Empleado e ON p.cuil_Empleado = e.cuil_Empleado
                WHERE 
                    MONTH(p.fecha_Pedido) = MONTH(GETDATE()) 
                    AND YEAR(p.fecha_Pedido) = YEAR(GETDATE())
                    AND p.id_EstadoPedido = 2
                GROUP BY 
                    e.cuil_Empleado, e.nombre_Empleado, e.apellido_Empleado
                ORDER BY 
                    CantidadPedidos DESC, TotalVentas DESC";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            VendedorEstadistica vendedor = new VendedorEstadistica
                            {
                                CUIL = reader.GetString(reader.GetOrdinal("cuil_Empleado")),
                                NombreEmpleado = reader.GetString(reader.GetOrdinal("nombre_Empleado")),
                                ApellidoEmpleado = reader.GetString(reader.GetOrdinal("apellido_Empleado")),
                                CantidadPedidos = reader.GetInt32(reader.GetOrdinal("CantidadPedidos")),
                                TotalVentas = reader.GetDouble(reader.GetOrdinal("TotalVentas"))
                            };
                            vendedores.Add(vendedor);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return vendedores;
        }

        public List<KeyValuePair<string, int>> ObtenerEstadisticasAnualesPedidos()
        {
            List<KeyValuePair<string, int>> estadisticasAnuales = new List<KeyValuePair<string, int>>();

            string query = @"
                SELECT 
                    MONTH(fecha_Pedido) AS Mes,
                    COUNT(*) AS CantidadPedidos
                FROM 
                    Pedido
                WHERE 
                    YEAR(fecha_Pedido) = YEAR(GETDATE())
                GROUP BY 
                    MONTH(fecha_Pedido)
                ORDER BY 
                    Mes";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int mes = reader.GetInt32(reader.GetOrdinal("Mes"));
                            int cantidadPedidos = reader.GetInt32(reader.GetOrdinal("CantidadPedidos"));

                            // Convertir el número del mes a nombre del mes
                            string nombreMes = new DateTime(1, mes, 1).ToString("MMMM");

                            estadisticasAnuales.Add(new KeyValuePair<string, int>(nombreMes, cantidadPedidos));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return estadisticasAnuales;
        }
    }
}
