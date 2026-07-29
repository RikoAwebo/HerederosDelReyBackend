namespace HerederosDelReyBackend.DTOs.DTO_UPDATE
{
    public class ImagenesProductoUpdateDto
    {
        public int IdProducto { get; set; }

        public string? NombreArchivo { get; set; }

        public string RutaImagen { get; set; } = null!;

        public bool? EsPrincipal { get; set; }
    }
}
