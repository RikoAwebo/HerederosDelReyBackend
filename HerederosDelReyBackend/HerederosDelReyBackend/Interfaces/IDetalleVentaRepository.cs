using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IDetalleVentaRepository : IGenericRepository<DetalleVenta>
    {
           Task<PagedList<DetalleVenta>> GetAllAsync(PostQueryFilter filter);
    }
}
