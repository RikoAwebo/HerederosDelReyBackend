using HerederosDelReyBackend.DTOs;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IVentaService
    {
        Task<IEnumerable<VentaDto>> GetAllAsync();
        Task<VentaDto?> GetByIdAsync(int id);
        Task<VentaDto> AddAsync(VentaCreateDto dto);
        Task<bool> UpdateAsync(int id, VentaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
