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


        // Método para obtener la lista de perfiles
        public List<TipoVehiculo> ObtenerTipoVehiculo()
        {
            List<TipoVehiculo> tiposVehiculo = new List<TipoVehiculo>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id_tipoVehiculo, nombre_tipoVehiculo FROM Tipo_Vehiculo", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoVehiculo tipoVehiculo = new TipoVehiculo()
                        {
                            IdTipoVehiculo = reader.GetInt32(0),  
                            NombreTipoVehiculo = reader.GetString(1) 
                        };

                        tiposVehiculo.Add(tipoVehiculo);
                    }
                }
            }
            catch (SqlException ex)
            {
                // Manejo de errores relacionados con SQL
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw; 
            }
            catch (Exception ex)
            {
                // Manejo de otros tipos de errores
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return tiposVehiculo;
        }
        

        // Método para insertar un nuevo empleado en la base de datos
        public bool InsertarVehiculo(Vehiculos vehiculo)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Vehiculo (marca_Vehiculo, modelo_Vehiculo, version_Vehiculo, km_Vehiculo, anio_Vehiculo, patente_Vehiculo,"+
                        "codigo_OKM, precio_Vehiculo, id_tipoVehiculo, id_Estado, id_Condicion) " +
                        "VALUES (@Marca, @Modelo, @Version, @KM, @Anio, @Patente, @Codigo0KM, @Precio, @IdTipoVehiculo, @IdEstado, @IdCondicion)", conn);


                    // Añadir los parámetros al comando SQL
                    cmd.Parameters.AddWithValue("@Marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue("@Modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue("@Version", vehiculo.Version);
                    cmd.Parameters.AddWithValue("@KM", vehiculo.Kilometraje);
                    cmd.Parameters.AddWithValue("@Anio", vehiculo.Anio);
                    cmd.Parameters.AddWithValue("@Patente", vehiculo.Patente);
                    cmd.Parameters.AddWithValue("@Codigo0KM", vehiculo.CodigoOKM);
                    cmd.Parameters.AddWithValue("@Precio", vehiculo.Precio);
                    cmd.Parameters.AddWithValue("@IdTipoVehiculo", vehiculo.IdTipoVehiculo);
                    cmd.Parameters.AddWithValue("@IdEstado", vehiculo.IdEstado);
                    cmd.Parameters.AddWithValue("@IdCondicion", vehiculo.IdEstado);

                    // Ejecutar el comando de inserción
                    cmd.ExecuteNonQuery();
                }

                return true; // Inserción exitosa
            }
            catch (SqlException ex)
            {
                // Verificar si el error es por duplicado (clave única violada)
                if (ex.Number == 2627 || ex.Number == 2601) // Violación de índice único
                {
                    throw new Exception("Ya existe un empleado con este DNI, CUIL o email.");
                }
                throw;
            }
        }
    }
}
