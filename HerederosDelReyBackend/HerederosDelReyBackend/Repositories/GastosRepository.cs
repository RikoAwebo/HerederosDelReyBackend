using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class GastosRepository : GenericRepository<Gasto>, IGastosRepository
    {
        public GastosRepository(HerederosDelReyContext context) : base(context)
        {

        }
        public async Task<PagedList<Gasto>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.TipoGasto.ToLower().Contains(buscar));
            }

            return await PagedList<Gasto>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
