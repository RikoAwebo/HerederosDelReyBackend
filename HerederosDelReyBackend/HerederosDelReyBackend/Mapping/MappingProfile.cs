using AutoMapper;
using HerederosDelReyBackend.DTOs;
using HerederosDelReyBackend.Models;

namespace HerederosDelReyBackend.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // =========================
            // VENTAS (CORRECTO)
            // =========================

            // SOLO LECTURA (NO CREACIÓN)
            CreateMap<Venta, VentaDto>()
                .ForMember(dest => dest.ClienteNombre,
                    opt => opt.MapFrom(src => src.Cliente != null ? src.Cliente.Nombre : null))
                .ForMember(dest => dest.UsuarioNombre,
                    opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.NombreUsuario : null));

            // CREAR VENTA (ESTO ES LO IMPORTANTE)
            CreateMap<VentaCreateDto, Venta>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Usuario, opt => opt.Ignore())
                .ForMember(x => x.Cliente, opt => opt.Ignore());

            CreateMap<VentaUpdateDto, Venta>();

            // =========================
            // DETALLE VENTA
            // =========================

            CreateMap<DetalleVentaDto, DetalleVenta>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.Venta, opt => opt.Ignore())
                .ForMember(x => x.Producto, opt => opt.Ignore());

            // =========================
            // TODO LO DEMÁS (SIN CAMBIOS IMPORTANTES)
            // =========================

            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<UsuarioCreateDto, Usuario>().ReverseMap();
            CreateMap<UsuarioUpdateDto, Usuario>().ReverseMap();
            CreateMap<VentaDto, Venta>().ReverseMap();
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            CreateMap<ClienteCreateDto, Cliente>().ReverseMap();
            CreateMap<ClienteUpdateDto, Cliente>().ReverseMap();

            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<CategoriaCreateDto, Categoria>().ReverseMap();
            CreateMap<CategoriaUpdateDto, Categoria>().ReverseMap();

            CreateMap<Proveedor, ProveedoresDto>().ReverseMap();
            CreateMap<ProveedoresCreateDto, Proveedor>().ReverseMap();
            CreateMap<ProveedoresUptadeDto, Proveedor>().ReverseMap();

            CreateMap<Marca, MarcaDto>().ReverseMap();
            CreateMap<MarcaCreateDto, Marca>().ReverseMap();
            CreateMap<MarcaUpdateDto, Marca>().ReverseMap();

            CreateMap<Producto, ProductoDto>()
                .ForMember(dest => dest.NombreMarca,
                    opt => opt.MapFrom(src => src.Marca != null ? src.Marca.Nombre : null))
                .ForMember(dest => dest.NombreCategoria,
                    opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.Nombre : null));

            CreateMap<ProductoCreateDto, Producto>()
                .ForMember(x => x.Marca, opt => opt.Ignore())
                .ForMember(x => x.Categoria, opt => opt.Ignore());

            CreateMap<ProductoUpdateDto, Producto>();
        }
    }
}