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

            compra.Observacion = dto.Observacion;
            compra.EstadoCompra = dto.EstadoCompra; 
            compra.NumeroDocumento = dto.NumeroDocumento;
            compra.TipoDocumento = dto.TipoDocumento;


            _unitOfWork.Compra.Update(compra);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ApiResponse<IEnumerable<CompraDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var objeto = await _unitOfWork.Compra.GetAllAsync(filter);

            var objetoDto = objeto.Select(c => new CompraDto { });
            //{
            //    Id = c.Id,
            //    FechaCompra = c.FechaCompra,
            //    Total = c.Total,
            //    Observacion = c.Observacion,

            //    IdProveedor = c.IdProveedor,
            //    IdUsuario = c.IdUsuario,

            //    // 👇 Llaves foráneas resueltas manualmente
            //    naviga = c.Proveedore != null
            //        ? c.Proveedore.Nombre
            //        : "Sin proveedor",

            //    NombreUsuario = c.Usuario1 != null
            //        ? c.Usuario1.NombreUsuario
            //        : "Sin usuario"
            //});

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
            compra.FechaCompra = DateTime.Now;

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

                detalle.IdCompra = compra.Id;

                // =========================
                // 3. VALIDAR PRODUCTO
                // =========================
                //if (detalle.IdProducto > 0)
                //{

                //    var inventario = await _unitOfWork.InventarioSucursal
                //    .GetByProductoSucursalAsync(detalle.IdProducto, compra.IdSucursal);

                //    if (inventario == null)
                //        throw new Exception("No existe inventario para este producto en esta sucursal.");

                //    inventario.StockActual += detalle.Cantidad;

                //    _unitOfWork.InventarioSucursal.Update(inventario);
                //}

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
