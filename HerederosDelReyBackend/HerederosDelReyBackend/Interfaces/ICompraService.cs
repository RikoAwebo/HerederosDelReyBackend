using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ICompraService
    {
        Task<IEnumerable<CompraDto>> GetAllAsync();
        Task<CompraDto?> GetByIdAsync(int id);
        Task<CompraDto> AddAsync(CompraCreateDto dto);
        Task<bool> UpdateAsync(int id, CompraUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<CompraDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
