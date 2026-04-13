using HerederosDelReyBackend.Models;
using HerederosDelReyBackend.Repositories;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IUsuarioRepository: IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByEmailAsync(string email);
    }
}
