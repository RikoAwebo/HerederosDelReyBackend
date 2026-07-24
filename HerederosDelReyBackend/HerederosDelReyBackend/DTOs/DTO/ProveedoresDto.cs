namespace HerederosDelReyBackend.DTOs
{
    public class ProveedoresDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Contacto { get; set; }

        public string? Nit { get; set; }

        public string? Telefono { get; set; }

        public string? Correo { get; set; }

        public string? Direccion { get; set; }

        public string? Observacion { get; set; }
    }
}
