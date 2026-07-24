using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace HerederosDelReyBackend.Repositories
{
    public class ImagenesProductoRepository : GenericRepository <ImagenesProducto>,IImagenesProductoRepository
    {
        public ImagenesProductoRepository(HerederosDelReyContext context) : base(context)
        {
        }
        public async Task<PagedList<ImagenesProducto>> GetAllAsync(PostQueryFilter filter)
        {
            var query = GetAllAsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Buscar))
            {
                var buscar = filter.Buscar.ToLower();

                query = query.Where(x =>
                    x.NombreArchivo.ToString().ToLower().Contains(buscar));


            }

            return await PagedList<ImagenesProducto>.CreateAsync(query, filter.PageNumber, filter.PageSize);
        }

    }
}
