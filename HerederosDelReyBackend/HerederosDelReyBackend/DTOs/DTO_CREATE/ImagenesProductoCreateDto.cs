namespace HerederosDelReyBackend.DTOs.DTO_CREATE
{
    public class ImagenesProductoCreateDto
    {
        public int IdProducto { get; set; }

        public string? NombreArchivo { get; set; }

        public string RutaImagen { get; set; } = null!;

        public bool? EsPrincipal { get; set; }
    }
}
