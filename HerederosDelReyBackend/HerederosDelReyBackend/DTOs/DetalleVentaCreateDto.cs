namespace HerederosDelReyBackend.DTOs
{
    public class DetalleVentaCreateDto
    {
        public int? Cantidad { get; set; }

        public decimal? PrecioUnitario { get; set; }

        public decimal? PrecioCompra { get; set; }

        public decimal? Subtotal { get; set; }

        public int? VentaId { get; set; }

        public int? ProductoId { get; set; }
    }
}
