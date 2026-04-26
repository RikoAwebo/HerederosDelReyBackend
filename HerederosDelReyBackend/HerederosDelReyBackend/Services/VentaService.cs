using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class VentaService: IVentaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VentaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VentaDto> AddAsync(VentaCreateDto dto)
        {
            var Objeto = _mapper.Map<Venta>(dto);

            await _unitOfWork.Ventas.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<VentaDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Ventas.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }   

        public async Task<IEnumerable<VentaDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Ventas.GetAllAsync();
            return _mapper.Map<IEnumerable<VentaDto>>(lista);
        }

        public async Task<VentaDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<VentaDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, VentaUpdateDto dto)
        {
            if (id == null)
                return false;

            var venta = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (venta == null)
                return false;

            venta.Fecha = dto.Fecha;
            venta.Total = dto.Total;
            venta.MetodoPago = dto.MetodoPago;
            venta.Observaciones = dto.Observaciones;
            venta.ClienteId = dto.ClienteId;
            venta.UsuarioId = dto.UsuarioId;


            _unitOfWork.Ventas.Update(venta);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<ApiResponse<IEnumerable<VentaDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var objeto = await _unitOfWork.Clientes.GetAllAsync(filter);
            var objetoDto = _mapper.Map<IEnumerable<VentaDto>>(objeto);

            return new ApiResponse<IEnumerable<VentaDto>>(objetoDto, objeto.MetaData);
        }
    }
}
