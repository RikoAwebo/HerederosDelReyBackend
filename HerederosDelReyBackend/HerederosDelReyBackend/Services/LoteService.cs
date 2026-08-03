using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.DTOs.DTO;
using HerederosDelReyBackend.DTOs.DTO_CREATE;
using HerederosDelReyBackend.DTOs.DTO_UPDATE;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class LoteService : ILoteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public async Task<IEnumerable<LoteDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Lote.GetAllAsync();
            return _mapper.Map<IEnumerable<LoteDto>>(lista);
        }

        public LoteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<LoteDto> AddAsync(LoteCreateDto dto)
        {
            var Objeto = _mapper.Map<Lote>(dto);

            await _unitOfWork.Lote.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<LoteDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Lote.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Lote.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }



        public async Task<LoteDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Lote.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<LoteDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, LoteUpdateDto dto)
        {
            if (id == null)
                return false;

            var Objeto = _unitOfWork.Lote.GetByIdAsync(id).Result;
            if (Objeto == null)
                return false;

            Objeto.NumeroLote = dto.NumeroLote;
            Objeto.IdProducto = dto.IdProducto;
            Objeto.FechaFabricacion = dto.FechaFabricacion;
            Objeto.FechaVencimiento = dto.FechaVencimiento; 
            Objeto.CantidadInicial = dto.CantidadInicial;
            Objeto.CantidadDisponible = dto.CantidadDisponible;

         


            _unitOfWork.Lote.Update(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<LoteDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var lotes = await _unitOfWork.Lote.GetAllAsync(filter);
            var lotesDto = _mapper.Map<IEnumerable<LoteDto>>(lotes);

            return new ApiResponse<IEnumerable<LoteDto>>(lotesDto, lotes.MetaData);
        }
    }
}
