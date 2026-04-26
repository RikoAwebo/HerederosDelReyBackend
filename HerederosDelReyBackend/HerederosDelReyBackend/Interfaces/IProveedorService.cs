using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IProveedorService
    {
        Task<IEnumerable<ProveedoresDto>> GetAllAsync();
        Task<ProveedoresDto?> GetByIdAsync(int id);
        Task<ProveedoresDto> AddAsync(ProveedoresCreateDto dto);
        Task<bool> UpdateAsync(int id, ProveedoresUptadeDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<ProveedoresDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
