namespace HerederosDelReyBackend.DTOs.DTO_CREATE
{
    public class SucursaleCreateDto
    {
        public string Nombre { get; set; } = null!;

        public string? Direccion { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }
    }
}
