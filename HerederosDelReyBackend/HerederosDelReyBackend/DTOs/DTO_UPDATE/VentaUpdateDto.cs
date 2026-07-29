namespace HerederosDelReyBackend.DTOs
{
    public class VentaUpdateDto
    {
        public bool Acredito { get; set; }

        public decimal MontoPagado { get; set; }

        public decimal SaldoPendiente { get; set; }

        public DateOnly? FechaLimitePago { get; set; }

        
        public string? Observacion { get; set; }

        public string EstadoVenta { get; set; } = null!;
    }
}
