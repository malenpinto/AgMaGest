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
                UPDATE Vehiculo
                SET id_EstadoVehiculo = @NuevoEstado
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

    }
}
