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

        public void InsertarPedido(Pedido pedido)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Pedido (cuil_Empleado, num_Factura, id_Cliente, fecha_Pedido) " +
                               "VALUES (@cuil_Empleado, @num_Factura, @id_Cliente, @fecha_Pedido); " +
                               "SELECT SCOPE_IDENTITY();"; // Esto devuelve el Id_Pedido generado

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@cuil_Empleado", pedido.CUIL);
                command.Parameters.AddWithValue("@num_Factura", pedido.NumFactura);
                command.Parameters.AddWithValue("@id_Cliente", pedido.IdCliente);
                command.Parameters.AddWithValue("@fecha_Pedido", pedido.FechaPedido);

                connection.Open();
                pedido.IdPedido = Convert.ToInt32(command.ExecuteScalar()); // Obtiene el Id generado
            }
        }

        public Pedido ObtenerPedido(int idPedido)
        {
            Pedido pedido = null;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT id_Pedido, cuil_Empleado, num_Factura, id_Cliente, fecha_Pedido FROM Pedido WHERE id_Pedido = @id_Pedido";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id_Pedido", idPedido);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pedido = new Pedido
                        {
                            IdPedido = Convert.ToInt32(reader["id_Pedido"]),
                            CUIL = reader["cuil_Empleado"].ToString(),
                            NumFactura = Convert.ToInt32(reader["num_Factura"]),
                            IdCliente = Convert.ToInt32(reader["id_Cliente"]),
                            FechaPedido = Convert.ToDateTime(reader["fecha_Pedido"])
                        };
                    }
                }
            }
            return pedido;
        }
    }
}
