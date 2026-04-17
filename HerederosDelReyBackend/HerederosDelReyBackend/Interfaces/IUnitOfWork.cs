namespace HerederosDelReyBackend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IClienteRepository Clientes { get; }
        Task<int> SaveChangesAsync();
    }
}
