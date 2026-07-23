namespace HerederosDelReyBackend.DTOs.DTO_CREATE
{
    public class CajaCreateDto
    {
        public int IdSucursal { get; set; }

        public int IdUsuarioApertura { get; set; }

        public int? IdUsuarioCierre { get; set; }

        public DateTime FechaApertura { get; set; }

        public DateTime? FechaCierre { get; set; }

        public decimal MontoInicial { get; set; }

        public decimal? MontoFinal { get; set; }

        public string EstadoCaja { get; set; } = null!;

        public string? Observacion { get; set; }


    }
}
