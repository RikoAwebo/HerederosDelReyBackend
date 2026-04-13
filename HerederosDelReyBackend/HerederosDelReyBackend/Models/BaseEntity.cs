namespace HerederosDelReyBackend.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool Borrado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
