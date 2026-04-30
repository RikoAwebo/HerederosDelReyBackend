namespace HerederosDelReyBackend.DTOs
{
    public class DetalleCompraUpdateDto
    {
        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public decimal? Subtotal { get; set; }

        public int CompraId { get; set; }

        public int ProductoId { get; set; }
    }
}
