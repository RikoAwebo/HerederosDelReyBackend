using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Cliente : BaseEntity
{

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }


    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
