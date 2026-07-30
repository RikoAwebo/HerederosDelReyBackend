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
    public class SucursaleService : ISucursalService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public async Task<IEnumerable<SucursaleDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Sucursale.GetAllAsync();
            return _mapper.Map<IEnumerable<SucursaleDto>>(lista);
        }

        public SucursaleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<SucursaleDto> AddAsync(SucursaleCreateDto dto)
        {
            var Objeto = _mapper.Map<Sucursale>(dto);

            await _unitOfWork.Sucursale.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<SucursaleDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Sucursale.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Sucursale.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }



        public async Task<SucursaleDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Sucursale.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<SucursaleDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, SucursaleUpdateDto dto)
        {
            if (id == null)
                return false;

            var Objeto = _unitOfWork.Sucursale.GetByIdAsync(id).Result;
            if (Objeto == null)
                return false;

            Objeto.Nombre = dto.Nombre;
            Objeto.Telefono = dto.Telefono;
            Objeto.Direccion = dto.Direccion;
            Objeto.Correo = dto.Correo;

            _unitOfWork.Sucursale.Update(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<SucursaleDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var sucursales   = await _unitOfWork.Categorias.GetAllAsync(filter);
            var sucursalesDto = _mapper.Map<IEnumerable<SucursaleDto>>(sucursales);

            return new ApiResponse<IEnumerable<SucursaleDto>>(sucursalesDto, sucursales.MetaData);
        }
    }
}
