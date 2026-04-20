using HerederosDelReyBackend.Data;
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
    }
}
