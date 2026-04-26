using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>,
        IUsuarioRepository
    {
        public UsuarioRepository(HerederosDelReyContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email == email && x.Borrado == false);
        }


        public async Task<PagedList<Usuario>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.NombreUsuario.ToLower().Contains(buscar) ||
                    x.Email.ToLower().Contains(buscar));
         
            }

            return await PagedList<Usuario>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }

    }
}
