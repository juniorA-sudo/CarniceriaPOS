using System;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Utilities
{
    public static class GestorCredito
    {
        
        
        
        public static bool EsVentaCredito(string metodoPago)
        {
            if (string.IsNullOrEmpty(metodoPago)) return false;
            return metodoPago.Equals("Credito", StringComparison.OrdinalIgnoreCase);
        }

        
        
        
        public static void ConfigurarVentaCredito(Venta venta, string metodoPago, Cliente cliente)
        {
            if (venta == null) throw new ArgumentNullException(nameof(venta));
            if (string.IsNullOrEmpty(metodoPago)) throw new ArgumentNullException(nameof(metodoPago));

            venta.MetodoPago = metodoPago;

            
            if (EsVentaCredito(metodoPago))
            {
                if (cliente == null)
                    throw new InvalidOperationException("Cliente es requerido para ventas a credito");

                venta.IdCliente = cliente.IdCliente;
            }
            else
            {
                
                if (cliente != null)
                    venta.IdCliente = cliente.IdCliente;
            }
        }

        
        
        
        public static bool ValidarDatosCredito(Venta venta, string metodoPago)
        {
            if (venta == null || string.IsNullOrEmpty(metodoPago)) return false;

            
            if (EsVentaCredito(metodoPago) && (!venta.IdCliente.HasValue || venta.IdCliente.Value <= 0))
                return false;

            return true;
        }

        
        
        
        public static string ObtenerMensajeErrorCredito(Venta venta, string metodoPago)
        {
            if (EsVentaCredito(metodoPago) && (!venta?.IdCliente.HasValue ?? false))
                return "Debe seleccionar un cliente para ventas a credito";

            return "";
        }
    }
}
