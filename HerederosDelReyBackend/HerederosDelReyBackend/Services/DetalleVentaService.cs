using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class DetalleVentaService : IDetalleVentaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DetalleVentaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
        }

        public async Task<DetalleVentaDto> AddAsync(DetalleVentaCreateDto dto)
        {
            var Objeto = _mapper.Map<DetalleVenta>(dto);

            await _unitOfWork.DetalleVentas.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DetalleVentaDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.DetalleVentas.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.DetalleVentas.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DetalleVentaDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.DetalleVentas.GetAllAsync();
            return _mapper.Map<IEnumerable<DetalleVentaDto>>(lista);
        }

        public async Task<DetalleVentaDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.DetalleVentas.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<DetalleVentaDto>(objeto);
        }


        public async Task<bool> UpdateAsync(int id, DetalleVentaUpdateDto dto)
        {
            if (id == null)
                return false;

            var venta = _unitOfWork.DetalleVentas.GetByIdAsync(id).Result;
            if (venta == null)
                return false;

            venta.ProductoId = dto.ProductoId;
            venta.Cantidad = dto.Cantidad;
            venta.PrecioUnitario = dto.PrecioUnitario;
            venta.Subtotal = dto.Subtotal;
            venta.VentaId = dto.VentaId;
            venta.PrecioCompra = dto.PrecioCompra;

            _unitOfWork.DetalleVentas.Update(venta);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<DetalleVentaDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var objeto = await _unitOfWork.Clientes.GetAllAsync(filter);
            var objetoDto = _mapper.Map<IEnumerable<DetalleVentaDto>>(objeto);

            return new ApiResponse<IEnumerable<DetalleVentaDto>>(objetoDto, objeto.MetaData);
        }
    }
}
