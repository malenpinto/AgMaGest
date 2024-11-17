using AgMaGest.C_Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string NombreEstadoPago { get; set; }
        public string NombreTipoPago { get; set; }
        public string NombreEstadoPedido { get; set; }
        public string CUIL_Empleado { get; set; }
        public string NombreCompleto { get; set; }
        public string DetallesVehiculo { get; set; }
        public string CUIL_Cliente { get; set; }
        public string NombreCliente { get; set; }
    }
}