using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class DetalleCompra : BaseEntity
{
    
    public int IdCompra { get; set; }

    public int IdProducto { get; set; }

    public int? IdLote { get; set; }

    public decimal Cantidad { get; set; }

    public decimal PrecioCompra { get; set; }

    public decimal Descuento { get; set; }

    public decimal Impuesto { get; set; }

    public decimal SubTotal { get; set; }

    
    public virtual Compra IdCompraNavigation { get; set; } = null!;

    public virtual Lote? IdLoteNavigation { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
