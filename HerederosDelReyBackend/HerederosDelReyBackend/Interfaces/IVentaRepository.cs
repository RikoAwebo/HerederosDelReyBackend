using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
                Task<PagedList<Venta>> GetAllAsync(PostQueryFilter filter);

    }
}
