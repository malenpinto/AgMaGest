using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Localidad
    {
        public int IdLocalidad{ get; set; } // ID de la Localidad
        public string NombreLocalidad { get; set; } // Nombre de la Localidad
        public int IdProvincia { get; set; } //ID de la provincia al que pertenece la Localidad
    }
}
