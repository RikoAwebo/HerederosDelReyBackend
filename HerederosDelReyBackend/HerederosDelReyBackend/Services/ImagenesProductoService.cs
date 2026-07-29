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
    public class ImagenesProductoService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ImagenesProductoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ImagenesProductoDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.ImagenesProducto.GetAllAsync();
            return _mapper.Map<IEnumerable<ImagenesProductoDto>>(lista);
        }


        public async Task<ImagenesProductoDto> AddAsync(ImagenesProductoCreateDto dto)
        {
            var Objeto = _mapper.Map<ImagenesProducto>(dto);

            await _unitOfWork.ImagenesProducto.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ImagenesProductoDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.ImagenesProducto.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.ImagenesProducto.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }



        public async Task<ImagenesProductoDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.ImagenesProducto.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<ImagenesProductoDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, ImagenesProductoUpdateDto dto)
        {
            if (id == null)
                return false;

            var Objeto = _unitOfWork.ImagenesProducto.GetByIdAsync(id).Result;
            if (Objeto == null)
                return false;

            Objeto.IdProducto = dto.IdProducto;
            Objeto.NombreArchivo = dto.NombreArchivo;
            Objeto.RutaImagen = dto.RutaImagen;
            Objeto.EsPrincipal = dto.EsPrincipal;

            _unitOfWork.ImagenesProducto.Update(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<ImagenesProductoDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var imagenesProducto = await _unitOfWork.ImagenesProducto.GetAllAsync(filter);
            var imagenesProductoDto = _mapper.Map<IEnumerable<ImagenesProductoDto>>(imagenesProducto);

            return new ApiResponse<IEnumerable<ImagenesProductoDto>>(imagenesProductoDto, imagenesProducto.MetaData);
        }

    }
}
