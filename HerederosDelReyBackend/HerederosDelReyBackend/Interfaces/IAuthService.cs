using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
    }
}
