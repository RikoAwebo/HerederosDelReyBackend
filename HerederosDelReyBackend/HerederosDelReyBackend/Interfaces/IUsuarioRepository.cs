using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;
using HerederosDelReyBackend.Repositories;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IUsuarioRepository: IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);

        Task<PagedList<Usuario>> GetAllAsync(PostQueryFilter filter);
    }
}
