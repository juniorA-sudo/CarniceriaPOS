using System;

namespace CarniceriaPOS.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public int? IdDepartamento { get; set; }
        public string Puesto { get; set; }
        public decimal? Salario { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string NombreDepartamento { get; set; }

        public Empleado()
        {
            FechaCreacion = DateTime.Now;
            Activo = true;
        }
    }
}
