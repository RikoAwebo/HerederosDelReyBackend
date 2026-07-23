using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Sucursale: BaseEntity
{
    
    public string Nombre { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

   
    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<InventarioSucursal> InventarioSucursals { get; set; } = new List<InventarioSucursal>();

    public virtual ICollection<Lote> Lotes { get; set; } = new List<Lote>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
