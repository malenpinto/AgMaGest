using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AgMaGest.C_Logica.Entidades;
using System.Configuration;


namespace AgMaGest.C_Datos
{
    public class PedidoDAL
    {
        // Obtener la cadena de conexión desde app.config
        private string ConnectionString = ConfigurationManager.ConnectionStrings["AgMaGest.Properties.Settings.AgmagestConnectionString"].ConnectionString;

        public bool InsertarPedido(Pedido pedido)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para insertar el pedido
                    string query = @"
                        INSERT INTO Pedido (cuil_Empleado, id_Cliente, id_Vehiculo, fecha_Pedido, monto_Pedido)
                        VALUES (@CuilEmpleado, @IdCliente, @IdVehiculo, @FechaPedido, @MontoPedido);
                    ";

                    // Crear el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar parámetros a la consulta
                        command.Parameters.AddWithValue("@CuilEmpleado", pedido.CUIL);
                        command.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
                        command.Parameters.AddWithValue("@IdVehiculo", pedido.IdVehiculo);
                        command.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                        command.Parameters.AddWithValue("@MontoPedido", pedido.MontoPedido);

                        // Ejecutar la consulta
                        int result = command.ExecuteNonQuery();

                        // Si la ejecución fue exitosa (se insertó al menos una fila)
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones (puedes personalizar esto según tus necesidades)
                    Console.WriteLine("Error al insertar el pedido: " + ex.Message);
                    return false;
                }
            }
        }


        public bool ActualizarPedido(Pedido pedido)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para actualizar el pedido
                    string query = @"
                        UPDATE Pedido
                        SET cuil_Empleado = @CuilEmpleado,
                            id_Cliente = @IdCliente,
                            id_Vehiculo = @IdVehiculo,
                            fecha_Pedido = @FechaPedido,
                            monto_Pedido = @MontoPedido
                        WHERE id_Pedido = @IdPedido;
                    ";

                    // Crear el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar los parámetros a la consulta
                        command.Parameters.AddWithValue("@IdPedido", pedido.IdPedido);
                        command.Parameters.AddWithValue("@CuilEmpleado", pedido.CUIL);
                        command.Parameters.AddWithValue("@IdCliente", pedido.IdCliente);
                        command.Parameters.AddWithValue("@IdVehiculo", pedido.IdVehiculo);
                        command.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                        command.Parameters.AddWithValue("@MontoPedido", pedido.MontoPedido);

                        // Ejecutar la consulta
                        int result = command.ExecuteNonQuery();

                        // Retornar verdadero si se actualizó al menos una fila
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al actualizar el pedido: " + ex.Message);
                    return false;
                }
            }
        }

        public bool EliminarPedido(int idPedido)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para eliminar un pedido
                    string query = @"
                            DELETE FROM Pedido
                            WHERE id_Pedido = @IdPedido;
                        ";

                    // Crear el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar el parámetro para el ID del pedido
                        command.Parameters.AddWithValue("@IdPedido", idPedido);

                        // Ejecutar la consulta
                        int result = command.ExecuteNonQuery();

                        // Retornar verdadero si se eliminó al menos una fila
                        return result > 0;
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al eliminar el pedido: " + ex.Message);
                    return false;
                }
            }
        }


        public Pedido ObtenerPedido(int idPedido)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Consulta SQL para obtener un pedido específico
                    string query = @"
                        SELECT id_Pedido, cuil_Empleado, id_Cliente, id_Vehiculo, fecha_Pedido, monto_Pedido
                        FROM Pedido
                        WHERE id_Pedido = @IdPedido;
                    ";

                    // Crear el comando SQL
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Agregar el parámetro para el ID del pedido
                        command.Parameters.AddWithValue("@IdPedido", idPedido);

                        // Ejecutar la consulta y leer el resultado
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Crear un objeto Pedido y asignar los valores
                                Pedido pedido = new Pedido
                                {
                                    IdPedido = reader.GetInt32(0),
                                    CUIL = reader.GetString(1),
                                    IdCliente = reader.GetInt32(2),
                                    IdVehiculo = reader.GetInt32(3),
                                    FechaPedido = reader.GetDateTime(4),
                                    MontoPedido = reader.GetDouble(5)
                                };

                                return pedido;
                            }
                            else
                            {
                                // Si no se encontró el pedido, retornar null
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones
                    Console.WriteLine("Error al obtener el pedido: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
