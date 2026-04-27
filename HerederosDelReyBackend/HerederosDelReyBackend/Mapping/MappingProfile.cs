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

            CreateMap<Proveedor, ProveedoresDto>();
            CreateMap<ProveedoresCreateDto, Proveedor>();
            CreateMap<ProveedoresUptadeDto, Proveedor>();

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

            CreateMap<Marca, MarcaDto>();
            CreateMap<MarcaCreateDto, Marca>();
            CreateMap<MarcaUpdateDto, Marca>();

            CreateMap<Gasto, GastosDto>();
            CreateMap<GastosCreateDto, Gasto>();
            CreateMap<GastosUpdateDto, Gasto>();

            CreateMap<Producto, ProductoDto>()
             .ForMember(dest => dest.NombreMarca,
                 opt => opt.MapFrom(src => src.Marca != null ? src.Marca.Nombre : null))

             .ForMember(dest => dest.NombreCategoria,
                 opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Nombre : null));
            CreateMap<ProductoCreateDto, Producto>();
            CreateMap<ProductoUpdateDto, Producto>();

            CreateMap<DetalleCompra, DetalleCompraDto>();
            CreateMap<DetalleCompraCreateDto, DetalleCompra>();
            CreateMap<DetalleCompraUpdateDto, DetalleCompra>();
        }
    }
}
