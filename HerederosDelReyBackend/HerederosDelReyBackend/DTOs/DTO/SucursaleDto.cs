namespace HerederosDelReyBackend.DTOs.DTO
{
    public class SucursaleDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }
    }
}
