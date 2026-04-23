using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IDetalleCompraRepository : IGenericRepository<DetalleCompra>
    {
                Task<PagedList<DetalleCompra>> GetAllAsync(PostQueryFilter filter);
        
    }
}
