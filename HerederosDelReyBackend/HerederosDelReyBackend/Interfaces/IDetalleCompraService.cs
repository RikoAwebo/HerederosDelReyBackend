using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IDetalleCompraService
    {
        Task<IEnumerable<DetalleCompraDto>> GetAllAsync();
        Task<DetalleCompraDto?> GetByIdAsync(int id);
        Task<DetalleCompraDto> AddAsync(DetalleCompraCreateDto dto);
        Task<bool> UpdateAsync(int id, DetalleCompraUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
