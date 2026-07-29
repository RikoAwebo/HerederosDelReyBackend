using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class SucursaleRepository: GenericRepository<Sucursale>, ISucursaleRepository
    {
        public SucursaleRepository(HerederosDelReyContext context) : base(context)
        {

        }

        public async Task<PagedList<Sucursale>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable()
                  .Include(x => x.Id)
                  .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();
                query = query.Where(x =>
                    x.Nombre.Contains(buscar));

            }

            return await PagedList<Sucursale>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
