using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;
using System.Configuration;
using System.Data;


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



    }
}
