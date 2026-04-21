using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public MarcaService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MarcaDto>> GetAllAsync()
        {
            var marcas = await _unitOfWork.Marca.GetAllAsync();
            return marcas.Select(m => new MarcaDto
            {
                Id = m.Id,
                Nombre = m.Nombre
            });
        }

        public async Task<MarcaDto?> GetByIdAsync(int id)
        {
            var marca = await _unitOfWork.Marca.GetByIdAsync(id);
            if (marca == null) return null;
            return new MarcaDto
            {
                Id = marca.Id,
                Nombre = marca.Nombre
            };
        }

        public async Task<MarcaDto> AddAsync(MarcaCreateDto dto)
        {
            var marca = new Marca
            {
                Nombre = dto.Nombre
            };
            await _unitOfWork.Marca.AddAsync(marca);
            await _unitOfWork.SaveChangesAsync();
            return new MarcaDto
            {
                Id = marca.Id,
                Nombre = marca.Nombre
            };
        }

        public async Task<bool> UpdateAsync(int id, MarcaUpdateDto dto)
        {
            var marca = await _unitOfWork.Marca.GetByIdAsync(id);
            if (marca == null) return false;
            marca.Nombre = dto.Nombre;
            _unitOfWork.Marca.Update(marca);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var marca = await _unitOfWork.Marca.GetByIdAsync(id);
            if (marca == null) return false;
            await _unitOfWork.Marca.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<ApiResponse<IEnumerable<MarcaDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var marcas = await _unitOfWork.Marca.GetAllAsync(filter);
            var marcasDto = _mapper.Map<IEnumerable<MarcaDto>>(marcas);

            return new ApiResponse<IEnumerable<MarcaDto>>(marcasDto, marcas.MetaData);
        }


    }
}