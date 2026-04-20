using HerederosDelReyBackend.Models;


namespace HerederosDelReyBackend.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        IQueryable<T> GetAllAsQueryable();
        Task DeleteAsync(int id);
    }
}
