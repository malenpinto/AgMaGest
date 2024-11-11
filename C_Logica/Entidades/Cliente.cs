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
        public string DireccionCompleta
        {
            get
            {
                return $"{CalleCliente} {NumCalle}" +
                       (PisoCliente.HasValue ? $", Piso {PisoCliente.Value}" : "") +
                       (!string.IsNullOrWhiteSpace(DptoCliente) ? $", Dpto {DptoCliente}" : "");
            }
        }
        public string LocalidadNombre { get; set; }
        public string ProvinciaNombre { get; set; }
        public string PaisNombre { get; set; }
        public string CuilCuit
        {
            get
            {
                if (this is ClienteFinal clienteFinal)
                {
                    return clienteFinal.CuilCFinal;
                }
                else if (this is ClienteEmpresa clienteEmpresa)
                {
                    return clienteEmpresa.CuitCEmpresa;
                }
                return string.Empty;
            }
        }

        public string NombreCompletoRazonSocial
        {
            get
            {
                if (this is ClienteFinal clienteFinal)
                {
                    return $"{clienteFinal.NombreCFinal} {clienteFinal.ApellidoCFinal}";
                }
                else if (this is ClienteEmpresa clienteEmpresa)
                {
                    return clienteEmpresa.RazonSocialCEmpresa;
                }
                return string.Empty;
            }
        }
        public string EstadoNombre { get; set; }
    }
}
