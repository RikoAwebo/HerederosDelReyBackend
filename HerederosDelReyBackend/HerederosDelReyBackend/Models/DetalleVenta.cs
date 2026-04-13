using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class DetalleVenta : BaseEntity
{

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? Subtotal { get; set; }

    public int? VentaId { get; set; }

    public int? ProductoId { get; set; }

    public virtual Producto? Producto { get; set; }

    public virtual Venta? Venta { get; set; }
}
