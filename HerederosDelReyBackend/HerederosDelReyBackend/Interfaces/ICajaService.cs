using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ICajaService
    {
        Task<IEnumerable<CajaDto>> GetAllAsync();
        Task<CajaDto?> GetByIdAsync(int id);
        Task<CajaDto> AddAsync(CajaCreateDto dto);
        Task<bool> UpdateAsync(int id, CajaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<CajaDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
