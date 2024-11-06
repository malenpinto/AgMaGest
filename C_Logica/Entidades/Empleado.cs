using System;

namespace AgMaGest.C_Logica.Entidades
{
    public class Empleado
    {
        public string CUIL { get; set; } // Código Único de Identificación Laboral (PK)
        public string DNI { get; set; } // Documento Nacional de Identidad (Unique)
        public string Nombre { get; set; } // Nombre del empleado
        public string Apellido { get; set; } // Apellido del empleado
        public string Email { get; set; } // Correo electrónico (Unique)
        public string Celular { get; set; } // Número de celular
        public DateTime FechaNacimiento { get; set; } // Fecha de Nacimiento
        public string Calle { get; set; } // Calle donde reside
        public int NumeroCalle { get; set; } // Número de la calle
        public int? Piso { get; set; } // Piso del edificio (Nullable)
        public string Dpto { get; set; } // Departamento (Nullable)
        public int CodigoPostal { get; set; } // Código postal
        public int IdLocalidad { get; set; } // ID de la localidad (FK)
        public int IdPerfil { get; set; } // ID del perfil del empleado (FK)
        public int IdEstado { get; set; } // ID del estado del empleado (FK)
        public string DireccionCompleta { get; set; }
        public string LocalidadNombre { get; set; }
        public string ProvinciaNombre { get; set; }
        public string PaisNombre { get; set; }
        public string PerfilNombre { get; set; }
        public string EstadoNombre { get; set; }

    }
}
