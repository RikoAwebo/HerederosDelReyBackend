using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Proveedore : BaseEntity
{

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Nit { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Direccion { get; set; }

    public string? Observacion { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();
}
