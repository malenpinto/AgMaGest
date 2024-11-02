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
        public int NumFactura { get; set; } // Numero de Factura (FK)
        public int IdCliente { get; set; } // Id_Cliente (FK)
        public DateTime FechaPedido { get; set; } // Fecha  de realizacion del pedido
    }
}
