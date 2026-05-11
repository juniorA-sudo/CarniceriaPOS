using System;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Business
{

    public class CalculadorDescuentos
    {

        public static decimal ObtenerPorcentajeDescuento(decimal pesoKg)
        {
            if (pesoKg >= 10)
                return 15; 
            else if (pesoKg >= 5)
                return 10; 
            else if (pesoKg >= 2)
                return 5; 
            else
                return 0; 
        }

        public static decimal ObtenerPorcentajeDescuentoUnidades(int cantidad)
        {
            if (cantidad >= 20)
                return 12; 
            else if (cantidad >= 10)
                return 8; 
            else if (cantidad >= 5)
                return 5; 
            else
                return 0; 
        }

        public static decimal CalcularPrecioConDescuento(decimal precioOriginal, decimal porcentajeDescuento)
        {
            if (porcentajeDescuento <= 0)
                return precioOriginal;

            decimal descuento = precioOriginal * (porcentajeDescuento / 100);
            return precioOriginal - descuento;
        }

        public static string ObtenerDescripcionDescuento(decimal pesoKg, decimal porcentajeDescuento)
        {
            if (porcentajeDescuento <= 0)
                return "Sin descuento";

            return $"Descuento por volumen: {porcentajeDescuento}% ({pesoKg:F2} kg)";
        }
    }
}
