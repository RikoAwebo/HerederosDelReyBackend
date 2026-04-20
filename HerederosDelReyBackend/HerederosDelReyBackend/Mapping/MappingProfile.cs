using AutoMapper;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();

            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteCreateDto, Cliente>();
            CreateMap<ClienteUpdateDto, Cliente>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaCreateDto,  Categoria>();
            CreateMap<CategoriaUpdateDto, Categoria>();

            CreateMap<Proveedore, ProveedoresDto>();
            CreateMap<ProveedoresCreateDto, Proveedore>();
            CreateMap<ProveedoresUptadeDto, Proveedore>();

            CreateMap<Compra, CompraDto>();
            CreateMap<CompraCreateDto, Compra>();
            CreateMap<CompraUpdateDto, Compra>();

            CreateMap<DetalleCompra, DetalleCompraDto>();
            CreateMap<DetalleCompraCreateDto, DetalleCompra>();
            CreateMap<DetalleCompraUpdateDto, DetalleCompra>();

            CreateMap<Caja, CajaDto>();
            CreateMap<CajaCreateDto, Caja>();
            CreateMap<CajaUpdateDto, Caja>();

            CreateMap<Venta, VentaDto>();
            CreateMap<VentaCreateDto, Venta>();
            CreateMap<VentaUpdateDto, Venta>();
        }
    }
}
