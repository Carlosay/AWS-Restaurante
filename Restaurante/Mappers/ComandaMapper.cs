using AutoMapper;
using Restaurante.Dto;
using Restaurante.Entities;

namespace Restaurante.Mappers
{
    public class ComandaMapper : Profile
    {
        public ComandaMapper() 
        { 
            this.CreateMap<ComandaRequestDto, Comanda>().ReverseMap();
        }
    }
}
