using Microsoft.AspNetCore.Mvc;
using SampleGrpc.Client.GrpcServices;
using SampleGrpc.Client.Models;

namespace SampleGrpc.Client.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CityController : ControllerBase
    {
        private readonly CityGrpcService _cityGrpcService;

        public CityController(CityGrpcService cityGrpcService)
        {
            _cityGrpcService = cityGrpcService;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            return Ok(await _cityGrpcService.GetCities());
        }

        [HttpGet("{name}")]
        public async Task<object> Get(string name)
        {
            return Ok(await _cityGrpcService.GetCityByName(name));
        }

        [HttpPost]
        public async Task<object> Post(City city)
        {
            return Ok(await _cityGrpcService.AddCity(city));
        }
    }
}