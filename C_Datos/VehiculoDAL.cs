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


        // Método para insertar un nuevo empleado en la base de datos
        public bool InsertarVehiculo(Vehiculos vehiculo, byte[] imagen = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();

                    // Comando para insertar el vehículo y obtener el ID generado
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Vehiculos (marca_Vehiculo, modelo_Vehiculo, version_Vehiculo, km_Vehiculo, anio_Vehiculo, patente_Vehiculo," +
                        "codigo_OKM, precio_Vehiculo, id_tipoVehiculo, id_Estado, id_Condicion, imagen) " +
                        "VALUES (@Marca, @Modelo, @Version, @KM, @Anio, @Patente, @CodigoOKM, @Precio, @IdTipoVehiculo, @IdEstado, @IdCondicion, @Imagen); " +
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
                    cmd.Parameters.AddWithValue("@Imagen", imagen ?? (object)DBNull.Value);

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
                        "   INSERT INTO Inventario_Vehiculos (id_Vehiculo, stock, precio_unitario) VALUES (@IdVehiculo, 1, @PrecioUnitario); " +
                        "END", conn);

                    // Añadir parámetros para el inventario
                    cmdUpdateStock.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                    cmdUpdateStock.Parameters.AddWithValue("@PrecioUnitario", vehiculo.Precio);

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
    }
}
