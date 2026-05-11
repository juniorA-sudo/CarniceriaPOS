using System;

namespace CarniceriaPOS.Models
{

    public class Producto
    {
        public int IdProducto { get; set; }
        public string CodigoBarras { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string Categoria { get; set; }

        public string UnidadMedida { get; set; }

        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal StockActual { get; set; }
        public decimal StockMinimo { get; set; }

        public bool AplicaITBIS { get; set; } = false;

        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }

        public string NombreUnidadMedida { get; set; }
        public string AbreviacionUnidad { get; set; }

        public string DisplayStock => $"{StockActual} {AbreviacionUnidad}";

        public string DisplayPrecio => $"${PrecioVenta:N2}";
    }
}
