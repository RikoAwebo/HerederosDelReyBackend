using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class CajaService : ICajaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CajaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CajaDto> AddAsync(CajaCreateDto dto)
        {
            var Objeto = _mapper.Map<Caja>(dto);

            await _unitOfWork.Caja.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CajaDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Caja.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Caja.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CajaDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Caja.GetAllAsync();
            return _mapper.Map<IEnumerable<CajaDto>>(lista);
        }

        public async Task<CajaDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Caja.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<CajaDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, CajaUpdateDto dto)
        {
            if (id == null)
                return false;

            var Objeto = _unitOfWork.Caja.GetByIdAsync(id).Result;
            if (Objeto == null)
                return false;

            Objeto.MontoInicial = dto.MontoInicial;
            Objeto.MontoFinal = dto.MontoFinal;
            Objeto.FechaApertura = dto.FechaApertura;
            Objeto.FechaCierre = dto.FechaCierre;
            Objeto.Gastos = dto.Gastos;
            Objeto.Estado = dto.Estado;
            Objeto.UsuarioId = dto.UsuarioId;


            _unitOfWork.Caja.Update(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;

        }

        public async Task<ApiResponse<IEnumerable<CajaDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var objetos = await _unitOfWork.Caja.GetAllAsync(filter);
            var objetosDto = _mapper.Map<IEnumerable<CajaDto>>(objetos);

            return new ApiResponse<IEnumerable<CajaDto>>(objetosDto, objetos.MetaData);
        }

    }

}