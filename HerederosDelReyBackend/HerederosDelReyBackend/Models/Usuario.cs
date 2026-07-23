using System;
using System.Collections.Generic;

namespace HerederosDelReyBackend.Models;

public partial class Usuario: BaseEntity
{
    public int IdSucursal { get; set; }

    public string Nombres { get; set; } = null!;

    public string? Apellidos { get; set; }

    public string? Rol { get; set; }

    public string Usuario1 { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Correo { get; set; }

    public string? Foto { get; set; }

    
    public virtual ICollection<Caja> CajaIdUsuarioAperturaNavigations { get; set; } = new List<Caja>();

    public virtual ICollection<Caja> CajaIdUsuarioCierreNavigations { get; set; } = new List<Caja>();

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<Gasto> Gastos { get; set; } = new List<Gasto>();

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
