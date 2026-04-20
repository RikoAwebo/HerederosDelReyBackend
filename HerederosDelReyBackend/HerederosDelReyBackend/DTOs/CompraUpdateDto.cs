namespace HerederosDelReyBackend.DTOs
{
    public class CompraUpdateDto
    {
        public DateTime? Fecha { get; set; }

        public decimal? Total { get; set; }

        public string? Descripcion { get; set; }

        public int? ProveedorId { get; set; }

        public int? UsuarioId { get; set; }
    }
}
