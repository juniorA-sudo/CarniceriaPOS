namespace CarniceriaPOS.Models
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }

        public string NombreProducto { get; set; }

        
        public decimal Peso { get; set; }
        public string TipoCantidad { get; set; } = "Unidad";

        
        public string DisplayCantidad =>
            TipoCantidad == "Kg" ? $"{Peso:F2} kg" : $"{Cantidad} unidades";
    }
}
