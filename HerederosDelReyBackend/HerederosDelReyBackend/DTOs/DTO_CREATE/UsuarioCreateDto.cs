using System.ComponentModel.DataAnnotations;

namespace HerederosDelReyBackend.DTOs
{
    public class UsuarioCreateDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int IdSucursal { get; set; }

        [Required, MaxLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Usuario1 { get; set; } = string.Empty;

        [Required, MinLength(6), MaxLength(255)]
        public string Clave { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Rol { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Telefono { get; set; }

        [MaxLength(150), EmailAddress]
        public string? Correo { get; set; }

        [MaxLength(500)]
        public string? Foto { get; set; }
    }
}
