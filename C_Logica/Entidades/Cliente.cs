using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string EmailCliente { get; set; }
        public string CelularCliente { get; set; }
        public string CalleCliente { get; set; }
        public int NumCalle { get; set; }
        public int? PisoCliente { get; set; }
        public string DptoCliente { get; set; }
        public int CodigoPostalCliente { get; set; }
        public int IdEstadoCliente { get; set; }
        public int IdLocalidad { get; set; }
    }
}
