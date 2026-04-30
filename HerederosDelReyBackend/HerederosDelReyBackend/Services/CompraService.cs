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
            var objeto = await _unitOfWork.Compra.GetAllAsync(filter);
            var objetoDto = _mapper.Map<IEnumerable<CompraDto>>(objeto);

            return new ApiResponse<IEnumerable<CompraDto>>(objetoDto, objeto.MetaData);
        }

        public async Task<bool> CompraDetalle(CompraDetalleDto dto)
        {
            if (dto == null || dto.Compra == null)
                throw new Exception("Datos de compra inválidos");

            // =========================
            // 1. CREAR COMPRA
            // =========================
            var compra = _mapper.Map<Compra>(dto.Compra);
            compra.Fecha = DateTime.Now;

            await _unitOfWork.Compra.AddAsync(compra);
            await _unitOfWork.SaveChangesAsync(); // genera ID

            // =========================
            // 2. VALIDAR DETALLES
            // =========================
            if (dto.Detalle == null || !dto.Detalle.Any())
                throw new Exception("La compra no tiene detalles");

            foreach (var detalleDto in dto.Detalle)
            {
                var detalle = _mapper.Map<DetalleCompra>(detalleDto);

                detalle.CompraId = compra.Id;

                // =========================
                // 3. VALIDAR PRODUCTO
                // =========================
                if (detalle.ProductoId > 0)
                {

                    var producto = await _unitOfWork.Productos.GetByIdAsync(detalle.ProductoId);

                    if (producto == null)
                        throw new Exception("Producto no encontrado");

                    // =========================
                    // AUMENTAR STOCK
                    // =========================
                    producto.Stock += detalle.Cantidad;

                    _unitOfWork.Productos.Update(producto);
                }

                await _unitOfWork.DetalleCompras.AddAsync(detalle);
            }

             //=========================
             //4.GUARDAR TODO JUNTO
             //=========================
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
