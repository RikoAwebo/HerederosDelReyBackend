using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Marca : BaseEntity
{

    public string? Nombre { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
