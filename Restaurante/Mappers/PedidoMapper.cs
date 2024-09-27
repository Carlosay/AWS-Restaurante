using AutoMapper;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Mappers
{
    public class PedidoMapper : Profile
    {
        public PedidoMapper()
        {
            this.CreateMap<PedidoRequestDto, Pedido>().ReverseMap();
            CreateMap<Pedido, PedidoListarDTO>()
                .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.Producto.Descripcion))
                .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Producto.Sector.descripcion))
                .ForMember(dest => dest.estadoPedido, opt => opt.MapFrom(src => src.EstadoPedido.Descripcion));
        }
    }
}
