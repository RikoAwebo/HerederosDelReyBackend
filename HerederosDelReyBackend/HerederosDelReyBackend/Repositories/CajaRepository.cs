using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Repositories
{
    public class CajaRepository : GenericRepository<Caja>,
        ICajaRepository
    {
        public CajaRepository(HerederosDelReyContext context) : base(context)
        {
        }
    }
}
