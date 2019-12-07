using AutoMapper;
using Core.DTO;
using Core.Entities;

namespace Core.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Car, CarDTO>();
            CreateMap<CarType, CarDTO>().ForMember(d => d.CarTypeName, o => o.MapFrom(s => s.Name));
        }
    }
}