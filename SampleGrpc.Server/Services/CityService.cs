using AutoMapper;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using SampleGrpc.Server.Models;
using SampleGrpc.Server.Protos;

namespace SampleGrpc.Server.Services
{
    public class CityService : CityProtoService.CityProtoServiceBase
    {
        private readonly IMapper _mapper;

        public CityService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override async Task<GetCitiesResponse> GetCities(GetCityRequest request, ServerCallContext context)
        {
            var citiesModel = _mapper.Map<List<CityModel>>(City.GetCities());

            var response = new GetCitiesResponse();
            response.Cities.AddRange(citiesModel);
            return response;
        }

        public override async Task<CityModel?> GetCityByName(GetCityByNameRequest request, ServerCallContext context)
        {
            var cities = City.GetCities();
            var city = cities.SingleOrDefault(c => c.Name.Equals(request.Name, StringComparison.InvariantCultureIgnoreCase));

            var response = _mapper.Map<CityModel?>(city);
            return response;
        }

        [Authorize]
        public override async Task<AddCityResponse> AddCity(CityModel request, ServerCallContext context)
        {
            var loggedUser = context.GetHttpContext().User.Identity?.Name;
            Console.WriteLine($"User who requested: {loggedUser}"); 

            var city = _mapper.Map<City>(request);
            City.AddCity(city);

            var cities = City.GetCities();
            var response = new AddCityResponse
            {
                Success = cities.Any(c => c.Name.Equals(request.Name)),
            };
            return response;
        }
    }
}