using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class ImagenesProducto : BaseEntity
{

    public int IdProducto { get; set; }

    public string? NombreArchivo { get; set; }

    public string RutaImagen { get; set; } = null!;

    public bool? EsPrincipal { get; set; }


    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
