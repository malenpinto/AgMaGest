using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Pago
    {
        public int IdPago { get; set; }
        public string Descripcion { get; set; }
        public double Importe { get; set; }
        public int IdTipoPago { get; set; }
        public int IdEstadoPago { get; set; }
        public int IdPedido { get; set; }
    }
}