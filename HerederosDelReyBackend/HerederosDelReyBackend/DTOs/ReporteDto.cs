namespace HerederosDelReyBackend.DTOs
{
    public class ReporteDto
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public double? TotalGen { get; set; }
        public double? InversionTotal { get; set; }
        public double? GastoTotal { get; set; }
        public double? GanaciaNeta { get; set; }

        public List<ProductoReporteDto> Productos { get; set; }

    }
}
