using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        public ProductoRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<Producto>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Categoria.ToString().ToLower().Contains(buscar) ||
                    x.StockMinimo.ToString().ToLower().Contains(buscar) ||
                    x.Nombre.ToString().ToLower().Contains(buscar));


            }

            return await PagedList<Producto>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }

    }
}
