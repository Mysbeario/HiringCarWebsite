using AutoMapper;
using Core.DTO;
using Core.Entities;

namespace Core.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Car, CarDTO>();
        }
    }
}