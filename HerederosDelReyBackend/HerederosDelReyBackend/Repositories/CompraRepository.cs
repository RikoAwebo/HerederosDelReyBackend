using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

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
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Fecha.ToString().ToLower().Contains(buscar));
            }

            return await PagedList<Compra>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
