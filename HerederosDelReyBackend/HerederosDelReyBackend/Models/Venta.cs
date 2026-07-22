using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Venta
{
    public int IdVenta { get; set; }

    public int IdSucursal { get; set; }

    public int? IdCliente { get; set; }

    public int IdUsuario { get; set; }

    public bool Acredito { get; set; }

    public decimal MontoPagado { get; set; }

    public decimal SaldoPendiente { get; set; }

    public DateOnly? FechaLimitePago { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string? NumeroDocumento { get; set; }

    public DateTime FechaVenta { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Impuesto { get; set; }

    public decimal Total { get; set; }

    public string? Observacion { get; set; }

    public string EstadoVenta { get; set; } = null!;

    public bool Estado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
