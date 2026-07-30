using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.DTOs.DTO;
using HerederosDelReyBackend.DTOs.DTO_CREATE;
using HerederosDelReyBackend.DTOs.DTO_UPDATE;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ISucursalService
    {
        Task<IEnumerable<SucursaleDto>> GetAllAsync();
        Task<SucursaleDto> AddAsync(SucursaleCreateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<SucursaleDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, SucursaleUpdateDto dto);
        Task<ApiResponse<IEnumerable<SucursaleDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
