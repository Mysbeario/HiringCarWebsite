using AutoMapper;
using Core.DTO;
using Core.Entities;

namespace Core.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile () {
            CreateMap<Car, CarDTO>();
            CreateMap<CarType, CarDTO>().ForMember(d => d.CarTypeName, o => o.MapFrom(s => s.Name)).ForMember(d => d.Id, o => o.Ignore());
            CreateMap<Booking, BookingDTO>().ForMember(d => d.PickUpDate, o => o.MapFrom(s => s.PickUpDate.ToString("yyyy-MM-dd")))
                .ForMember(d => d.DropOffDate, o => o.MapFrom(s => s.DropOffDate.ToString("yyyy-MM-dd")));
        }
    }
}