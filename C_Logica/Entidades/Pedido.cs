﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Pedido
    {
        public int IdPedido { get; set; } // Id_Pedido (PK)
        public string CUIL { get; set; } // Código Único de Identificación Laboral (FK)
        public int IdCliente { get; set; } //Id del cliente
        public int IdVehiculo { get; set; } //Id del vehiculo
        public DateTime FechaPedido { get; set; } // Fecha de realizacion del pedido
        public double MontoPedido { get; set; } // Id del monto a pagar
        public int IdEstadoPedido { get; set; }

        // Propiedades para los datos del empleado
        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string NombreEstadoPedido { get; set; }
        public Vehiculos Vehiculo { get; set; }

        // Propiedad para mostrar los detalles del vehículo en el DataGridView
        public string DetallesVehiculo { get; set; }

        // Propiedades para los datos del empleado
        public string CUIL_Cliente { get; set; }
        public string NombreCliente { get; set; }

        // Propiedad para la imagen del vehículo
        public Image Imagen { get; set; }
        public class VendedorEstadistica
        {
            public string CUIL { get; set; }
            public string NombreEmpleado { get; set; }
            public string ApellidoEmpleado { get; set; }
            public int CantidadPedidos { get; set; }
            public double TotalVentas { get; set; }
        }
    }
}