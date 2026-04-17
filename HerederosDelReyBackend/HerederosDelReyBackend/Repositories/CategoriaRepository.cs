using HerederosDelReyBackend.Data;
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
    }
}
