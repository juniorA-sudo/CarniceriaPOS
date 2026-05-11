using System;

namespace CarniceriaPOS.Models
{
    public class MovimientoInventario
    {
        public int IdMovimiento { get; set; }
        public int IdProducto { get; set; }
        public string Tipo { get; set; }  
        public int Cantidad { get; set; }
        public int IdUsuario { get; set; }
        public string Razon { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}
