using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class DetalleCompra : BaseEntity
{
  

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal? Subtotal { get; set; }



    public int CompraId { get; set; }

    public int ProductoId { get; set; }

    public virtual Compra Compra { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
