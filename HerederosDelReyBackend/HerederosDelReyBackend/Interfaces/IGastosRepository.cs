using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IGastosRepository: IGenericRepository<Gasto>
    {
        Task<PagedList<Gasto>> GetAllAsync(PostQueryFilter filter);
    }
}
