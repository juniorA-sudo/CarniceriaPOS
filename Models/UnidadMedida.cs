using System;

namespace CarniceriaPOS.Models
{

    public class UnidadMedida
    {
        public int IdUnidadMedida { get; set; }
        public string Nombre { get; set; }               
        public string Abreviacion { get; set; }          
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
