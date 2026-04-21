using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IMarcaRepository: IGenericRepository<Marca>
    {
        Task<PagedList<Marca>> GetAllAsync(PostQueryFilter filter);
    }
}
