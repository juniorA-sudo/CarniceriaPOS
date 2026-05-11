using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using CarniceriaPOS.Data;

namespace CarniceriaPOS.Utilities
{
    public class LimpiadorBD
    {
        private ConexionBD conexion;

        public LimpiadorBD()
        {
            conexion = new ConexionBD();
        }

        
        
        
        public bool LimpiarDatosDeProductos()
        {
            try
            {
                MessageBox.Show(" ADVERTENCIA: Se van a eliminar TODOS los datos de prueba.\n\n" +
                                "Se eliminaran:\n" +
                                "• Productos\n" +
                                "• Clientes\n" +
                                "• Proveedores\n" +
                                "• Ventas\n" +
                                "• Compras\n" +
                                "• Categorias\n\n" +
                                "Se mantienen:\n" +
                                " Usuarios\n" +
                                " Roles\n" +
                                " Departamentos",
                    "Limpiar Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (MessageBox.Show("?Esta seguro de que desea continuar?",
                    "Confirmar Limpieza", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return false;
                }

                
                conexion.EjecutarComando("EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");

                
                conexion.EjecutarComando("DELETE FROM MovimientosInventario");
                conexion.EjecutarComando("DELETE FROM CierresCaja");
                conexion.EjecutarComando("DELETE FROM DetalleVentas");
                conexion.EjecutarComando("DELETE FROM DetalleCompras");
                conexion.EjecutarComando("DELETE FROM Ventas");
                conexion.EjecutarComando("DELETE FROM Compras");
                conexion.EjecutarComando("DELETE FROM Productos");
                conexion.EjecutarComando("DELETE FROM Proveedores");
                conexion.EjecutarComando("DELETE FROM Clientes");
                conexion.EjecutarComando("DELETE FROM Categorias");

                
                conexion.EjecutarComando("EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'");

                
                ActualizarEmailsUsuarios();

                MessageBox.Show(" Base de datos limpiada exitosamente.\n\n" +
                                "Solo quedan los usuarios en el sistema.",
                    "Limpieza Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar la base de datos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ActualizarEmailsUsuarios()
        {
            try
            {
                SqlParameter[] parametros = new SqlParameter[] {
                    new SqlParameter("@Email", "admin@gmail.com"),
                    new SqlParameter("@IdUsuario", 1)
                };
                conexion.EjecutarComando("UPDATE Usuarios SET Email = @Email WHERE IdUsuario = @IdUsuario", parametros);

                parametros = new SqlParameter[] {
                    new SqlParameter("@Email", "gerente@gmail.com"),
                    new SqlParameter("@IdUsuario", 2)
                };
                conexion.EjecutarComando("UPDATE Usuarios SET Email = @Email WHERE IdUsuario = @IdUsuario", parametros);

                parametros = new SqlParameter[] {
                    new SqlParameter("@Email", "vendedor@gmail.com"),
                    new SqlParameter("@IdUsuario", 3)
                };
                conexion.EjecutarComando("UPDATE Usuarios SET Email = @Email WHERE IdUsuario = @IdUsuario", parametros);

                parametros = new SqlParameter[] {
                    new SqlParameter("@Email", "cajero@gmail.com"),
                    new SqlParameter("@IdUsuario", 4)
                };
                conexion.EjecutarComando("UPDATE Usuarios SET Email = @Email WHERE IdUsuario = @IdUsuario", parametros);

                parametros = new SqlParameter[] {
                    new SqlParameter("@Email", "bodeguero@gmail.com"),
                    new SqlParameter("@IdUsuario", 5)
                };
                conexion.EjecutarComando("UPDATE Usuarios SET Email = @Email WHERE IdUsuario = @IdUsuario", parametros);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Advertencia: No se pudieron actualizar todos los emails: " + ex.Message);
            }
        }

        
        
        
        public string ObtenerEstadoBD()
        {
            try
            {
                var dt = conexion.ObtenerDatos(
                    @"SELECT 'Usuarios' as Tabla, COUNT(*) as Cantidad FROM Usuarios
                      UNION ALL SELECT 'Clientes', COUNT(*) FROM Clientes
                      UNION ALL SELECT 'Productos', COUNT(*) FROM Productos
                      UNION ALL SELECT 'Categorias', COUNT(*) FROM Categorias
                      UNION ALL SELECT 'Proveedores', COUNT(*) FROM Proveedores
                      UNION ALL SELECT 'Ventas', COUNT(*) FROM Ventas
                      UNION ALL SELECT 'Compras', COUNT(*) FROM Compras");

                string estado = "Estado de la Base de Datos:\n\n";
                foreach (System.Data.DataRow row in dt.Rows)
                {
                    estado += row["Tabla"] + ": " + row["Cantidad"] + "\n";
                }

                return estado;
            }
            catch (Exception ex)
            {
                return "Error al obtener estado: " + ex.Message;
            }
        }
    }
}
