using AutoMapper;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Interfaces;
using HerederosDelReyBackend.Repositories;

namespace HerederosDelReyBackend.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ReporteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ReporteDto>> GetReport(DateTime fechaInicial, DateTime fechaFinal)
        {
            var Objeto = new ReporteDto();
            var Gastos = await _unitOfWork.Gastos.GetAllAsync();
            var detalles = await _unitOfWork.DetalleVentas.GetDetallesFecha(fechaInicial, fechaFinal);
            Objeto.FechaInicio = fechaInicial;
            Objeto.FechaFinal = fechaFinal;

            Objeto.InversionTotal = (double)detalles.Sum(x => x.PrecioCompra * x.Cantidad);
            Objeto.TotalGen = (double)detalles.Sum(x => x.PrecioUnitario * x.Cantidad);
        
            Objeto.GastoTotal = Gastos.Where(x => x.FechaCreacion.Date >= fechaInicial.Date && x.FechaCreacion.Date <= fechaFinal.Date).Sum(x => x.Monto);
            Objeto.GanaciaNeta = Objeto.TotalGen - (Objeto.GastoTotal + Objeto.InversionTotal);
                           
            Objeto.Productos = detalles
                .Select(x => new ProductoReporteDto
                {
                    Nombre = x.Producto.Nombre ?? "Desconocido",
                    Cantidad = x.Cantidad,
                    PrecioCompra = x.PrecioCompra,
                    PrecioVenta = x.PrecioUnitario
                }).ToList();

            return new List<ReporteDto> { Objeto };



        }

    }
}
