using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdSucursal { get; set; }

    public int IdProveedor { get; set; }

    public int IdUsuario { get; set; }

    public string TipoDocumento { get; set; } = null!;

    public string? NumeroDocumento { get; set; }

    public DateTime FechaCompra { get; set; }

    public decimal SubTotal { get; set; }

    public decimal Descuento { get; set; }

    public decimal Impuesto { get; set; }

    public decimal Total { get; set; }

    public string? Observacion { get; set; }

    public string EstadoCompra { get; set; } = null!;

    public bool Estado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
