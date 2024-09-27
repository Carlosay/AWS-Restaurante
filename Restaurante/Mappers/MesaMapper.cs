using AutoMapper;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Mappers
{
    public class MesaMapper : Profile
    {
        public MesaMapper()
        {
            CreateMap<MesaRequestDto, Mesa>()
            .ReverseMap();

            CreateMap<MesaListarDTO, Mesa>()
                .ReverseMap()
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.EstadoMesa.Descripcion));

        }
    }
}
