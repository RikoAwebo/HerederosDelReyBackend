using AutoMapper;
using HerederosDelReyBackend.Data;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HerederosDelReyBackend.Services
{
    public class VentaService: IVentaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VentaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<VentaDto> AddAsync(VentaCreateDto dto)
        {
            var Objeto = _mapper.Map<Venta>(dto);

            await _unitOfWork.Ventas.AddAsync(Objeto);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<VentaDto>(Objeto);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var objeto = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (objeto == null)
                return false;

            await _unitOfWork.Ventas.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }   

        public async Task<IEnumerable<VentaDto>> GetAllAsync()
        {
            var lista = await _unitOfWork.Ventas.GetAllAsync();
            return _mapper.Map<IEnumerable<VentaDto>>(lista);
        }

        public async Task<VentaDto?> GetByIdAsync(int id)
        {
            var objeto = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (objeto == null)
                return null;

            return _mapper.Map<VentaDto>(objeto);
        }

        public async Task<bool> UpdateAsync(int id, VentaUpdateDto dto)
        {
            if (id == null)
                return false;

            var venta = await _unitOfWork.Ventas.GetByIdAsync(id);
            if (venta == null)
                return false;

            venta.Fecha = dto.Fecha;
            venta.Total = dto.Total;
            venta.MetodoPago = dto.MetodoPago;
            venta.Observaciones = dto.Observaciones;
            venta.ClienteId = dto.ClienteId;
            venta.UsuarioId = dto.UsuarioId;


            _unitOfWork.Ventas.Update(venta);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<ApiResponse<IEnumerable<VentaDto>>> GetAllAsync(PostQueryFilter filter)
        {
            var objeto = await _unitOfWork.Ventas.GetAllAsync(filter);

            var objetoDto = objeto.Select(v => new VentaDto
            {
                Id = v.Id,
                Fecha = v.Fecha,
                Total = v.Total,
                ClienteId = v.ClienteId,
                UsuarioId = v.UsuarioId,

                UsuarioNombre = v.Usuario != null
                    ? v.Usuario.NombreUsuario
                    : "Sin usuario",
                ClienteNombre = v.Cliente != null
                    ? v.Cliente.Nombre
                    : "Sin usuario"


            });

            return new ApiResponse<IEnumerable<VentaDto>>(objetoDto, objeto.MetaData);
        }



        public async Task<bool> VentaDetalle(VentaDetalleDto dto)
        {
            if (dto == null || dto.Venta == null)
                throw new Exception("Datos de venta inválidos");

            // =========================
            // 1. CREAR VENTA
            // =========================
            var venta = _mapper.Map<Venta>(dto.Venta);
            venta.Fecha = DateTime.Now;

            await _unitOfWork.Ventas.AddAsync(venta);
            await _unitOfWork.SaveChangesAsync(); // genera ID

            // =========================
            // 2. VALIDAR DETALLES
            // =========================
            if (dto.Detalle == null || !dto.Detalle.Any())
                throw new Exception("La venta no tiene detalles");

            foreach (var detalleDto in dto.Detalle)
            {
                var detalle = _mapper.Map<DetalleVenta>(detalleDto);

                detalle.VentaId = venta.Id;

                // =========================
                // 3. VALIDAR PRODUCTO
                // =========================
                if (detalle.ProductoId > 0)
                {
                    var producto = await _unitOfWork.Productos.GetByIdAsync(detalle.ProductoId.Value);

                    if (producto == null)
                        throw new Exception("Producto no encontrado");

                    if (producto.Stock < detalle.Cantidad)
                        throw new Exception($"Stock insuficiente para {producto.Nombre}");

                    producto.Stock -= detalle.Cantidad;
                    _unitOfWork.Productos.Update(producto);
                }

                await _unitOfWork.DetalleVentas.AddAsync(detalle);
            }

            // =========================
            // 4. GUARDAR TODO JUNTO
            // =========================
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
