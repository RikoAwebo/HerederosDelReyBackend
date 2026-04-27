using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<Producto>> GetAllAsync(PostQueryFilter filter)
        {

            var query = GetAllAsQueryable()
            .Include(x => x.Marca)
            .Include(x => x.Categoria)
            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.Trim().ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar)
                    || x.Marca.Nombre.ToLower().Contains(buscar)
                    || x.Categoria.Nombre.ToLower().Contains(buscar)
                );
            }

            return await PagedList<Producto>.CreateAsync(
                query,
                filter.PageNumber,
                filter.PageSize
            );
        }

    }
}
