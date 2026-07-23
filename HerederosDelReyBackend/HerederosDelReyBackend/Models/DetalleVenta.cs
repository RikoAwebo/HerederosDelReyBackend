using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class DetalleVenta : BaseEntity
{
    
    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int? IdLote { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioVenta { get; set; }

    public decimal Descuento { get; set; }

    public decimal Impuesto { get; set; }

    public decimal SubTotal { get; set; }

    
    public virtual Lote? IdLoteNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
