using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Usuario : BaseEntity
{

    public string? NombreUsuario { get; set; }

    public string? Email { get; set; }

    public string? Clave { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
