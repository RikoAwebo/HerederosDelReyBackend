namespace HerederosDelReyBackend.DTOs
{
    public class VentaUpdateDto
    {
        public DateTime? Fecha { get; set; }

        public decimal? Total { get; set; }

        public string? MetodoPago { get; set; }

        public string? Observaciones { get; set; }

        public int? ClienteId { get; set; }

        public int? UsuarioId { get; set; }
    }
}
