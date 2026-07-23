namespace HerederosDelReyBackend.DTOs.DTO
{
    public class ImagenesProductoDto
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }

        public string? NombreArchivo { get; set; }

        public string RutaImagen { get; set; } = null!;

        public bool? EsPrincipal { get; set; }

    }
}
