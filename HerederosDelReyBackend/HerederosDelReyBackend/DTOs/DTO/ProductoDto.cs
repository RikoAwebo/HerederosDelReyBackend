namespace HerederosDelReyBackend.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public int? Stock { get; set; }

        public int? StockMinimo { get; set; }

        public decimal? PrecioCompra { get; set; }

        public decimal? PrecioVenta { get; set; }

        public DateOnly? FechaCaducidad { get; set; }

        public int? CategoriaId { get; set; }

        public int? MarcaId { get; set; }

        public string? NombreMarca { get; set; }
        public string? NombreCategoria { get; set; }
    }
}
