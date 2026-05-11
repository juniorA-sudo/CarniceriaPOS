using System;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.Business
{

    public static class LogAuditoria
    {
        private static ConexionBD bd = new ConexionBD();

        public static void Registrar(string accion, string modulo, string detalles, int? usuarioId = null)
        {
            try
            {
                
                if (!usuarioId.HasValue && Utilities.SesionActual.UsuarioActual != null)
                {
                    usuarioId = Utilities.SesionActual.UsuarioActual.IdUsuario;
                }

                string sql = @"
                    INSERT INTO AuditoriaAcceso
                    (UsuarioId, Accion, Modulo, FechaHora, Detalles)
                    VALUES (@UsuarioId, @Accion, @Modulo, @FechaHora, @Detalles)";

                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@UsuarioId", usuarioId ?? (object)DBNull.Value),
                    new SqlParameter("@Accion", accion),
                    new SqlParameter("@Modulo", modulo),
                    new SqlParameter("@FechaHora", DateTime.Now),
                    new SqlParameter("@Detalles", detalles ?? "")
                };

                bd.EjecutarComando(sql, parametros);
            }
            catch (Exception ex)
            {
                
                System.Diagnostics.Debug.WriteLine("Error registrando auditoria: " + ex.Message);
            }
        }

        public static void RegistrarVentaCreada(int idVenta, int? idCliente, decimal total)
        {
            string detalles = $"IdVenta: {idVenta}, IdCliente: {idCliente}, Total: {total:C0}";
            Registrar("VENTA_CREADA", "POS", detalles);
        }

        public static void RegistrarAccesoDenegado(string modulo, int usuarioId)
        {
            string detalles = $"Intento de acceso a {modulo} sin permisos";
            Registrar("ACCESO_DENEGADO", modulo, detalles, usuarioId);
        }

        public static void RegistrarCreditoOtorgado(int idCliente, decimal monto, string nombreCliente)
        {
            string detalles = $"Cliente: {nombreCliente} (Id: {idCliente}), Monto: {monto:C0}";
            Registrar("CREDITO_OTORGADO", "CREDITO", detalles);
        }

        public static void RegistrarInventarioActualizado(int idProducto, string nombreProducto,
                                                          int stockAnterior, int stockNuevo, string razon)
        {
            string detalles = $"Producto: {nombreProducto}, Stock: {stockAnterior} a’ {stockNuevo}, Razon: {razon}";
            Registrar("INVENTARIO_ACTUALIZADO", "INVENTARIO", detalles);
        }

        public static void RegistrarPagoCredito(int idCliente, decimal monto, string nombreCliente)
        {
            string detalles = $"Cliente: {nombreCliente} (Id: {idCliente}), Pago: {monto:C0}";
            Registrar("PAGO_CREDITO", "CREDITO", detalles);
        }

        public static void RegistrarCierreCaja(int idCierre, decimal montoEsperado, decimal montoReal, decimal diferencia)
        {
            string detalles = $"IdCierre: {idCierre}, Esperado: {montoEsperado:C0}, Real: {montoReal:C0}, Diferencia: {diferencia:C0}";
            Registrar("CIERRE_CAJA", "CAJA", detalles);
        }

        public static void RegistrarProductoModificado(int idProducto, string nombreProducto, string cambios)
        {
            string detalles = $"Producto: {nombreProducto} (Id: {idProducto}), Cambios: {cambios}";
            Registrar("PRODUCTO_MODIFICADO", "INVENTARIO", detalles);
        }

        public static void RegistrarUsuarioCreado(string nombreUsuario, string rol)
        {
            string detalles = $"Usuario: {nombreUsuario}, Rol: {rol}";
            Registrar("USUARIO_CREADO", "USUARIOS", detalles);
        }

        public static void RegistrarLogin(string nombreUsuario, bool exitoso)
        {
            string accion = exitoso ? "LOGIN_EXITOSO" : "LOGIN_FALLIDO";
            string detalles = $"Usuario: {nombreUsuario}";

            int? userId = null;
            try
            {
                var repoUsuario = new Data.RepositorioUsuario();
                var usuario = repoUsuario.ObtenerUsuarioPorEmail(nombreUsuario);
                if (usuario != null)
                    userId = usuario.IdUsuario;
            }
            catch { }

            Registrar(accion, "LOGIN", detalles, userId);
        }

        public static void RegistrarIntentosLoginFallidos(string nombreUsuario, int intentos)
        {
            if (intentos >= 3)
            {
                string detalles = $"Usuario: {nombreUsuario}, Intentos fallidos: {intentos} - POSIBLE ATAQUE";
                Registrar("INTENTOS_LOGIN_FALLIDOS", "SEGURIDAD", detalles);
            }
        }

        public static void RegistrarDevolucion(int idVentaOriginal, decimal monto, string razon)
        {
            string detalles = $"Venta original: {idVentaOriginal}, Monto: {monto:C0}, Razon: {razon}";
            Registrar("DEVOLUCION", "POS", detalles);
        }

        public static void RegistrarCambioConfiguracion(string clave, string valorAnterior, string valorNuevo)
        {
            string detalles = $"Configuracion: {clave}, Anterior: {valorAnterior}, Nuevo: {valorNuevo}";
            Registrar(“CONFIGURACION_CAMBIO”, “ADMINISTRACION”, detalles);
        }
    }
}
