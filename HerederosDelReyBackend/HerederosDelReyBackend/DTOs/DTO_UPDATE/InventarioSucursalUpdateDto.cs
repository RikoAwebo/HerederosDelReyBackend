namespace HerederosDelReyBackend.DTOs.DTO_UPDATE
{
    public class InventarioSucursalUpdateDto
    {
        public int IdSucursal { get; set; }

        public int IdProducto { get; set; }

        public decimal StockActual { get; set; }

        public decimal StockMinimo { get; set; }

        public decimal? StockMaximo { get; set; }

        public decimal? PuntoReorden { get; set; }

        public string? Ubicacion { get; set; }
    }
}
