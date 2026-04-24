using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Proveedor : BaseEntity
{

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }


    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
