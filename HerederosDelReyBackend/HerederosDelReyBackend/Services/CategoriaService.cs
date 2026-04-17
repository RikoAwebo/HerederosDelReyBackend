using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;

namespace HerederosDelReyBackend.Services
{
    public class CategoriaService : ICategoriaService
    {
        public Task<CategoriaDto> AddAsync(CategoriaCreateDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, CategoriaUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
