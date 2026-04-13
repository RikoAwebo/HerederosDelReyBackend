using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Producto : BaseEntity
{

    public string? Nombre { get; set; }

    public int? Stock { get; set; }

    public int? StockMinimo { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public DateOnly? FechaCaducidad { get; set; }

    public int? CategoriaId { get; set; }

    public int? MarcaId { get; set; }

    public virtual Categoria? Categoria { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Marca? Marca { get; set; }
}
