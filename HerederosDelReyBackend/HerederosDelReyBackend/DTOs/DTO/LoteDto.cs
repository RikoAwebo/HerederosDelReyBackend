namespace HerederosDelReyBackend.DTOs.DTO
{
    public class LoteDto
    {
        public string Id { get; set; }
        public int IdSucursal { get; set; }

        public int IdProducto { get; set; }

        public string NumeroLote { get; set; } = null!;

        public DateOnly? FechaFabricacion { get; set; }

        public DateOnly? FechaVencimiento { get; set; }

        public decimal CantidadInicial { get; set; }

        public decimal CantidadDisponible { get; set; }

        public decimal CostoCompra { get; set; }

    }
}
