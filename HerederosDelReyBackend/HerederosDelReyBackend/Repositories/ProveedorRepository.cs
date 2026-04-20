using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class ProveedorRepository : GenericRepository<Proveedore>,
        IProveedorRepository
    {
        public ProveedorRepository(HerederosDelReyContext context) : base(context)
        {
        }
    }
}
