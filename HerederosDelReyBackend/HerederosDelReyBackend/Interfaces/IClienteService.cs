using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto?> GetByIdAsync(int id);
        Task<ClienteDto> AddAsync(ClienteCreateDto dto);
        Task<bool> UpdateAsync(int id, ClienteUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<ClienteDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
