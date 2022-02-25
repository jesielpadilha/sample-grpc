using AutoMapper;
using Grpc.Core;
using SampleGrpc.Client.Models;
using SampleGrpc.Server.Protos;

namespace SampleGrpc.Client.GrpcServices
{
    public class CityGrpcService
    {
        private readonly CityProtoService.CityProtoServiceClient _cityProtoService;
        private readonly IMapper _mapper;

        public CityGrpcService(CityProtoService.CityProtoServiceClient cityProtoService,
            IMapper mapper)
        {
            _cityProtoService = cityProtoService;
            _mapper = mapper;
        }

        public async Task<List<City>> GetCities()
        {
            var request = new GetCityRequest();
            var citiesModel = await _cityProtoService.GetCitiesAsync(request);
            var response = _mapper.Map<List<City>>(citiesModel.Cities);
            return response;
        }

        public async Task<City?> GetCityByName(string name)
        {
            var request = new GetCityByNameRequest
            {
                Name = name
            };
            var cityModel = await _cityProtoService.GetCityByNameAsync(request);
            var response = _mapper.Map<City?>(cityModel);
            return response;
        }

        public async Task<bool> AddCity(City city)
        {
            var request = _mapper.Map<CityModel>(city);
            var response = await _cityProtoService.AddCityAsync(request, headers: GetHeaders(city.AuthToken));
            return response.Success;
        }

        private Metadata GetHeaders(string token)
        {
            var headers = new Metadata
            {
                { "Authorization", $"Bearer {token}" }
            };
            return headers;
        }
    }
}