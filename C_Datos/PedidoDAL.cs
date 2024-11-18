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

        public bool ActualizarEstadoPedido(int idPedido, int nuevoEstado)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = "UPDATE Pedido SET id_EstadoPedido = @NuevoEstado WHERE id_Pedido = @IdPedido";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                    cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                    resultado = cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return resultado;
        }

        /*public int ObtenerIdClientePorPedido(int idPedido)
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT id_Cliente FROM Pedido WHERE id_Pedido = @idPedido";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPedido", idPedido);
                        object result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el cliente por pedido: " + ex.Message);
            }
        }*/


        public int ObtenerIdClientePorPedido(int idPedido)
        {
            if (idPedido <= 0)
            {
                throw new ArgumentException("El ID del pedido debe ser mayor a cero.", nameof(idPedido));
            }

            try
            {
                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = "SELECT id_Cliente FROM Pedido WHERE id_Pedido = @idPedido";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPedido", idPedido);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int idCliente))
                        {
                            return idCliente;
                        }

                        // Retornar 0 si no hay coincidencia
                        return 0;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Manejo específico para errores de SQL
                throw new Exception($"Error al ejecutar la consulta SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener el cliente por pedido: {ex.Message}");
            }
        }


        public int ObtenerEstadoPagoPorPedido(int idPedido)
        {
            int estadoPago = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = "SELECT id_EstadoPago FROM Pago WHERE id_Pedido = @IdPedido";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            estadoPago = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al obtener el estado del pago: {ex.Message}");
                throw new Exception("Error al obtener el estado del pago.", ex);
            }

            return estadoPago;
        }


        public List<Pedido> ObtenerPedidos()
        {
            List<Pedido> listaPedidos = new List<Pedido>();
            ClienteDAL clienteDAL = new ClienteDAL(); // Instancia para obtener datos del cliente

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
                    ep.nombre_EstadoPedido,
                    v.marca_Vehiculo,
                    v.modelo_Vehiculo,
                    v.anio_Vehiculo,
                    v.ruta_Imagen,
                    cv.nombre_Condicion AS CondicionVehiculo,
                    tv.nombre_TipoVehiculo AS TipoVehiculo, -- Tipo del vehículo
                    cf.nombre_CFinal,
                    cf.apellido_CFinal,
                    cf.cuil_CFinal,
                    ce.razon_Social_CEmpresa,
                    ce.cuit_CEmpresa
                FROM 
                    Pedido p
                INNER JOIN 
                    Empleado e ON p.cuil_Empleado = e.cuil_Empleado
                INNER JOIN 
                    Estado_Pedido ep ON p.id_EstadoPedido = ep.id_EstadoPedido
                INNER JOIN 
                    Vehiculos v ON p.id_Vehiculo = v.id_Vehiculo
                INNER JOIN 
                    Condicion cv ON v.id_Condicion = cv.id_Condicion
                INNER JOIN 
                    Tipo_Vehiculo tv ON v.id_tipoVehiculo = tv.id_tipoVehiculo
                LEFT JOIN 
                    Cliente c ON p.id_Cliente = c.id_Cliente
                LEFT JOIN 
                    Cliente_Final cf ON c.id_Cliente = cf.id_Cliente
                LEFT JOIN 
                    Cliente_Empresa ce ON c.id_Cliente = ce.id_Cliente";

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

                            // Crear objeto Pedido
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
                                NombreEstadoPedido = reader.GetString(reader.GetOrdinal("nombre_EstadoPedido")),
                                CUIL_Cliente = cuilCuitCliente,
                                NombreCliente = nombreCliente,
                                Vehiculo = new Vehiculos
                                {
                                    RutaImagen = reader.IsDBNull(reader.GetOrdinal("ruta_Imagen"))
                                            ? null
                                            : reader.GetString(reader.GetOrdinal("ruta_Imagen")),
                                    Marca = reader.GetString(reader.GetOrdinal("marca_Vehiculo")),
                                    Modelo = reader.GetString(reader.GetOrdinal("modelo_Vehiculo")),
                                    Anio = reader.GetDateTime(reader.GetOrdinal("anio_Vehiculo")),
                                    CondicionNombre = reader.GetString(reader.GetOrdinal("CondicionVehiculo")),
                                    TipoNombre = reader.GetString(reader.GetOrdinal("TipoVehiculo"))
                                }
                            };

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
                    e.nombre_Empleado,
                    e.apellido_Empleado,
                    p.id_Cliente,
                    p.id_Vehiculo,
                    p.fecha_Pedido,
                    p.monto_Pedido,
                    p.id_EstadoPedido,
                    ep.nombre_EstadoPedido,
                    v.marca_Vehiculo,
                    v.modelo_Vehiculo,
                    v.anio_Vehiculo,
                    v.ruta_Imagen,
                    cv.nombre_Condicion AS CondicionVehiculo,
                    tv.nombre_TipoVehiculo AS TipoVehiculo,
                    cf.nombre_CFinal,
                    cf.apellido_CFinal,
                    cf.cuil_CFinal,
                    ce.razon_Social_CEmpresa,
                    ce.cuit_CEmpresa
                FROM 
                    Pedido p
                INNER JOIN 
                    Empleado e ON p.cuil_Empleado = e.cuil_Empleado
                INNER JOIN 
                    Estado_Pedido ep ON p.id_EstadoPedido = ep.id_EstadoPedido
                INNER JOIN 
                    Vehiculos v ON p.id_Vehiculo = v.id_Vehiculo
                INNER JOIN 
                    Condicion cv ON v.id_Condicion = cv.id_Condicion
                INNER JOIN 
                    Tipo_Vehiculo tv ON v.id_tipoVehiculo = tv.id_tipoVehiculo
                LEFT JOIN 
                    Cliente c ON p.id_Cliente = c.id_Cliente
                LEFT JOIN 
                    Cliente_Final cf ON c.id_Cliente = cf.id_Cliente
                LEFT JOIN 
                    Cliente_Empresa ce ON c.id_Cliente = ce.id_Cliente
                WHERE 
                    p.id_Pedido LIKE @CriterioBusqueda 
                    OR p.cuil_Empleado LIKE @CriterioBusqueda 
                    OR e.nombre_Empleado LIKE @CriterioBusqueda
                    OR e.apellido_Empleado LIKE @CriterioBusqueda
                    OR ep.nombre_EstadoPedido LIKE @CriterioBusqueda
                    OR cf.nombre_CFinal LIKE @CriterioBusqueda
                    OR cf.apellido_CFinal LIKE @CriterioBusqueda
                    OR cf.cuil_CFinal LIKE @CriterioBusqueda
                    OR ce.razon_Social_CEmpresa LIKE @CriterioBusqueda
                    OR ce.cuit_CEmpresa LIKE @CriterioBusqueda
                    OR v.marca_Vehiculo LIKE @CriterioBusqueda
                    OR v.modelo_Vehiculo LIKE @CriterioBusqueda";

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
                                string nombreCliente;
                                string cuilCuitCliente;

                                // Identificar tipo de cliente
                                if (!reader.IsDBNull(reader.GetOrdinal("nombre_CFinal")) &&
                                    !reader.IsDBNull(reader.GetOrdinal("apellido_CFinal")) &&
                                    !reader.IsDBNull(reader.GetOrdinal("cuil_CFinal")))
                                {
                                    string nombre = reader.GetString(reader.GetOrdinal("nombre_CFinal"));
                                    string apellido = reader.GetString(reader.GetOrdinal("apellido_CFinal"));
                                    cuilCuitCliente = reader.GetString(reader.GetOrdinal("cuil_CFinal"));
                                    nombreCliente = $"{nombre} {apellido}";
                                }
                                else if (!reader.IsDBNull(reader.GetOrdinal("razon_Social_CEmpresa")) &&
                                         !reader.IsDBNull(reader.GetOrdinal("cuit_CEmpresa")))
                                {
                                    cuilCuitCliente = reader.GetString(reader.GetOrdinal("cuit_CEmpresa"));
                                    nombreCliente = reader.GetString(reader.GetOrdinal("razon_Social_CEmpresa"));
                                }
                                else
                                {
                                    cuilCuitCliente = "N/A";
                                    nombreCliente = "Cliente desconocido";
                                }

                                // Crear objeto Pedido
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
                                    NombreEstadoPedido = reader.GetString(reader.GetOrdinal("nombre_EstadoPedido")),
                                    CUIL_Cliente = cuilCuitCliente,
                                    NombreCliente = nombreCliente,
                                    Vehiculo = new Vehiculos
                                    {
                                        RutaImagen = reader.IsDBNull(reader.GetOrdinal("ruta_Imagen"))
                                            ? null
                                            : reader.GetString(reader.GetOrdinal("ruta_Imagen")),
                                        Marca = reader.GetString(reader.GetOrdinal("marca_Vehiculo")),
                                        Modelo = reader.GetString(reader.GetOrdinal("modelo_Vehiculo")),
                                        Anio = reader.GetDateTime(reader.GetOrdinal("anio_Vehiculo")),
                                        CondicionNombre = reader.GetString(reader.GetOrdinal("CondicionVehiculo")),
                                        TipoNombre = reader.GetString(reader.GetOrdinal("TipoVehiculo"))
                                    }
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

        public List<KeyValuePair<string, int>> ObtenerEstadisticasAnualesPedidos(int? mes = null)
        {
            List<KeyValuePair<string, int>> estadisticasAnuales = new List<KeyValuePair<string, int>>();

            // Consulta SQL con filtro opcional por mes
            string query = @"
        SELECT 
            MONTH(fecha_Pedido) AS Mes,
            COUNT(*) AS CantidadPedidos
        FROM 
            Pedido
        WHERE 
            YEAR(fecha_Pedido) = YEAR(GETDATE())";

            // Agregar filtro por mes si se proporciona
            if (mes.HasValue)
            {
                query += " AND MONTH(fecha_Pedido) = @Mes";
            }

            query += @"
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
                    {
                        // Si se proporciona un mes, agregarlo como parámetro
                        if (mes.HasValue)
                        {
                            cmd.Parameters.AddWithValue("@Mes", mes.Value);
                        }

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int mesResult = reader.GetInt32(reader.GetOrdinal("Mes"));
                                int cantidadPedidos = reader.GetInt32(reader.GetOrdinal("CantidadPedidos"));

                                // Convertir el número del mes al nombre del mes
                                string nombreMes = new DateTime(1, mesResult, 1).ToString("MMMM");

                                estadisticasAnuales.Add(new KeyValuePair<string, int>(nombreMes, cantidadPedidos));
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

            return estadisticasAnuales;
        }

    }
}
