using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class DetallePedido
    {
        public int IdVehiculo { get; set; } // Id_Vehiculo (FK)
        public int IdPedido { get; set; } // Id_Pedido (FK)
        public double Subtotal { get; set; } // Subtotal de la compra
    }
}
