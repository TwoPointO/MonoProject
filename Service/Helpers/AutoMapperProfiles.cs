using AutoMapper;
using Service.DTOs;
using Service.Models;

namespace Service.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<VehicleMake, VehicleMakeDto>()
            .ForMember(dest => dest.Name,
             opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Abrv, opt => opt.MapFrom(src => src.Abrv));

            CreateMap<VehicleModel, VehicleModelDto>()
            .ForMember(dest => dest.MakeId, opt => opt.MapFrom(src => src.MakeId))
            .ForMember(dest => dest.Name,
            opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Abrv, opt => opt.MapFrom(src => src.Abrv));
        }
    }
}