using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Caja : BaseEntity
{

    public decimal? MontoInicial { get; set; }

    public decimal? MontoFinal { get; set; }

    public DateTime? FechaApertura { get; set; }

    public DateTime? FechaCierre { get; set; }

    public decimal? Gastos { get; set; }

    public string? Estado { get; set; }

    public int? UsuarioId { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
