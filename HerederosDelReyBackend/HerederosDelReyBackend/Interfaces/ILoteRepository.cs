using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ILoteRepository:IGenericRepository<Lote>
    {
        Task<PagedList<Lote>> GetAllAsync(PostQueryFilter filter);




    }
}
