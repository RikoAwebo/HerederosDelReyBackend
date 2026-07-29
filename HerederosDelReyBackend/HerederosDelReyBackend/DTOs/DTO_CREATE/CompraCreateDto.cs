using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.DTOs.DTO_CREATE
{
    public class CompraCreateDto
    {

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


    }
}
