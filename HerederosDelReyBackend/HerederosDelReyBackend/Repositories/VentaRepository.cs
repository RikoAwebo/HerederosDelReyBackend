using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class VentaRepository : GenericRepository<Venta>,
        IVentaRepository
    {
        public VentaRepository(HerederosDelReyContext context) : base(context)
        {
        }
    }
}
