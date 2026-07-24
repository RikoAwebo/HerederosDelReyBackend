namespace HerederosDelReyBackend.DTOs
{
    public class UsuarioDto
    {
        public string Id { get; set; }
        public int IdSucursal { get; set; }

        public string Nombres { get; set; } = null!;

        public string? Apellidos { get; set; }

        public string? Rol { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Foto { get; set; }
    }
}
