using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Gasto: BaseEntity
{
    
    public int IdCaja { get; set; }

    public int IdUsuario { get; set; }

    public string Concepto { get; set; } = null!;

    public string? NumeroComprobante { get; set; }

    public decimal Monto { get; set; }

    public string? Observacion { get; set; }

    public virtual Caja IdCajaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
