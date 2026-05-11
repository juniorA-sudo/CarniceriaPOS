using System;
using System.Collections.Generic;

namespace CarniceriaPOS.Models
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public string NumeroFacturaProv { get; set; }
        public int IdProveedor { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        
        public string NombreProveedor { get; set; }
        public string NombreUsuario { get; set; }
        public List<DetalleCompra> Detalles { get; set; }

        public Compra()
        {
            FechaCompra = DateTime.Now;
            Estado = "Completada";
            Detalles = new List<DetalleCompra>();
        }
    }
}
