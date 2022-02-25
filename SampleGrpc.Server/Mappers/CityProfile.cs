using AutoMapper;
using SampleGrpc.Server.Models;
using SampleGrpc.Server.Protos;

namespace SampleGrpc.Server.Mappers
{
    public class CityProfile : Profile
    {
        public CityProfile()
        {
            CreateMap<City, CityModel>().ReverseMap();
        }
    }
}