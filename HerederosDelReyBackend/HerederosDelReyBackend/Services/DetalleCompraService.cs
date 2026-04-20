using AutoMapper;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Services
{
    public class DetalleCompraService : IDetalleCompraService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DetalleCompraService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<DetalleCompraDto> AddAsync(DetalleCompraCreateDto dto)
        {
            var Objeto = _mapper.Map<DetalleCompra>(dto);

            await _unitOfWork.DetalleCompras.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<DetalleCompraDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.DetalleCompras.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.DetalleCompras.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DetalleCompraDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.DetalleCompras.GetAllAsync();
            return _mapper.Map<IEnumerable<DetalleCompraDto>>(lista);
        }

        public async Task<DetalleCompraDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.DetalleCompras.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<DetalleCompraDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, DetalleCompraUpdateDto dto)
        {
            if (id == null)
                return false;

            var compra = _unitOfWork.DetalleCompras.GetByIdAsync(id).Result;
            if (compra == null)
                return false;

            compra.Producto = dto.Producto;
            compra.Cantidad = dto.Cantidad;
            compra.Precio = dto.Precio;
            compra.Subtotal = dto.Subtotal;
            compra.CompraId = dto.CompraId;


            _unitOfWork.DetalleCompras.Update(compra);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
