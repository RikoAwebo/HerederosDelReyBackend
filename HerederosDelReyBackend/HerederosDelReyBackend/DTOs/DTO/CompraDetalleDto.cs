using HerederosDelReyBackend.DTOs.DTO;
using HerederosDelReyBackend.DTOs.DTO_CREATE;

namespace HerederosDelReyBackend.DTOs
{
    public class CompraDetalleDto
    {
        public CompraDto Compra { get; set; }
        public List<DetalleCompraDto> Detalle { get; set; }
    }
}
