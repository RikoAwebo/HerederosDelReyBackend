using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class LoteRepository: GenericRepository<Lote>, ILoteRepository
    {
        public LoteRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<Lote>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Id.ToString().Contains(buscar));


            }


            return await PagedList<Lote>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
