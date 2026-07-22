namespace HerederosDelReyBackend.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public DateTime? FechaEliminacion { get; set; }
    }
}


