using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Venta : BaseEntity
{
    public DateTime? Fecha { get; set; }

    public decimal? Total { get; set; }

    public string? MetodoPago { get; set; }

    public string? Observaciones { get; set; }

    public int? ClienteId { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Cliente? Cliente { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Usuario? Usuario { get; set; }
}
