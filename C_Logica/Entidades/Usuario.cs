using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; } // ID usuario
        public string CuilEmpleado { get; set; } // Cuil del empleado (FK)
        public string PassswordUsuario { get; set; } //Contaseña Usuario
        public Empleado Empleado { get; set; }
        public string PerfilNombre { get; set; }
    }
}
