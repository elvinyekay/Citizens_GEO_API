using AutoMapper;
using Citizen_Geo_API.DTOs;
using Citizen_Geo_API.Models;

namespace Citizen_Geo_API.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Citizen, CitizenDto>().ReverseMap();
    }
}