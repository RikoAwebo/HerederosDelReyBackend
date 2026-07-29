namespace HerederosDelReyBackend.DTOs
{
    public class ProveedoresCreateDto
    {
        public string Nombre { get; set; } = null!;

        public string? Contacto { get; set; }

        public string? Nit { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public string? Observacion { get; set; }
    }
}
