using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
