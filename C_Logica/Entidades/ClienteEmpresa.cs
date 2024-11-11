using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class ClienteEmpresa : Cliente
    {
        public int IdCEmpresa { get; set; }
        public string CuitCEmpresa { get; set; }
        public string RazonSocialCEmpresa { get; set; }
        public int IdCliente { get; set; } // <- Relación con Cliente

    }
}
