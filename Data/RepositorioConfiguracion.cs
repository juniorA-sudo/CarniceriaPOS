using System;
using System.Data;
using System.Data.SqlClient;

namespace CarniceriaPOS.Data
{
    public class RepositorioConfiguracion
    {
        private ConexionBD bd = new ConexionBD();

        public string ObtenerValor(string clave, string valorPorDefecto = "")
        {
            string sql = "SELECT Valor FROM Configuracion WHERE Clave = @Clave";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Clave", clave)
            };

            try
            {
                object resultado = bd.ObtenerEscalar(sql, parametros);
                return resultado != null ? resultado.ToString() : valorPorDefecto;
            }
            catch
            {
                return valorPorDefecto;
            }
        }

        public decimal ObtenerValorDecimal(string clave, decimal valorPorDefecto = 0)
        {
            string valor = ObtenerValor(clave);
            if (decimal.TryParse(valor, out decimal resultado))
                return resultado;
            return valorPorDefecto;
        }

        public bool ActualizarValor(string clave, string valor, string descripcion = "")
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM Configuracion WHERE Clave = @Clave)
                    UPDATE Configuracion SET Valor = @Valor, Descripcion = @Descripcion, FechaActualizacion = GETDATE()
                    WHERE Clave = @Clave
                ELSE
                    INSERT INTO Configuracion (Clave, Valor, Descripcion) VALUES (@Clave, @Valor, @Descripcion)
            ";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Clave", clave),
                new SqlParameter("@Valor", valor),
                new SqlParameter("@Descripcion", descripcion ?? "")
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }
    }
}
