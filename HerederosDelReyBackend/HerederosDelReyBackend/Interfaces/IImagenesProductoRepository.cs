using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IImagenesProductoRepository : IGenericRepository<ImagenesProducto>
    {
        Task<PagedList<ImagenesProducto>> GetAllAsync(PostQueryFilter filter);
    }
}
