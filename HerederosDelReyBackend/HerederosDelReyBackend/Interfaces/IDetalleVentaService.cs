using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Interfaces
{
    public interface IDetalleVentaService
    {
        Task<IEnumerable<DetalleVentaDto>> GetAllAsync();
        Task<DetalleVentaDto> AddAsync(DetalleVentaCreateDto dto);
        Task<DetalleVentaDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, DetalleVentaUpdateDto dto);
        Task<bool> DeleteAsync(int id);
        Task<ApiResponse<IEnumerable<DetalleVentaDto>>> GetAllAsync(PostQueryFilter filter);
    }
}
