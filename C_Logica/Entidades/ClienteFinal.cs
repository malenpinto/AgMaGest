using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class ClienteFinal
    {
        public int IdClienteFinal { get; set; }
        public string NombreCFinal { get; set; }
        public string ApellidoCFinal { get; set; }
        public string DniCFinal { get; set; }
        public string CuilCFinal { get; set; }
        public DateTime FechaNacCFinal { get; set; }
        public int IdCliente { get; set; }
    }
}
