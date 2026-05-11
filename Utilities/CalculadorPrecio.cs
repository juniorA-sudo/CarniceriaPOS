using System;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Utilities
{
    public static class CalculadorPrecio
    {
        
        
        
        public static decimal CalcularSubtotal(Producto producto, decimal cantidad)
        {
            if (producto == null) return 0;

            return producto.PrecioVenta * cantidad;
        }

        
        
        
        public static decimal CalcularCambio(decimal montoRecibido, decimal total, int metodoId)
        {
            
            if (metodoId == (int)MetodoPagoEnum.Efectivo)
            {
                return montoRecibido - total;
            }
            return 0m;
        }

        
        
        
        public static decimal CalcularImpuesto(decimal subtotal)
        {
            return subtotal * 0.12m;
        }

        
        
        
        public static decimal CalcularTotal(decimal subtotal)
        {
            decimal impuesto = CalcularImpuesto(subtotal);
            return subtotal + impuesto;
        }

        
        
        
        public static bool EsMontoSuficiente(decimal montoRecibido, decimal total, int metodoId)
        {
            
            if (metodoId == (int)MetodoPagoEnum.Efectivo)
            {
                return montoRecibido >= total;
            }
            
            return true;
        }

        
        
        
        public static string ObtenerMensajeMontoInsuficiente(decimal montoRecibido, decimal total)
        {
            decimal faltante = total - montoRecibido;
            return $"Monto insuficiente. Faltan ${faltante:N2}";
        }
    }
}
