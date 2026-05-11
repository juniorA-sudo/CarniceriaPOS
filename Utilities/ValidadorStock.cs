using System;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Utilities
{
    public static class ValidadorStock
    {
        
        
        
        public static bool ValidarStock(Producto producto, decimal cantidad)
        {
            if (producto == null) return false;

            return producto.StockActual >= cantidad;
        }

        
        
        
        public static string ObtenerMensajeError(Producto producto, decimal requerido)
        {
            if (producto == null) return "Producto no vÃ¡lido";

            string unidad = !string.IsNullOrEmpty(producto.AbreviacionUnidad) ?
                producto.AbreviacionUnidad : "unidades";

            return $"Stock disponible: {producto.StockActual:F2} {unidad}\n" +
                   $"Stock requerido: {requerido:F2} {unidad}";
        }

        
        
        
        public static bool EstaStockBajo(Producto producto)
        {
            if (producto == null) return false;

            return producto.StockActual <= producto.StockMinimo;
        }
    }
}
