using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class CompraService : ICompraService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CompraService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CompraDto> AddAsync(CompraCreateDto dto)
        {
            var Objeto = _mapper.Map<Compra>(dto);

            await _unitOfWork.Compra.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CompraDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Compra.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Compra.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CompraDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Compra.GetAllAsync();
            return _mapper.Map<IEnumerable<CompraDto>>(lista);
        }

        public async Task<CompraDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Compra.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<CompraDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, CompraUpdateDto dto)
        {
            if (id == null)
                return false;

            var compra = _unitOfWork.Compra.GetByIdAsync(id).Result;
            if (compra == null)
                return false;

            compra.Fecha = dto.Fecha;
            compra.Total = dto.Total;
            compra.Descripcion = dto.Descripcion;
            compra.ProveedorId = dto.ProveedorId;
            compra.UsuarioId = dto.UsuarioId;


            _unitOfWork.Compra.Update(compra);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<CompraDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var objeto = await _unitOfWork.Clientes.GetAllAsync(filter);
            var objetoDto = _mapper.Map<IEnumerable<CompraDto>>(objeto);

            return new ApiResponse<IEnumerable<CompraDto>>(objetoDto, objeto.MetaData);
        }
    }
}
