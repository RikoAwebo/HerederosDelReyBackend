namespace HerederosDelReyBackend.DTOs
{
    public class GastosDto
    {
        public int Id { get; set; } 
        public string? Descripcion { get; set; }

        public double? Monto { get; set; }

        public string? TipoGasto { get; set; }
    }
}
