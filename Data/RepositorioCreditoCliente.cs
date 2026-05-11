using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioCreditoCliente
    {
        private ConexionBD bd = new ConexionBD();

        public CreditoCliente ObtenerCreditoPorCliente(int idCliente)
        {
            string sql = "SELECT * FROM CreditoCliente WHERE IdCliente = @IdCliente";
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdCliente", idCliente) };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                return MapearCredito(dt.Rows[0]);
            }
            return null;
        }

        public bool CrearCredito(int idCliente, decimal limiteCredito)
        {
            string sql = @"INSERT INTO CreditoCliente (IdCliente, SaldoDeudor, LimiteCredito, Activo)
                          VALUES (@IdCliente, 0, @LimiteCredito, 1)";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCliente", idCliente),
                new SqlParameter("@LimiteCredito", limiteCredito)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public bool AumentarDeuda(int idCliente, decimal monto)
        {
            string sql = @"UPDATE CreditoCliente
                          SET SaldoDeudor = SaldoDeudor + @Monto,
                              FechaUltimaCompra = GETDATE()
                          WHERE IdCliente = @IdCliente";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCliente", idCliente),
                new SqlParameter("@Monto", monto)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public bool RealizarPago(int idCliente, decimal monto)
        {
            string sql = @"UPDATE CreditoCliente
                          SET SaldoDeudor = MAX(0, SaldoDeudor - @Monto),
                              FechaUltimoPago = GETDATE()
                          WHERE IdCliente = @IdCliente";

            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdCliente", idCliente),
                new SqlParameter("@Monto", monto)
            };

            return bd.EjecutarComando(sql, parametros) > 0;
        }

        public List<CreditoCliente> ObtenerClientesConAtraso(int diasAtraso = 30)
        {
            string sql = @"SELECT c.* FROM CreditoCliente c
                          WHERE c.SaldoDeudor > 0
                          AND DATEDIFF(DAY, c.FechaUltimoPago, GETDATE()) > @DiasAtraso
                          ORDER BY c.SaldoDeudor DESC";

            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@DiasAtraso", diasAtraso) };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            List<CreditoCliente> creditos = new List<CreditoCliente>();

            foreach (DataRow row in dt.Rows)
            {
                creditos.Add(MapearCredito(row));
            }
            return creditos;
        }

        private CreditoCliente MapearCredito(DataRow row)
        {
            return new CreditoCliente
            {
                IdCredito = (int)row["IdCredito"],
                IdCliente = (int)row["IdCliente"],
                SaldoDeudor = (decimal)row["SaldoDeudor"],
                LimiteCredito = (decimal)row["LimiteCredito"],
                FechaUltimaCompra = row["FechaUltimaCompra"] != DBNull.Value ? (DateTime)row["FechaUltimaCompra"] : DateTime.Now,
                FechaUltimoPago = row["FechaUltimoPago"] != DBNull.Value ? (DateTime)row["FechaUltimoPago"] : DateTime.Now,
                Activo = (bool)row["Activo"],
                FechaCreacion = (DateTime)row["FechaCreacion"]
            };
        }
    }
}
