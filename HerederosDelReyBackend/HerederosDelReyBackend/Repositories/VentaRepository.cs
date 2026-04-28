using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class VentaRepository : GenericRepository<Venta>,
        IVentaRepository
    {
        public VentaRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<Venta>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable().Include(v => v.Cliente).Include(v => v.Usuario).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Cliente.Nombre.ToLower().Contains(buscar) ||
                    x.Usuario.NombreUsuario.ToLower().Contains(buscar));


            }

            return await PagedList<Venta>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
