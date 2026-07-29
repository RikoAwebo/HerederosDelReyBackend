namespace HerederosDelReyBackend.DTOs.DTO_UPDATE
{
    public class DetalleCompraUpdateDto
    {
        
        public decimal Cantidad { get; set; }

        public decimal PrecioCompra { get; set; }

        public decimal Descuento { get; set; }

        public decimal Impuesto { get; set; }

        public decimal SubTotal { get; set; }
    }
}
