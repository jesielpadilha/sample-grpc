using AutoMapper;
using SampleGrpc.Client.Models;
using SampleGrpc.Server.Protos;

namespace SampleGrpc.Client.Mappers
{
    public class CityProfile : Profile
    {
        public CityProfile() => CreateMap<City, CityModel>().ReverseMap();
    }
}