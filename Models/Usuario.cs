using System;

namespace CarniceriaPOS.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int IdRol { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string NombreRol { get; set; }
        public string NombreEmpleado { get; set; }

        public Usuario()
        {
            FechaCreacion = DateTime.Now;
            Activo = true;
        }
    }
}
