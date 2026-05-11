using System;

namespace CarniceriaPOS.Models
{

    public class CreditoCliente
    {
        public int IdCredito { get; set; }
        public int IdCliente { get; set; }
        public decimal SaldoDeudor { get; set; } 
        public decimal LimiteCredito { get; set; } 
        public DateTime FechaUltimaCompra { get; set; }
        public DateTime FechaUltimoPago { get; set; }
        public int DiasAtraso { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public bool PuedeCreditoDisponible(decimal montoCompra)
        {
            return (LimiteCredito - SaldoDeudor) >= montoCompra;
        }

        public decimal ObtenerCreditoDisponible()
        {
            return LimiteCredito - SaldoDeudor;
        }
    }
}
