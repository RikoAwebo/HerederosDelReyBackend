using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class CategoriaRepository : GenericRepository<Categoria>,
        ICategoriaRepository
    {
        public CategoriaRepository(HerederosDelReyContext context) : base(context)
        {
            
        }
        public async Task<PagedList<Categoria>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.Nombre.ToLower().Contains(buscar));
            }

            return await PagedList<Categoria>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }
    }
}
