using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Caja:BaseEntity
{
    public int IdSucursal { get; set; }

    public int IdUsuarioApertura { get; set; }

    public int? IdUsuarioCierre { get; set; }

    public DateTime FechaApertura { get; set; }

    public DateTime? FechaCierre { get; set; }

    public decimal MontoInicial { get; set; }

    public decimal? MontoFinal { get; set; }

    public string EstadoCaja { get; set; } = null!;

    public string? Observacion { get; set; }

    

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioAperturaNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioCierreNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
