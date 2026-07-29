namespace HerederosDelReyBackend.DTOs.DTO_UPDATE
{
    public class CompraUpdateDto
    {
        
        public string TipoDocumento { get; set; } = null!;

        public string? NumeroDocumento { get; set; }
        public decimal Descuento { get; set; }
        public string? Observacion { get; set; }

        public string EstadoCompra { get; set; } = null!;


    }
}
