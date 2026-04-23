using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class ProveedorRepository : GenericRepository<Proveedore>,
        IProveedorRepository
    {
        public ProveedorRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<Proveedore>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar) ||
                    x.Email.ToLower().Contains(buscar));


            }

            return await PagedList<Proveedore>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
