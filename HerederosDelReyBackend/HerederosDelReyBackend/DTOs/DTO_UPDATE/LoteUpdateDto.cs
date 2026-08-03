namespace HerederosDelReyBackend.DTOs.DTO_UPDATE
{
    public class LoteUpdateDto
    {
       
        public int IdProducto { get; set; }

        public string NumeroLote { get; set; } = null!;

        public DateOnly? FechaFabricacion { get; set; }

        public DateOnly? FechaVencimiento { get; set; }

        public decimal CantidadInicial { get; set; }

        public decimal CantidadDisponible { get; set; }

        
    }
}
