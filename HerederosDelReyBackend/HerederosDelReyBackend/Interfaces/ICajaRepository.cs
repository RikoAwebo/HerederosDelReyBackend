using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ICajaRepository : IGenericRepository<Caja>
    {
        Task<PagedList<Caja>> GetAllAsync(PostQueryFilter filter);
    }
}
