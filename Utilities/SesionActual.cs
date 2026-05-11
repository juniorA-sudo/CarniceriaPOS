using CarniceriaPOS.Models;

namespace CarniceriaPOS.Utilities
{
    public static class SesionActual
    {
        public static Usuario UsuarioActual { get; set; }
        public static Rol RolActual { get; set; }

        public static void IniciarSesion(Usuario usuario, Rol rol)
        {
            UsuarioActual = usuario;
            RolActual = rol;
        }

        public static void CerrarSesion()
        {
            UsuarioActual = null;
            RolActual = null;
        }

        public static bool EstaAutenticado()
        {
            return UsuarioActual != null;
        }

        public static bool TieneAcceso(string modulo)
        {
            if (UsuarioActual == null) return false;

            int idRol = UsuarioActual.IdRol;

            switch (modulo)
            {
                case "Productos":
                    return idRol == 1 || idRol == 2 || idRol == 5;
                case "Clientes":
                    return idRol == 1 || idRol == 2 || idRol == 3;
                case "Proveedores":
                    return idRol == 1 || idRol == 2 || idRol == 5;
                case "Ventas":
                    return idRol == 1 || idRol == 2 || idRol == 3 || idRol == 4;
                case "Compras":
                    return idRol == 1 || idRol == 2 || idRol == 5;
                case "Reportes":
                    return idRol == 1 || idRol == 2;
                case "Usuarios":
                    return idRol == 1 || idRol == 2;
                case "Caja":
                    return idRol == 1 || idRol == 2 || idRol == 4;
                case "Empleados":
                    return idRol == 1 || idRol == 2;
                default:
                    return false;
            }
        }
    }
}
