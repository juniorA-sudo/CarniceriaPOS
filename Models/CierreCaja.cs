using System;

namespace CarniceriaPOS.Models
{
    public class CierreCaja
    {
        public int IdCierre { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaApertura { get; set; }
        public DateTime FechaClosing { get; set; }
        public decimal MontoApertura { get; set; }
        public decimal MontoEsperado { get; set; }
        public decimal MontoReal { get; set; }
        public decimal Diferencia { get; set; }
        public string Estado { get; set; }

        public string NombreUsuario { get; set; }

        public CierreCaja()
        {
            Estado = "Abierto";
            FechaClosing = DateTime.Now;
        }
    }
}
