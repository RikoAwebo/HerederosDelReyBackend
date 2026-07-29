using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface ISucursaleRepository  : IGenericRepository<Sucursale>
    {
        Task<PagedList<Sucursale>> GetAllAsync(PostQueryFilter filter);
    }
}
