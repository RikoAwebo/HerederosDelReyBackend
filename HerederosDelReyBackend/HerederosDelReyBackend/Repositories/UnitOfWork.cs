using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace HerederosDelReyBackend.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HerederosDelReyContext _context;
        private IUsuarioRepository? _usuarioRepository;

        public UnitOfWork(HerederosDelReyContext context)
        {
            _context = context;
        }
        public IUsuarioRepository Usuarios
           => _usuarioRepository ??= new UsuarioRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
