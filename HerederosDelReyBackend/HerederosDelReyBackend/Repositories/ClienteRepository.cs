using HerederosDelReyBackend.Data;
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

      

    }
}
