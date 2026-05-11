using System;

namespace CarniceriaPOS.Models
{
    
    
    
    
    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool RequiereVerificacion { get; set; }     
        public DateTime FechaCreacion { get; set; }

        public override string ToString() => Nombre;
    }

    public enum MetodoPagoEnum
    {
        Efectivo = 1,
        TarjetaDebito = 2,
        TarjetaCredito = 3,
        Credito = 4
    }
}
