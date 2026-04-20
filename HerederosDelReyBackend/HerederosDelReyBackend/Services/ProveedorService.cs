using AutoMapper;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using HerederosDelReyBackend.Repositories;

namespace HerederosDelReyBackend.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProveedorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProveedoresDto> AddAsync(ProveedoresCreateDto dto)
        {
            var Objeto = _mapper.Map<Proveedore>(dto);

            await _unitOfWork.Proveedores.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProveedoresDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Proveedores.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ProveedoresDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Proveedores.GetAllAsync();
            return _mapper.Map<IEnumerable<ProveedoresDto>>(lista);
        }

        public async Task<ProveedoresDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Proveedores.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<ProveedoresDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, ProveedoresUptadeDto dto)
        {
            if (id == null)
                return false;

            var proveedor = _unitOfWork.Proveedores.GetByIdAsync(id).Result;
            if (proveedor == null)
                return false;

            proveedor.Nombre = dto.Nombre;
            proveedor.Telefono = dto.Telefono;
            proveedor.Email = dto.Email;
            proveedor.Direccion = dto.Direccion;


            _unitOfWork.Proveedores.Update(proveedor);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
