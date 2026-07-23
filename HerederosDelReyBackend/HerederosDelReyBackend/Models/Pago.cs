using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Pago : BaseEntity
{

    public int IdVenta { get; set; }

    public int IdCaja { get; set; }

    public string MetodoPago { get; set; } = null!;

    public decimal Monto { get; set; }

    public string? Referencia { get; set; }

    public string? Observacion { get; set; }

    
    public virtual Caja IdCajaNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
