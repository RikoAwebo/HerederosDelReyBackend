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
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.Trim();

                query = query.Where(x =>
                    x.Nombre.Contains(buscar) ||
                    (x.Telefono != null && x.Telefono.Contains(buscar)) ||
                    (x.Direccion != null && x.Direccion.Contains(buscar)) ||
                    (x.Correo != null && x.Correo.Contains(buscar)));
            }

            query = query.OrderBy(x => x.Nombre);

            return await PagedList<Sucursale>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
