using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDto>> GetAllAsync();
        Task<MarcaDto?> GetByIdAsync(int id);
        Task<MarcaDto> AddAsync(MarcaCreateDto dto);
        Task<bool> UpdateAsync(int id, MarcaUpdateDto dto);
        Task <bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<MarcaDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
