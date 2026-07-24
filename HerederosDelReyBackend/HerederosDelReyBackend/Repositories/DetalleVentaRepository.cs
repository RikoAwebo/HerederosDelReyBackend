using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class DetalleVentaRepository : GenericRepository<DetalleVenta>, IDetalleVentaRepository
    {
        public DetalleVentaRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<DetalleVenta>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.IdVenta.ToString().ToLower().Contains(buscar));


            }

            return await PagedList<DetalleVenta>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }

        public async Task<List<DetalleVenta>> GetDetallesFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            var query = GetAllAsQueryable();

            query = query.Where(x => x.FechaRegistro.Date >= fechaInicio.Date && x.FechaRegistro.Date <= fechaFinal.Date && x.Estado != true).Include(x=>x.IdProductoNavigation);

            return await query.ToListAsync();



        }
    }
}
