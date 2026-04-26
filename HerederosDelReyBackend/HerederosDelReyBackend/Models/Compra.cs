using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Compra : BaseEntity
{
    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public string? Descripcion { get; set; }

    public int? ProveedorId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedor? Proveedor { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
