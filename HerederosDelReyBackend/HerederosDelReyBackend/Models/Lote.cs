using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Lote
{
    public int IdLote { get; set; }

    public int IdSucursal { get; set; }

    public int IdProducto { get; set; }

    public string NumeroLote { get; set; } = null!;

    public DateOnly? FechaFabricacion { get; set; }

    public DateOnly? FechaVencimiento { get; set; }

    public decimal CantidadInicial { get; set; }

    public decimal CantidadDisponible { get; set; }

    public decimal CostoCompra { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
}
