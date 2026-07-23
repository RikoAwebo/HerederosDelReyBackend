using System.ComponentModel.DataAnnotations;

namespace HerederosDelReyBackend.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Clave { get; set; } = string.Empty;

    }
}
