using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class CajaRepository : GenericRepository<Caja>,
        ICajaRepository
    {
        public CajaRepository(HerederosDelReyContext context) : base(context)
        {

        }

        public async Task<PagedList<Caja>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable()
                  .Include(x => x.Id)
                  .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();
                query = query.Where(x =>
                    x.FechaApertura.ToString().Contains(buscar));

            }

            return await PagedList<Caja>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }

    }
}
