using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Categorias.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoriaDto>>(lista);
        }

        public CategoriaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CategoriaDto> AddAsync(CategoriaCreateDto dto)
        {
            var Objeto = _mapper.Map<Categoria>(dto);

            await _unitOfWork.Categorias.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<CategoriaDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Categorias.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;    
        }

        

        public async Task<CategoriaDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Categorias.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<CategoriaDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, CategoriaUpdateDto dto)
        {
            if (id == null)
                return false;

            var Objeto = _unitOfWork.Categorias.GetByIdAsync(id).Result;
            if (Objeto == null)
                return false;

            Objeto.Nombre = dto.Nombre;
            Objeto.Descripcion = dto.Descripcion;
       

            _unitOfWork.Categorias.Update(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<CategoriaDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var categorias = await _unitOfWork.Categorias.GetAllAsync(filter);
            var categoriasDto = _mapper.Map<IEnumerable<CategoriaDto>>(categorias);

            return new ApiResponse<IEnumerable<CategoriaDto>>(categoriasDto, categorias.MetaData);
        }
    }
}
