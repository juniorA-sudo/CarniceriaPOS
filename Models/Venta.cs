using System;
using System.Collections.Generic;

namespace CarniceriaPOS.Models
{

    public class Venta
    {
        public int IdVenta { get; set; }
        public string NumeroFactura { get; set; }
        public int? IdCliente { get; set; }                
        public int IdEmpleado { get; set; }
        public DateTime FechaVenta { get; set; }
        public string MetodoPago { get; set; }              

        public decimal Subtotal { get; set; }
        public decimal TotalITBIS { get; set; }             
        public decimal Total { get; set; }

        public decimal MontoRecibido { get; set; }
        public decimal Cambio { get; set; }

        public string Estado { get; set; }                  

        public string NombreCliente { get; set; }
        public string NombreUsuario { get; set; }
        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            FechaVenta = DateTime.Now;
            Estado = "Completada";
            Detalles = new List<DetalleVenta>();
        }
    }
}
