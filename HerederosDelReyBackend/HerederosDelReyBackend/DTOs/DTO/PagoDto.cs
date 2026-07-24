namespace HerederosDelReyBackend.DTOs.DTO
{
    public class PagoDto
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }

        public int IdCaja { get; set; }

        public string MetodoPago { get; set; } = null!;

        public decimal Monto { get; set; }

        public string? Referencia { get; set; }

        public string? Observacion { get; set; }

    }
}
