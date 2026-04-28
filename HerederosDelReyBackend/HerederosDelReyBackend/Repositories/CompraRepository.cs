using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class CompraRepository : GenericRepository<Compra>,
        ICompraRepository
    {
        public CompraRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<Compra>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable().Include(v => v.Proveedor).Include(v => v.Usuario).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Proveedor.Nombre.ToLower().Contains(buscar) ||
                    x.Usuario.NombreUsuario.ToLower().Contains(buscar));
            }

            return await PagedList<Compra>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
