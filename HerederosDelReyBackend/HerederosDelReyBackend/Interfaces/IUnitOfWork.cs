namespace HerederosDelReyBackend.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository Usuarios { get; }
        IClienteRepository Clientes { get; }

        ICategoriaRepository Categorias { get; }
        IProveedorRepository Proveedores { get; }
        ICompraRepository Compra { get; }
        IDetalleCompraRepository DetalleCompras { get; }
        ICajaRepository Caja { get; }
        IVentaRepository Ventas { get; }


        IMarcaRepository Marca { get; }

        IGastosRepository Gastos { get; }

        IProductoRepository Productos { get; }

        IDetalleVentaRepository DetalleVentas { get; }

        Task<int> SaveChangesAsync();
    }
}
