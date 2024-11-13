using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Pedido
    {
        public int IdPedido { get; set; } // Id_Pedido (PK)
        public string CUIL { get; set; } // Código Único de Identificación Laboral (FK)
        public int IdCliente { get; set; } //Id del cliente
        public int IdVehiculo { get; set; } //Id del vehiculo
        public DateTime FechaPedido { get; set; } // Fecha de realizacion del pedido
        public double MontoPedido { get; set; } // Id del monto a pagar
    }
}