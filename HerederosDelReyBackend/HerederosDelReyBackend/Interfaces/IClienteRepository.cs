using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IClienteRepository : IGenericRepository<Cliente>
    {
                Task<PagedList<Cliente>> GetAllAsync(PostQueryFilter filter);
    }
}
