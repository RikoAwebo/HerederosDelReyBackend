using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class ClienteRepository : GenericRepository<Cliente>,
        IClienteRepository
    {

        public ClienteRepository(HerederosDelReyContext context) : base(context)
        {
                
        }
        public async Task<PagedList<Cliente>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar));
            }

            return await PagedList<Cliente>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }



    }
}
