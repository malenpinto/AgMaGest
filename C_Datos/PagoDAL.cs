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
    public class PagoDAL
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para insertar un nuevo pago
        public bool InsertarPago(Pago pago)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        INSERT INTO Pago (descripcion_Pago, importe_Pago, id_TipoPago, id_EstadoPago, id_Pedido)
                        VALUES (@Descripcion, @Importe, @IdTipoPago, @IdEstadoPago, @IdPedido);
        
                        SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Asignar valores a los parámetros
                        cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(pago.Descripcion) ? (object)DBNull.Value : pago.Descripcion);
                        cmd.Parameters.AddWithValue("@Importe", pago.Importe);
                        cmd.Parameters.AddWithValue("@IdTipoPago", pago.IdTipoPago);
                        cmd.Parameters.AddWithValue("@IdEstadoPago", 2); // Estado inicial predeterminado (2)
                        cmd.Parameters.AddWithValue("@IdPedido", pago.IdPedido);

                        // Ejecutar el comando y recuperar el ID del pago recién insertado
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            pago.IdPago = Convert.ToInt32(result); // Asignar el ID al objeto Pago
                            resultado = true;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al insertar pago: {ex.Message}");
                throw new Exception("Error al insertar el pago. Verifica los datos ingresados.", ex);
            }

            return resultado;
        }

        //Método para actualizar el estado del pago una vez que se genera el pago
        public bool ActualizarEstadoPago(int idPago, int nuevoEstado)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    string query = @"
                        UPDATE Pago
                        SET id_EstadoPago = @NuevoEstado
                        WHERE id_Pago = @IdPago";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@IdPago", idPago);

                        int filasAfectadas = cmd.ExecuteNonQuery();
                        resultado = filasAfectadas > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al actualizar estado del pago: {ex.Message}");
                throw new Exception("Error al actualizar el estado del pago. Verifica los datos ingresados.", ex);
            }

            return resultado;
        }

        // Método para obtener todos los pagos
        public List<Pago> ObtenerPagos()
        {
            List<Pago> listaPagos = new List<Pago>();
            EmpleadoDAL empleadoDAL = new EmpleadoDAL(); // Para obtener los detalles del empleado

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Consulta SQL para obtener los pagos
                    string query = @"
                        SELECT 
                            p.id_pago,
                            p.descripcion_Pago,
                            p.importe_Pago,
                            p.id_TipoPago,
                            p.id_EstadoPago,
                            e.cuil_Empleado AS CUIL_Empleado,
                            CONCAT(e.nombre_Empleado, ' ', e.apellido_Empleado) AS NombreEmpleado,
                            ep.nombre_EstadoPedido AS NombreEstadoPedido,
                            epa.nombre_EstadoPago AS NombreEstadoPago,
                            t.nombre_tipoPago AS NombreTipoPago,
                            CONCAT(v.marca_Vehiculo, ' ', v.modelo_Vehiculo, ' ', v.anio_Vehiculo) AS DetallesVehiculo,
                            c.id_Cliente,
                            cf.nombre_CFinal,
                            cf.apellido_CFinal,
                            cf.cuil_CFinal,
                            ce.razon_Social_CEmpresa,
                            ce.cuit_CEmpresa
                        FROM 
                            Pago p
                        INNER JOIN 
                            Pedido pe ON p.id_Pedido = pe.id_Pedido
                        INNER JOIN 
                            Empleado e ON pe.cuil_Empleado = e.cuil_Empleado
                        INNER JOIN 
                            Vehiculos v ON pe.id_Vehiculo = v.id_Vehiculo
                        INNER JOIN 
                            Cliente c ON pe.id_Cliente = c.id_Cliente
                        LEFT JOIN 
                            Cliente_Final cf ON c.id_Cliente = cf.id_Cliente
                        LEFT JOIN 
                            Cliente_Empresa ce ON c.id_Cliente = ce.id_Cliente
                        INNER JOIN 
                            Estado_Pago epa ON p.id_EstadoPago = epa.id_EstadoPago
                        INNER JOIN 
                            Tipo_Pago t ON p.id_TipoPago = t.id_TipoPago
                        INNER JOIN 
                            Estado_Pedido ep ON pe.id_EstadoPedido = ep.id_EstadoPedido";

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

                                // Crear el pago con los datos obtenidos
                                Pago pago = new Pago
                                {
                                    IdPago = reader.GetInt32(reader.GetOrdinal("id_pago")),
                                    Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion_Pago")) ? "Sin descripción" : reader.GetString(reader.GetOrdinal("descripcion_Pago")),
                                    Importe = reader.GetDouble(reader.GetOrdinal("importe_Pago")),
                                    IdTipoPago = reader.GetInt32(reader.GetOrdinal("id_TipoPago")),
                                    IdEstadoPago = reader.GetInt32(reader.GetOrdinal("id_EstadoPago")),
                                    NombreEstadoPedido = reader.IsDBNull(reader.GetOrdinal("NombreEstadoPedido")) ? "Sin estado" : reader.GetString(reader.GetOrdinal("NombreEstadoPedido")),
                                    NombreEstadoPago = reader.IsDBNull(reader.GetOrdinal("NombreEstadoPago")) ? "Sin estado" : reader.GetString(reader.GetOrdinal("NombreEstadoPago")),
                                    NombreTipoPago = reader.IsDBNull(reader.GetOrdinal("NombreTipoPago")) ? "Sin datos" : reader.GetString(reader.GetOrdinal("NombreTipoPago")),
                                    CUIL_Empleado = reader.GetString(reader.GetOrdinal("CUIL_Empleado")),
                                    NombreCompleto = reader.IsDBNull(reader.GetOrdinal("NombreEmpleado"))
                                        ? "N/A"
                                        : reader.GetString(reader.GetOrdinal("NombreEmpleado")),
                                    DetallesVehiculo = reader.IsDBNull(reader.GetOrdinal("DetallesVehiculo"))
                                        ? "Sin detalles"
                                        : reader.GetString(reader.GetOrdinal("DetallesVehiculo")),
                                    CUIL_Cliente = cuilCuitCliente,
                                    NombreCliente = nombreCliente
                                };

                                listaPagos.Add(pago);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al obtener los pagos: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al obtener los pagos: " + ex.Message);
            }

            return listaPagos;
        }

        public List<Pago> BuscarPagos(string criterio)
        {
            List<Pago> listaPagos = new List<Pago>();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Construir la consulta SQL dinámicamente según los parámetros de búsqueda
                    string query = @"
                        SELECT 
                            p.id_pago,
                            p.descripcion_Pago,
                            p.importe_Pago,
                            p.id_TipoPago,
                            p.id_EstadoPago,
                            e.cuil_Empleado AS CUIL_Empleado,
                            CONCAT(e.nombre_Empleado, ' ', e.apellido_Empleado) AS NombreEmpleado,
                            ep.nombre_EstadoPedido AS NombreEstadoPedido,
                            epa.nombre_EstadoPago AS NombreEstadoPago,
                            t.nombre_tipoPago AS NombreTipoPago,
                            CONCAT(v.marca_Vehiculo, ' ', v.modelo_Vehiculo, ' ', v.anio_Vehiculo) AS DetallesVehiculo,
                            c.id_Cliente,
                            cf.nombre_CFinal,
                            cf.apellido_CFinal,
                            cf.cuil_CFinal,
                            ce.razon_Social_CEmpresa,
                            ce.cuit_CEmpresa
                        FROM 
                            Pago p
                        INNER JOIN 
                            Pedido pe ON p.id_Pedido = pe.id_Pedido
                        INNER JOIN 
                            Empleado e ON pe.cuil_Empleado = e.cuil_Empleado
                        INNER JOIN 
                            Vehiculos v ON pe.id_Vehiculo = v.id_Vehiculo
                        INNER JOIN 
                            Cliente c ON pe.id_Cliente = c.id_Cliente
                        LEFT JOIN 
                            Cliente_Final cf ON c.id_Cliente = cf.id_Cliente
                        LEFT JOIN 
                            Cliente_Empresa ce ON c.id_Cliente = ce.id_Cliente
                        INNER JOIN 
                            Estado_Pago epa ON p.id_EstadoPago = epa.id_EstadoPago
                        INNER JOIN 
                            Tipo_Pago t ON p.id_TipoPago = t.id_TipoPago
                        INNER JOIN 
                            Estado_Pedido ep ON pe.id_EstadoPedido = ep.id_EstadoPedido
                        WHERE
                            CAST(ISNULL(p.id_pago, 0) AS NVARCHAR) LIKE @Criterio
                            OR ISNULL(p.descripcion_Pago, '') LIKE @Criterio
                            OR CAST(ISNULL(p.importe_Pago, 0) AS NVARCHAR) LIKE @Criterio 
                            OR ISNULL(ep.nombre_EstadoPedido, '') LIKE @Criterio
                            OR ISNULL(epa.nombre_EstadoPago, '') LIKE @Criterio
                            OR ISNULL(t.nombre_tipoPago, '') LIKE @Criterio
                            OR ISNULL(cf.nombre_CFinal, '') LIKE @Criterio
                            OR ISNULL(cf.apellido_CFinal, '') LIKE @Criterio
                            OR ISNULL(cf.cuil_CFinal, '') LIKE @Criterio
                            OR ISNULL(ce.razon_Social_CEmpresa, '') LIKE @Criterio
                            OR ISNULL(ce.cuit_CEmpresa, '') LIKE @Criterio
                            OR ISNULL(e.nombre_Empleado, '') LIKE @Criterio
                            OR ISNULL(e.apellido_Empleado, '') LIKE @Criterio
                            OR ISNULL(v.marca_Vehiculo, '') LIKE @Criterio
                            OR ISNULL(v.modelo_Vehiculo, '') LIKE @Criterio
                            OR CAST(ISNULL(v.anio_Vehiculo, 0) AS NVARCHAR) LIKE @Criterio";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Criterio", "%" + criterio + "%");

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

                                // Crear el pago con los datos obtenidos
                                Pago pago = new Pago
                                {
                                    IdPago = reader.GetInt32(reader.GetOrdinal("id_pago")),
                                    Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion_Pago")) ? "Sin descripción" : reader.GetString(reader.GetOrdinal("descripcion_Pago")),
                                    Importe = reader.GetDouble(reader.GetOrdinal("importe_Pago")),
                                    IdTipoPago = reader.GetInt32(reader.GetOrdinal("id_TipoPago")),
                                    IdEstadoPago = reader.GetInt32(reader.GetOrdinal("id_EstadoPago")),
                                    NombreEstadoPedido = reader.IsDBNull(reader.GetOrdinal("NombreEstadoPedido")) ? "Sin estado" : reader.GetString(reader.GetOrdinal("NombreEstadoPedido")),
                                    NombreEstadoPago = reader.IsDBNull(reader.GetOrdinal("NombreEstadoPago")) ? "Sin estado" : reader.GetString(reader.GetOrdinal("NombreEstadoPago")),
                                    NombreTipoPago = reader.IsDBNull(reader.GetOrdinal("NombreTipoPago")) ? "Sin datos" : reader.GetString(reader.GetOrdinal("NombreTipoPago")),
                                    CUIL_Empleado = reader.GetString(reader.GetOrdinal("CUIL_Empleado")),
                                    NombreCompleto = reader.IsDBNull(reader.GetOrdinal("NombreEmpleado"))
                                        ? "N/A"
                                        : reader.GetString(reader.GetOrdinal("NombreEmpleado")),
                                    DetallesVehiculo = reader.IsDBNull(reader.GetOrdinal("DetallesVehiculo"))
                                        ? "Sin detalles"
                                        : reader.GetString(reader.GetOrdinal("DetallesVehiculo")),
                                    CUIL_Cliente = cuilCuitCliente,
                                    NombreCliente = nombreCliente
                                };

                                listaPagos.Add(pago);
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception("Error SQL al obtener los pagos: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error general al obtener los pagos: " + ex.Message);
            }

            return listaPagos;
        }

    }
}
