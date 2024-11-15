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
    public class VehiculoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        // Método para insertar un nuevo vehículo en la base de datos
        public bool InsertarVehiculo(Vehiculos vehiculo, string rutaImagen = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Comando para insertar el vehículo y obtener el ID generado
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Vehiculos (marca_Vehiculo, modelo_Vehiculo, version_Vehiculo, km_Vehiculo, anio_Vehiculo, patente_Vehiculo, " +
                        "codigo_OKM, precio_Vehiculo, id_tipoVehiculo, id_Estado, id_Condicion, ruta_imagen) " +
                        "VALUES (@Marca, @Modelo, @Version, @KM, @Anio, @Patente, @CodigoOKM, @Precio, @IdTipoVehiculo, @IdEstado, @IdCondicion, @RutaImagen); " +
                        "SELECT SCOPE_IDENTITY();", conn);

                    // Añadir los parámetros al comando SQL
                    cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue("@Version", vehiculo.Version);
                    cmd.Parameters.AddWithValue("@KM", vehiculo.Kilometraje);
                    cmd.Parameters.AddWithValue("@Anio", vehiculo.Anio);
                    cmd.Parameters.AddWithValue("@Patente", (object)vehiculo.Patente ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CodigoOKM", (object)vehiculo.CodigoOKM ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Precio", vehiculo.Precio);
                    cmd.Parameters.AddWithValue("@IdTipoVehiculo", vehiculo.IdTipoVehiculo);
                    cmd.Parameters.AddWithValue("@IdEstado", vehiculo.IdEstado);
                    cmd.Parameters.AddWithValue("@IdCondicion", vehiculo.IdCondicion);
                    cmd.Parameters.AddWithValue("@RutaImagen", rutaImagen ?? (object)DBNull.Value);

                    // Ejecutar el comando y obtener el ID del vehículo insertado
                    int idVehiculo = Convert.ToInt32(cmd.ExecuteScalar());

                    // Comando para actualizar o insertar en el inventario
                    SqlCommand cmdUpdateStock = new SqlCommand(
                        "IF EXISTS (SELECT 1 FROM Inventario_Vehiculos WHERE id_Vehiculo = @IdVehiculo) " +
                        "BEGIN " +
                        "   UPDATE Inventario_Vehiculos SET stock = stock + 1 WHERE id_Vehiculo = @IdVehiculo; " +
                        "END " +
                        "ELSE " +
                        "BEGIN " +
                        "   INSERT INTO Inventario_Vehiculos (id_Vehiculo, stock) VALUES (@IdVehiculo, 1); " +
                        "END", conn);

                    // Añadir parámetros para el inventario
                    cmdUpdateStock.Parameters.AddWithValue("@IdVehiculo", idVehiculo);

                    // Ejecutar la actualización o inserción en el inventario
                    cmdUpdateStock.ExecuteNonQuery();
                }

                return true; // Inserción exitosa
            }
            catch (SqlException ex)
            {
                // Verificar si el error es por duplicado (clave única violada)
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("Ya existe un vehículo con esta patente o Código de 0km.");
                }
                throw;
            }
        }

        // Método para obtener un vehículo por ID
        public Vehiculos ObtenerVehiculoPorId(int idVehiculo)
        {
            Vehiculos vehiculo = null;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT v.id_Vehiculo, v.marca_Vehiculo, v.modelo_Vehiculo, v.version_Vehiculo, 
                           v.km_Vehiculo, v.anio_Vehiculo, v.patente_Vehiculo, v.codigo_OKM, 
                           v.precio_Vehiculo, v.id_tipoVehiculo, v.id_Estado, v.id_Condicion, 
                           v.ruta_imagen,
                           t.nombre_TipoVehiculo AS TipoNombre,
                           e.nombre_Estado AS EstadoNombre,
                           c.nombre_Condicion AS CondicionNombre
                    FROM Vehiculos v
                    LEFT JOIN Tipo_Vehiculo t ON v.id_tipoVehiculo = t.id_tipoVehiculo
                    LEFT JOIN Estado_Vehiculo e ON v.id_Estado = e.id_Estado
                    LEFT JOIN Condicion c ON v.id_Condicion = c.id_Condicion
                    WHERE v.id_Vehiculo = @IdVehiculo", conn);

                cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        vehiculo = new Vehiculos
                        {
                            IdVehiculo = (int)reader["id_Vehiculo"],
                            Marca = reader["marca_Vehiculo"].ToString(),
                            Modelo = reader["modelo_Vehiculo"].ToString(),
                            Version = reader["version_Vehiculo"].ToString(),
                            Kilometraje = (int)reader["km_Vehiculo"],
                            Anio = (DateTime)reader["anio_Vehiculo"],
                            Patente = reader["patente_Vehiculo"] as string,
                            CodigoOKM = reader["codigo_OKM"] as int?,
                            Precio = (double)reader["precio_Vehiculo"],
                            IdTipoVehiculo = (int)reader["id_tipoVehiculo"],
                            IdEstado = (int)reader["id_Estado"],
                            IdCondicion = (int)reader["id_Condicion"],
                            RutaImagen = reader["ruta_imagen"] as string,
                    
                            // Nuevos campos para mostrar los nombres
                            TipoNombre = reader["TipoNombre"].ToString(),
                            EstadoNombre = reader["EstadoNombre"].ToString(),
                            CondicionNombre = reader["CondicionNombre"].ToString()
                        };
                    }
                }
            }
            return vehiculo;
        }


        // Método para actualizar un vehículo
        public bool ActualizarVehiculo(Vehiculos vehiculo)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Vehiculos SET marca_Vehiculo = @Marca, modelo_Vehiculo = @Modelo, version_Vehiculo = @Version, " +
                    "km_Vehiculo = @KM, anio_Vehiculo = @Anio, patente_Vehiculo = @Patente, codigo_OKM = @CodigoOKM, precio_Vehiculo = @Precio, " +
                    "id_tipoVehiculo = @IdTipoVehiculo, id_Estado = @IdEstado, id_Condicion = @IdCondicion, ruta_imagen = @RutaImagen " +
                    "WHERE id_Vehiculo = @IdVehiculo", conn);

                cmd.Parameters.AddWithValue("@IdVehiculo", vehiculo.IdVehiculo);
                cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                cmd.Parameters.AddWithValue("@Version", vehiculo.Version);
                cmd.Parameters.AddWithValue("@KM", vehiculo.Kilometraje);
                cmd.Parameters.AddWithValue("@Anio", vehiculo.Anio);
                cmd.Parameters.AddWithValue("@Patente", (object)vehiculo.Patente ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodigoOKM", (object)vehiculo.CodigoOKM ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Precio", vehiculo.Precio);
                cmd.Parameters.AddWithValue("@IdTipoVehiculo", vehiculo.IdTipoVehiculo);
                cmd.Parameters.AddWithValue("@IdEstado", vehiculo.IdEstado);
                cmd.Parameters.AddWithValue("@IdCondicion", vehiculo.IdCondicion);
                cmd.Parameters.AddWithValue("@RutaImagen", (object)vehiculo.RutaImagen ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Método para eliminar un vehículo
        public bool EliminarVehiculo(int idVehiculo)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Vehiculos WHERE id_Vehiculo = @IdVehiculo", conn);
                cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Método para obtener todos los vehículos
        public List<Vehiculos> ObtenerTodosLosVehiculos()
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string query = @"
                    SELECT v.id_Vehiculo, v.marca_Vehiculo, v.modelo_Vehiculo, v.version_Vehiculo, 
                           v.km_Vehiculo, v.anio_Vehiculo, v.patente_Vehiculo, v.codigo_OKM, 
                           v.precio_Vehiculo, v.id_tipoVehiculo, v.id_Estado, v.id_Condicion, 
                           v.ruta_imagen, 
                           t.nombre_tipoVehiculo AS TipoNombre, 
                           e.nombre_Estado AS EstadoNombre, 
                           c.nombre_Condicion AS CondicionNombre
                    FROM Vehiculos v
                    LEFT JOIN Tipo_Vehiculo t ON v.id_tipoVehiculo = t.id_tipoVehiculo
                    LEFT JOIN Estado_Vehiculo e ON v.id_Estado = e.id_Estado
                    LEFT JOIN Condicion c ON v.id_Condicion = c.id_Condicion";

                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        vehiculos.Add(new Vehiculos
                        {
                            IdVehiculo = (int)reader["id_Vehiculo"],
                            Marca = reader["marca_Vehiculo"].ToString(),
                            Modelo = reader["modelo_Vehiculo"].ToString(),
                            Version = reader["version_Vehiculo"].ToString(),
                            Kilometraje = (int)reader["km_Vehiculo"],
                            Anio = (DateTime)reader["anio_Vehiculo"],
                            Patente = reader["patente_Vehiculo"] as string,
                            CodigoOKM = reader["codigo_OKM"] as int?,
                            Precio = (double)reader["precio_Vehiculo"],
                            IdTipoVehiculo = (int)reader["id_tipoVehiculo"],
                            IdEstado = (int)reader["id_Estado"],
                            IdCondicion = (int)reader["id_Condicion"],
                            RutaImagen = reader["ruta_imagen"] as string,

                            // Nuevos campos para los nombres
                            TipoNombre = reader["TipoNombre"].ToString(),
                            EstadoNombre = reader["EstadoNombre"].ToString(),
                            CondicionNombre = reader["CondicionNombre"].ToString()
                        });
                    }
                }
            }

            return vehiculos;
        }

        public List<Vehiculos> FiltrarVehiculos(string texto)
        {
            List<Vehiculos> vehiculos = new List<Vehiculos>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Consulta SQL con joins y filtro
                    SqlCommand cmd = new SqlCommand(@"
                SELECT v.id_Vehiculo, 
                       v.marca_Vehiculo, 
                       v.modelo_Vehiculo, 
                       v.version_Vehiculo,
                       v.anio_Vehiculo, 
                       v.km_Vehiculo, 
                       v.patente_Vehiculo, 
                       v.codigo_OKM, 
                       v.precio_Vehiculo, 
                       v.ruta_imagen,
                       c.nombre_Condicion AS CondicionNombre,
                       t.nombre_TipoVehiculo AS TipoNombre,
                       e.nombre_Estado AS EstadoNombre
                FROM Vehiculos v
                INNER JOIN Condicion c ON v.id_Condicion = c.id_Condicion
                INNER JOIN Tipo_Vehiculo t ON v.id_TipoVehiculo = t.id_TipoVehiculo
                INNER JOIN Estado_Vehiculo e ON v.id_Estado = e.id_Estado
                WHERE v.marca_Vehiculo LIKE @texto
                   OR v.modelo_Vehiculo LIKE @texto
                   OR v.version_Vehiculo LIKE @texto
                   OR v.anio_Vehiculo LIKE @texto
                   OR v.patente_Vehiculo LIKE @texto
                   OR v.codigo_OKM LIKE @texto
                   OR c.nombre_Condicion LIKE @texto
                   OR t.nombre_TipoVehiculo LIKE @texto
                   OR e.nombre_Estado LIKE @texto", conn);

                    cmd.Parameters.AddWithValue("@texto", $"%{texto}%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vehiculos vehiculo = new Vehiculos
                            {
                                IdVehiculo = (int)reader["id_Vehiculo"],
                                Marca = reader["marca_Vehiculo"].ToString(),
                                Modelo = reader["modelo_Vehiculo"].ToString(),
                                Version = reader["version_Vehiculo"].ToString(),
                                Kilometraje = (int)reader["km_Vehiculo"],
                                Anio = (DateTime)reader["anio_Vehiculo"],
                                Patente = reader["patente_Vehiculo"] as string,
                                CodigoOKM = reader["codigo_OKM"] as int?,
                                Precio = (double)reader["precio_Vehiculo"],
                                RutaImagen = reader["ruta_imagen"] as string,
                                CondicionNombre = reader["CondicionNombre"].ToString(),
                                TipoNombre = reader["TipoNombre"].ToString(),
                                EstadoNombre = reader["EstadoNombre"].ToString()
                            };

                            vehiculos.Add(vehiculo);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return vehiculos;
        }

        public List<Vehiculos> ObtenerVehiculosActivos()
        {
            List<Vehiculos> inventario = new List<Vehiculos>();
            string query = @"
                    SELECT 
                        v.id_Vehiculo,
                        v.marca_Vehiculo,
                        v.modelo_Vehiculo,
                        v.version_Vehiculo,
                        v.km_Vehiculo,
                        v.anio_Vehiculo,
                        v.patente_Vehiculo,
                        v.codigo_OKM,
                        v.precio_Vehiculo,
                        v.ruta_imagen,
                        t.nombre_TipoVehiculo AS TipoNombre,
                        c.nombre_Condicion AS CondicionNombre
                    FROM Vehiculos v
                    JOIN Tipo_Vehiculo t ON v.id_tipoVehiculo = t.id_tipoVehiculo
                    JOIN Condicion c ON v.id_Condicion = c.id_Condicion
                    WHERE v.id_Estado = 1";  // Filtrar solo vehículos con estado 1

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vehiculos vehiculo = new Vehiculos
                                {
                                    IdVehiculo = reader.GetInt32(reader.GetOrdinal("id_Vehiculo")),
                                    Marca = reader.GetString(reader.GetOrdinal("marca_Vehiculo")),
                                    Modelo = reader.GetString(reader.GetOrdinal("modelo_Vehiculo")),
                                    Version = reader.GetString(reader.GetOrdinal("version_Vehiculo")),
                                    Kilometraje = reader.GetInt32(reader.GetOrdinal("km_Vehiculo")),
                                    Anio = reader.GetDateTime(reader.GetOrdinal("anio_Vehiculo")),
                                    Patente = reader.IsDBNull(reader.GetOrdinal("patente_Vehiculo")) ? null : reader.GetString(reader.GetOrdinal("patente_Vehiculo")),
                                    CodigoOKM = reader.IsDBNull(reader.GetOrdinal("codigo_OKM")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("codigo_OKM")),
                                    Precio = reader.GetDouble(reader.GetOrdinal("precio_Vehiculo")),
                                    RutaImagen = reader.IsDBNull(reader.GetOrdinal("ruta_imagen")) ? null : reader.GetString(reader.GetOrdinal("ruta_imagen")),
                                    CondicionNombre = reader.GetString(reader.GetOrdinal("CondicionNombre")),
                                    TipoNombre = reader.GetString(reader.GetOrdinal("TipoNombre"))
                                };
                                inventario.Add(vehiculo);
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

            return inventario;
        }

        public List<Vehiculos> FiltrarVehiculosActivos(string texto)
        {
            List<Vehiculos> vehiculosFiltrados = new List<Vehiculos>();
            string query = @"
                    SELECT 
                        v.id_Vehiculo,
                        v.marca_Vehiculo,
                        v.modelo_Vehiculo,
                        v.version_Vehiculo,
                        v.km_Vehiculo,
                        v.anio_Vehiculo,
                        v.patente_Vehiculo,
                        v.codigo_OKM,
                        v.precio_Vehiculo,
                        v.ruta_imagen,
                        t.nombre_TipoVehiculo AS TipoNombre,
                        c.nombre_Condicion AS CondicionNombre
                    FROM Vehiculos v
                    JOIN Tipo_Vehiculo t ON v.id_tipoVehiculo = t.id_tipoVehiculo
                    JOIN Condicion c ON v.id_Condicion = c.id_Condicion
                    WHERE v.id_Estado = 1 AND 
                          (v.marca_Vehiculo LIKE @texto OR 
                           v.modelo_Vehiculo LIKE @texto OR 
                           v.version_Vehiculo LIKE @texto)"; // Ajusta los campos según tus necesidades

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Vehiculos vehiculo = new Vehiculos
                                {
                                    IdVehiculo = reader.GetInt32(reader.GetOrdinal("id_Vehiculo")),
                                    Marca = reader.GetString(reader.GetOrdinal("marca_Vehiculo")),
                                    Modelo = reader.GetString(reader.GetOrdinal("modelo_Vehiculo")),
                                    Version = reader.GetString(reader.GetOrdinal("version_Vehiculo")),
                                    Kilometraje = reader.GetInt32(reader.GetOrdinal("km_Vehiculo")),
                                    Anio = reader.GetDateTime(reader.GetOrdinal("anio_Vehiculo")),
                                    Patente = reader.IsDBNull(reader.GetOrdinal("patente_Vehiculo")) ? null : reader.GetString(reader.GetOrdinal("patente_Vehiculo")),
                                    CodigoOKM = reader.IsDBNull(reader.GetOrdinal("codigo_OKM")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("codigo_OKM")),
                                    Precio = reader.GetDouble(reader.GetOrdinal("precio_Vehiculo")),
                                    RutaImagen = reader.IsDBNull(reader.GetOrdinal("ruta_imagen")) ? null : reader.GetString(reader.GetOrdinal("ruta_imagen")),
                                    CondicionNombre = reader.GetString(reader.GetOrdinal("CondicionNombre")),
                                    TipoNombre = reader.GetString(reader.GetOrdinal("TipoNombre"))
                                };
                                vehiculosFiltrados.Add(vehiculo);
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

            return vehiculosFiltrados;
        }
    }
}
