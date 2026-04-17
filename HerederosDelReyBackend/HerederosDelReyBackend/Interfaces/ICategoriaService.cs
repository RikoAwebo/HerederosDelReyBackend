using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetAllAsync();
        Task<CategoriaDto?> GetByIdAsync(int id);
        Task<CategoriaDto> AddAsync(CategoriaCreateDto dto);
        Task<bool> UpdateAsync(int id, CategoriaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
