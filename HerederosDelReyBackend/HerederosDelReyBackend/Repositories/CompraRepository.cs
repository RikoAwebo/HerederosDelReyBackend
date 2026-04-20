using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class CompraRepository : GenericRepository<Compra>,
        ICompraRepository
    {
        public CompraRepository(HerederosDelReyContext context) : base(context)
        {
        }
    }
}
