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

                    // El SQL para insertar un nuevo pago en la tabla
                    string query = @"
                        INSERT INTO Pago (descripcion_Pago, importe_Pago, id_TipoPago, id_EstadoPago, id_Pedido)
                        VALUES (@Descripcion, @Importe, @IdTipoPago, @IdEstadoPago, @IdPedido);
            
                        -- Obtener el id_pago recién insertado
                        SELECT SCOPE_IDENTITY();";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    // Asignar valores a los parámetros
                    cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(pago.Descripcion) ? (object)DBNull.Value : pago.Descripcion);
                    cmd.Parameters.AddWithValue("@Importe", pago.Importe);
                    cmd.Parameters.AddWithValue("@IdTipoPago", pago.IdTipoPago);
                    cmd.Parameters.AddWithValue("@IdEstadoPago", pago.IdEstadoPago);
                    cmd.Parameters.AddWithValue("@IdPedido", pago.IdPedido);

                    // Ejecutar el comando y recuperar el ID del pago recién insertado
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        pago.IdPago = Convert.ToInt32(result);  // Asignar el ID al objeto pago
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


        // Método para obtener una lista de pagos por ID de pedido
        public List<Pago> ObtenerPagosPorPedido(int idPedido)
        {
            List<Pago> pagos = new List<Pago>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT id_pago, descripcion_Pago, importe_Pago, id_TipoPago, id_EstadoPago, id_Pedido
                    FROM Pago
                    WHERE id_Pedido = @IdPedido";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pago pago = new Pago
                            {
                                IdPago = reader.GetInt32(0),
                                Descripcion = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Importe = reader.GetDouble(2),
                                IdTipoPago = reader.GetInt32(3),
                                IdEstadoPago = reader.GetInt32(4),
                                IdPedido = reader.GetInt32(5)
                            };

                            pagos.Add(pago);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return pagos;
        }

        // Método para actualizar el estado de un pago
        public bool ActualizarEstadoPago(int idPago, int nuevoEstadoPago)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    UPDATE Pago
                    SET id_EstadoPago = @NuevoEstadoPago
                    WHERE id_pago = @IdPago";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NuevoEstadoPago", nuevoEstadoPago);
                    cmd.Parameters.AddWithValue("@IdPago", idPago);

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

        // Método para eliminar un pago
        public bool EliminarPago(int idPago)
        {
            bool resultado = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    DELETE FROM Pago
                    WHERE id_pago = @IdPago";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdPago", idPago);

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

        // Método para obtener todos los pagos
        public List<Pago> ObtenerTodosLosPagos()
        {
            List<Pago> pagos = new List<Pago>();

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = @"
                    SELECT id_pago, descripcion_Pago, importe_Pago, id_TipoPago, id_EstadoPago, id_Pedido
                    FROM Pago";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pago pago = new Pago
                            {
                                IdPago = reader.GetInt32(0),
                                Descripcion = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Importe = reader.GetDouble(2),
                                IdTipoPago = reader.GetInt32(3),
                                IdEstadoPago = reader.GetInt32(4),
                                IdPedido = reader.GetInt32(5)
                            };

                            pagos.Add(pago);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error de SQL: {ex.Message}");
                throw;
            }

            return pagos;
        }
    }
}
