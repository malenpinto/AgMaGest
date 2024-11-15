using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgMaGest.C_Logica.Entidades
{
    public class Pago
    {
        public int IdPago { get; set; }
        public string Descripcion { get; set; }
        public double Importe { get; set; }
        public int IdTipoPago { get; set; }
        public int IdEstadoPago { get; set; }
        public int IdPedido { get; set; }

        public string NombreEmpleado { get; set; }
        public string ApellidoEmpleado { get; set; }
        public string NombreEstadoPedido { get; set; }
        public Vehiculos Vehiculo { get; set; }
        // Propiedad para mostrar los detalles del vehículo en el DataGridView
        public string DetallesVehiculo { get; set; }

        // Propiedad para almacenar el CUIL/CUIT del cliente
        public string DetallesCliente { get; set; }
        // Propiedad para la imagen del vehículo
        public Image Imagen { get; set; }
    }
}