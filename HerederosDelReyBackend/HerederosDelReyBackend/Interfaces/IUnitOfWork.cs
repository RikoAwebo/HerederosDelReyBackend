namespace HerederosDelReyBackend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IClienteRepository Clientes { get; }

        ICategoriaRepository Categorias { get; }
        IProveedorRepository Proveedores { get; }
        Task<int> SaveChangesAsync();
    }
}
