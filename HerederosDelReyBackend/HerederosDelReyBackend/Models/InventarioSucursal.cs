using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class InventarioSucursal
{
    public int IdInventario { get; set; }

    public int IdSucursal { get; set; }

    public int IdProducto { get; set; }

    public decimal StockActual { get; set; }

    public decimal StockMinimo { get; set; }

    public decimal? StockMaximo { get; set; }

    public decimal? PuntoReorden { get; set; }

    public string? Ubicacion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
}
