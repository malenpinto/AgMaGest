using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Factura
    {
        public int NumFactura { get; set; }
        public DateTime FechaFactura { get; set; }
        public double TotalFactura { get; set; } 
        public int IdPago { get; set; }
    }
}