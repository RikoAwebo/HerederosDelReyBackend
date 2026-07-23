namespace HerederosDelReyBackend.DTOs
{
    public class VentaDto
    {
        public int Id { get; set; }

        public DateTime? Fecha { get; set; }

        public decimal? Total { get; set; }

        public string? MetodoPago { get; set; }

        public string? Observaciones { get; set; }

        public int? ClienteId { get; set; }

        public int? UsuarioId { get; set; }

        public string? ClienteNombre { get; set; }
        public string? UsuarioNombre { get; set; }
    }
}
