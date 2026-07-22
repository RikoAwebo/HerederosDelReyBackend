using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class ImagenesProducto
{
    public int IdImagen { get; set; }

    public int IdProducto { get; set; }

    public string? NombreArchivo { get; set; }

    public string RutaImagen { get; set; } = null!;

    public bool? EsPrincipal { get; set; }

    public bool? Estado { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
