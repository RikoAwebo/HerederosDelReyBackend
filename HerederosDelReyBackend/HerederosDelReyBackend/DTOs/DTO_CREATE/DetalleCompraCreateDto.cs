namespace HerederosDelReyBackend.DTOs.DTO_CREATE
{
    public class DetalleCompraCreateDto
    {
       public int Id { get; set; }
        public int IdCompra { get; set; }

        public int IdProducto { get; set; }

        public int? IdLote { get; set; }

        public decimal Cantidad { get; set; }

        public decimal PrecioCompra { get; set; }

        public decimal Descuento { get; set; }

        public decimal Impuesto { get; set; }

        public decimal SubTotal { get; set; }
    }
}
