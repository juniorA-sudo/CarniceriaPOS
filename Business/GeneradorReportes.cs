using System;
using System.Collections.Generic;
using System.Data;

namespace CarniceriaPOS.Business
{
    public abstract class GeneradorReportes
    {
        protected string NombreEmpresa = "Carniceria POS";
        protected string Direccion = "Direccion: Calle, Manzana, Lote";
        protected string Telefono = "Telefono: +503-XXXX-XXXX";
        protected string NIT = "NIT: 12345-670";
        protected string Email = "Email: info@carniceria.com";
        protected DateTime FechaReporte = DateTime.Now;

        public abstract string GenerarHTML();

        protected string ObtenerEncabezado(string tituloReporte)
        {
            return $@"
<!DOCTYPE html>
<html lang='es'>
<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>{tituloReporte}</title>
    <style>
        * {{ margin: 0; padding: 0; box-sizing: border-box; }}
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background: #f5f5f5; padding: 20px; }}
        .contenedor {{ max-width: 1000px; margin: 0 auto; background: white; padding: 30px; box-shadow: 0 0 20px rgba(0,0,0,0.1); }}

        
        .encabezado {{ display: flex; justify-content: space-between; align-items: center; border-bottom: 3px solid #E75480; padding-bottom: 20px; margin-bottom: 30px; }}
        .logo-empresa {{ flex: 1; }}
        .logo {{ width: 60px; height: 60px; background: linear-gradient(135deg, #E75480 0%, #FF69B4 100%); border-radius: 50%; display: flex; align-items: center; justify-content: center; color: white; font-size: 24px; font-weight: bold; }}
        .info-empresa {{ flex: 2; margin-left: 20px; }}
        .nombre-empresa {{ font-size: 20px; font-weight: bold; color: #333; }}
        .detalle {{ font-size: 12px; color: #666; margin: 2px 0; }}
        .titulo-reporte {{ flex: 1; text-align: right; }}
        .titulo-reporte h1 {{ font-size: 28px; color: #E75480; font-weight: bold; text-transform: uppercase; }}
        .fecha {{ font-size: 12px; color: #666; margin-top: 5px; }}

        
        .indicadores {{ display: grid; grid-template-columns: repeat(auto-fit, minmax(200px, 1fr)); gap: 15px; margin-bottom: 30px; }}
        .indicador {{ background: linear-gradient(135deg, #E75480 0%, #FF69B4 100%); color: white; padding: 20px; border-radius: 10px; text-align: center; box-shadow: 0 4px 6px rgba(0,0,0,0.1); }}
        .indicador-titulo {{ font-size: 12px; font-weight: bold; text-transform: uppercase; margin-bottom: 10px; opacity: 0.9; }}
        .indicador-valor {{ font-size: 32px; font-weight: bold; }}
        .indicador-unidad {{ font-size: 12px; margin-top: 5px; opacity: 0.8; }}

        .indicador.verde {{ background: linear-gradient(135deg, #4CAF50 0%, #8BC34A 100%); }}
        .indicador.azul {{ background: linear-gradient(135deg, #2196F3 0%, #03A9F4 100%); }}
        .indicador.naranja {{ background: linear-gradient(135deg, #FF9800 0%, #FFC107 100%); }}
        .indicador.rojo {{ background: linear-gradient(135deg, #F44336 0%, #E91E63 100%); }}

        
        .seccion {{ margin-bottom: 30px; }}
        .seccion-titulo {{ font-size: 18px; font-weight: bold; color: #E75480; margin-bottom: 15px; padding-bottom: 10px; border-bottom: 2px solid #E75480; }}
        .tabla-contenedor {{ overflow-x: auto; }}
        table {{ width: 100%; border-collapse: collapse; }}
        th {{ background: linear-gradient(135deg, #E75480 0%, #FF69B4 100%); color: white; padding: 12px; text-align: left; font-weight: bold; }}
        td {{ padding: 10px 12px; border-bottom: 1px solid #eee; }}
        tr:hover {{ background: #f9f9f9; }}
        tr:nth-child(even) {{ background: #f5f5f5; }}

        
        .analisis {{ display: grid; grid-template-columns: 1fr 1fr; gap: 20px; margin-bottom: 30px; }}
        .caja-analisis {{ background: #FFF5F7; padding: 15px; border-left: 4px solid #E75480; border-radius: 4px; }}
        .caja-analisis h3 {{ color: #E75480; margin-bottom: 10px; font-size: 14px; }}
        .caja-analisis ul {{ margin-left: 20px; font-size: 13px; line-height: 1.6; }}
        .caja-analisis li {{ margin-bottom: 5px; color: #555; }}

        
        .grafico-contenedor {{ margin-bottom: 30px; text-align: center; }}
        .grafico-contenedor canvas {{ max-width: 500px; margin: 0 auto; }}

        
        .footer {{ border-top: 2px solid #E75480; padding-top: 20px; margin-top: 30px; text-align: center; font-size: 12px; color: #666; }}
        .firma {{ display: grid; grid-template-columns: 1fr 1fr; gap: 40px; margin-top: 40px; text-align: center; }}
        .firma-linea {{ border-top: 1px solid #333; margin-top: 40px; padding-top: 5px; }}

        
        .texto-verde {{ color: #4CAF50; font-weight: bold; }}
        .texto-rojo {{ color: #F44336; font-weight: bold; }}
        .texto-gris {{ color: #999; }}
        .texto-derecha {{ text-align: right; }}
        .texto-centro {{ text-align: center; }}

        @media print {{
            body {{ background: white; padding: 0; }}
            .contenedor {{ box-shadow: none; }}
            .no-imprimir {{ display: none; }}
        }}
    </style>
</head>
<body>
    <div class='contenedor'>
        <div class='encabezado'>
            <div class='logo-empresa'>
                <div class='logo'></div>
            </div>
            <div class='info-empresa'>
                <div class='nombre-empresa'>{NombreEmpresa}</div>
                <div class='detalle'>{Direccion}</div>
                <div class='detalle'>{Telefono}</div>
                <div class='detalle'>NIT: {NIT}</div>
                <div class='detalle'>{Email}</div>
            </div>
            <div class='titulo-reporte'>
                <h1>{tituloReporte}</h1>
                <div class='fecha'>Generado: {FechaReporte:dd/MM/yyyy HH:mm:ss}</div>
            </div>
        </div>";
        }

        protected string ObtenerPie()
        {
            return @"
        <div class='footer'>
            <p><strong>Documento Confidencial - Uso exclusivo de la empresa</strong></p>
            <p>Este reporte fue generado automaticamente por el Sistema POS Carniceria</p>
            <div class='firma'>
                <div>
                    <div class='firma-linea'></div>
                    <p>Responsable de Generacion</p>
                </div>
                <div>
                    <div class='firma-linea'></div>
                    <p>Autorizado por Gerencia</p>
                </div>
            </div>
        </div>
    </div>
</body>
</html>";
        }

        protected string ObtenerIndicadores(List<(string titulo, string valor, string unidad, string clase)> indicadores)
        {
            string html = "<div class='indicadores'>";
            foreach (var ind in indicadores)
            {
                html += $@"
        <div class='indicador {ind.clase}'>
            <div class='indicador-titulo'>{ind.titulo}</div>
            <div class='indicador-valor'>{ind.valor}</div>
            <div class='indicador-unidad'>{ind.unidad}</div>
        </div>";
            }
            html += "</div>";
            return html;
        }

        protected string ObtenerTabla(DataTable dt, string titulo = "")
        {
            if (dt == null || dt.Rows.Count == 0)
                return "<p>No hay datos disponibles</p>";

            string html = "";
            if (!string.IsNullOrEmpty(titulo))
                html += $"<div class='seccion-titulo'>{titulo}</div>";

            html += "<div class='tabla-contenedor'><table>";
            html += "<thead><tr>";
            foreach (DataColumn col in dt.Columns)
                html += $"<th>{col.ColumnName}</th>";
            html += "</tr></thead>";
            html += "<tbody>";
            foreach (DataRow row in dt.Rows)
            {
                html += "<tr>";
                foreach (var cell in row.ItemArray)
                    html += $"<td>{cell?.ToString() ?? "-"}</td>";
                html += "</tr>";
            }
            html += "</tbody></table></div>";
            return html;
        }

        protected string ObtenerAnalisisYRecomendaciones(List<string> indicadores, List<string> recomendaciones)
        {
            string html = "<div class='analisis'>";

            html += "<div class='caja-analisis'>";
            html += "<h3> Indicadores Clave</h3>";
            html += "<ul>";
            foreach (var ind in indicadores)
                html += $"<li>{ind}</li>";
            html += "</ul></div>";

            html += "<div class='caja-analisis'>";
            html += "<h3> Recomendaciones</h3>";
            html += "<ul>";
            foreach (var rec in recomendaciones)
                html += $"<li>{rec}</li>";
            html += "</ul></div>";

            html += "</div>";
            return html;
        }
    }
}
