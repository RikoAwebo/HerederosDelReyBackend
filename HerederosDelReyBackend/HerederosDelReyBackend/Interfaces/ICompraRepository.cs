using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ICompraRepository : IGenericRepository<Compra>
    {
                Task<PagedList<Compra>> GetAllAsync(PostQueryFilter filter);
    }
}
