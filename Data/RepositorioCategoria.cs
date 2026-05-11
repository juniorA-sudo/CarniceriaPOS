using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CarniceriaPOS.Models;

namespace CarniceriaPOS.Data
{
    public class RepositorioCategoria
    {
        private ConexionBD bd = new ConexionBD();

        public List<Categoria> ObtenerTodas()
        {
            string sql = "SELECT * FROM Categorias";
            DataTable dt = bd.ObtenerDatos(sql);
            List<Categoria> categorias = new List<Categoria>();

            foreach (DataRow row in dt.Rows)
            {
                categorias.Add(new Categoria
                {
                    IdCategoria = (int)row["IdCategoria"],
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString()
                });
            }
            return categorias;
        }

        public Categoria ObtenerCategoriaPorId(int idCategoria)
        {
            string sql = "SELECT * FROM Categorias WHERE IdCategoria = @IdCategoria";
            SqlParameter[] parametros = new SqlParameter[] { new SqlParameter("@IdCategoria", idCategoria) };

            DataTable dt = bd.ObtenerDatos(sql, parametros);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Categoria
                {
                    IdCategoria = (int)row["IdCategoria"],
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString()
                };
            }
            return null;
        }
    }
}
