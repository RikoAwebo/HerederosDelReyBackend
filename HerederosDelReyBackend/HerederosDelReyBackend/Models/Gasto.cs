using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Gasto : BaseEntity
{
    public string? Descripcion { get; set; }

    public double? Monto { get; set; }

    public string? TipoGasto { get; set; }
}
