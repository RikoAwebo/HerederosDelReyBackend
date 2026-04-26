using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IGastosService
    {
       
        Task<IEnumerable<GastosDto>> GetAllAsync();
        Task<GastosDto> AddAsync(GastosCreateDto dto);
        Task<GastosDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, GastosUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<GastosDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
