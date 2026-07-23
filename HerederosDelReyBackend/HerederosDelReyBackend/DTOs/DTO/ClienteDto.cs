namespace HerederosDelReyBackend.DTOs.DTO
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; } = null!;

        public string? Apellidos { get; set; }

        public string? NitCi { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public string? Observacion { get; set; }

    }
}
