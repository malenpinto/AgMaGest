using System;

namespace AgMaGest.C_Logica.Entidades
{
    public class Provincia
    {
        // Propiedad para el ID de la provincia
        public int IdProvincia { get; set; }

        // Propiedad para el nombre de la provincia
        public string NombreProvincia { get; set; }

        // Propiedad para el ID del país al que pertenece la provincia
        public int IdPais { get; set; }
    }
}