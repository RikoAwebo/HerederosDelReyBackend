using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ICategoriaRepository : IGenericRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetAllAsync(PostQueryFilter filter);
    }
}
