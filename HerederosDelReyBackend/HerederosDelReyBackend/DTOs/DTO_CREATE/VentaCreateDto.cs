namespace HerederosDelReyBackend.DTOs
{
    public class VentaCreateDto
    {
        public int Id { get; set; }

        public bool Acredito { get; set; }

        public decimal MontoPagado { get; set; }

        public decimal SaldoPendiente { get; set; }

        public DateOnly? FechaLimitePago { get; set; }

        public string TipoDocumento { get; set; } = null!;

        public string? NumeroDocumento { get; set; }

        public DateTime FechaVenta { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Impuesto { get; set; }

        public decimal Total { get; set; }

        public string? Observacion { get; set; }

        public string EstadoVenta { get; set; } = null!;

    }
}
