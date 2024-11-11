using System;
using System.Drawing;

namespace AgMaGest.C_Logica.Entidades
{
    public class Vehiculos
    {
        public int IdVehiculo { get; set; } // id_Vehiculo en SQL
        public string Marca { get; set; } // marca_Vehiculo en SQL
        public string Modelo { get; set; } // modelo_Vehiculo en SQL (cambiado a string)
        public string Version { get; set; } // version_Vehiculo en SQL (cambiado a string)
        public int Kilometraje { get; set; } // km_Vehiculo en SQL
        public DateTime Anio { get; set; } // anio_Vehiculo en SQL
        public string Patente { get; set; } // patente_Vehiculo en SQL (nullable)
        public int? CodigoOKM { get; set; } // codigo_OKM en SQL (nullable)
        public double Precio { get; set; } // precio_Vehiculo en SQL (cambiado a double)
        public int IdTipoVehiculo { get; set; } // id_tipoVehiculo en SQL (clave foránea)
        public int IdEstado { get; set; } // id_Estado en SQL (clave foránea)
        public int IdCondicion { get; set; } // id_Condicion en SQL (clave foránea)
        public string RutaImagen { get; set; } // Para almacenar la ruta de la imagen 
        public Image Imagen { get; set; }

        // Relaciones
        public string CondicionNombre { get; set; }
        public string TipoNombre { get; set; }
        public string EstadoNombre { get; set; }

    }
}
