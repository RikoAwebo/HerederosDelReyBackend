using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class DetalleCompraRepository : GenericRepository<DetalleCompra>,
        IDetalleCompraRepository
    {
        public DetalleCompraRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<DetalleCompra>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Cantidad.ToString().ToLower().Contains(buscar) ||
                    x.CompraId.ToString().ToLower().Contains(buscar));


            }

            return await PagedList<DetalleCompra>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
