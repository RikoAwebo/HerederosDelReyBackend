namespace HerederosDelReyBackend.DTOs
{
    public class ProductoReporteDto
    {
        public string? Nombre { get; set; }
        public int? Cantidad { get; set; }

        public decimal? PrecioCompra { get; set; }

        public decimal? PrecioVenta { get; set; }

        public decimal? PrecioCompraT =>
              (PrecioCompra.HasValue && Cantidad.HasValue)
                  ? PrecioCompra.Value * Cantidad.Value
                  : (decimal?)null;

        public decimal? PrecioVentaT =>
              (PrecioVenta.HasValue && Cantidad.HasValue)
                  ? PrecioVenta.Value * Cantidad.Value
                  : (decimal?)null;

        public decimal? TotalGanancia =>
              (PrecioVentaT.HasValue && PrecioCompraT.HasValue)
                  ? PrecioVentaT.Value - PrecioCompraT.Value
                  : (decimal?)null;
    }
}
