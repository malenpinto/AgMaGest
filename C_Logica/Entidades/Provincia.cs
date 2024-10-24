using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Provincia
    {
        public int IdProvincia { get; set; } // ID de la provincia
        public string NombreProvincia { get; set; } // Nombre de la provincia
        public int IdPais { get; set; } //ID del país al que pertenece la provincia
    }
}