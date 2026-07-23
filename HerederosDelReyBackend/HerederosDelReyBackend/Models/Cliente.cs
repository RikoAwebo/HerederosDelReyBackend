using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Cliente : BaseEntity
{

    public string Nombres { get; set; } = null!;

    public string? Apellidos { get; set; }

    public string? NitCi { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Observacion { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
