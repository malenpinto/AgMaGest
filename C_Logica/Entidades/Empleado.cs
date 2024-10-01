using System;

namespace AgMaGest.C_Logica.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } // Nombre del empleado
        public string Apellido { get; set; } // Apellido del empleado
        public string DNI { get; set; } // Documento Nacional de Identidad
        public string CUIL { get; set; } // Código Único de Identificación Laboral
        public string Calle { get; set; } // Calle donde reside
        public string NumeroCalle { get; set; } // Número de la calle
        public string Piso { get; set; } // Piso del edificio
        public string Dpto { get; set; } // Departamento
        public string Email { get; set; } // Correo electrónico
        public string Celular { get; set; } // Número de celular
        public string CodigoPostal { get; set; } // Código postal
        public int IdLocalidad { get; set; } // ID de la localidad
        public int IdPerfil { get; set; } // ID del perfil del empleado
        public int IdEstado { get; set; } // ID del estado
        public string Ciudad { get; set; } // Ciudad donde reside
        public string Pais { get; set; } // País donde reside
        public string Provincia { get; set; } // Provincia donde reside
        public string Localidad { get; set; } // Localidad donde reside

    }
}
