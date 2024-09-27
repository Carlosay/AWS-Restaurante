using AutoMapper;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Mappers
{
    public class EmpleadoMapper : Profile
    {
        public EmpleadoMapper()
        {
            CreateMap<EmpleadoRequestCreateDto, Empleado>()
          .ForMember(dest => dest.RolId, opt => opt.MapFrom(src => src.IdRol))
          .ForMember(dest => dest.SectorId, opt => opt.MapFrom(src => src.IdSector));


            CreateMap<Empleado, EmpleadoResponseDto>()
                  .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.Rol.Descripcion))
                  .ForMember(dest => dest.Sector, opt => opt.MapFrom(src => src.Sector.descripcion));
        }
    }
}
