using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public int? IdMarca { get; set; }

    public string Codigo { get; set; } = null!;

    public string? CodigoBarras { get; set; }

    public string Nombre { get; set; } = null!;

    public string? NombreGenerico { get; set; }

    public string? Descripcion { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal? Peso { get; set; }

    public bool ControlaInventario { get; set; }

    public bool ManejaLotes { get; set; }

    public bool TieneVencimiento { get; set; }

    public bool PermiteVenta { get; set; }

    public bool Estado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Marca? IdMarcaNavigation { get; set; }

    public virtual ICollection<ImagenesProducto> ImagenesProductos { get; set; } = new List<ImagenesProducto>();

    public virtual ICollection<InventarioSucursal> InventarioSucursals { get; set; } = new List<InventarioSucursal>();

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();
}
