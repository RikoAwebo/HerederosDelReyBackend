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
            var query = GetAllAsQueryable()
                .Include(x => x.EstadoCompra)
                .Include(x => x.FechaCompra)
                .Include(x => x.DetalleCompras) // 🔥 IMPORTANTE
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    (x.EstadoCompra != null && x.EstadoCompra.ToLower().Contains(buscar)) ||
                    (x.FechaCompra.ToString().Contains(buscar))
                );
            }

            return await PagedList<Compra>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
