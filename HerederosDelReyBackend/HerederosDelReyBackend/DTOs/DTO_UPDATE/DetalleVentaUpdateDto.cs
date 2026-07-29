namespace HerederosDelReyBackend.DTOs
{
    public class DetalleVentaUpdateDto
    {
        
        public decimal Cantidad { get; set; }

        public decimal PrecioVenta { get; set; }

        public decimal Descuento { get; set; }

        public decimal Impuesto { get; set; }

        public decimal SubTotal { get; set; }
    }
}
