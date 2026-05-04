namespace HerederosDelReyBackend.DTOs
{
    public class CajaDto
    {
        public int Id { get; set; }

        public decimal? MontoInicial { get; set; }

        public decimal? MontoFinal { get; set; }

        public DateTime? FechaApertura { get; set; }

        public DateTime? FechaCierre { get; set; }

        public decimal? Gastos { get; set; }

        public string? Estado { get; set; }

        public int? UsuarioId { get; set; }

        public string? UsuarioName { get; set; }
    }
}
