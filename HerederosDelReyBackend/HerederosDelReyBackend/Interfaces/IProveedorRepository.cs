using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IProveedorRepository : IGenericRepository<Proveedor>
    {
                        Task<PagedList<Proveedor>> GetAllAsync(PostQueryFilter filter);
    }
}
