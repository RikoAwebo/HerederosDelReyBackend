using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Nit { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Observacion { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
