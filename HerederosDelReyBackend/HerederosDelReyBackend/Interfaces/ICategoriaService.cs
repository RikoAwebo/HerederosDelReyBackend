using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.DTOs.DTO;
using HerederosDelReyBackend.DTOs.DTO_UPDATE;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetAllAsync();
        Task<CategoriaDto?> GetByIdAsync(int id);
        Task<CategoriaDto> AddAsync(CategoriaCreateDto dto);
        Task<bool> UpdateAsync(int id, CategoriaUpdateDto dto);
        Task<bool> DeleteAsync(int id);

        Task<ApiResponse<IEnumerable<CategoriaDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
