using Microsoft.AspNetCore.Mvc;
using SampleGrpc.Auth.Models;

namespace SampleGrpc.Auth.Controllers
{
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public AuthController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpPost]
        public IActionResult Index([FromBody] Credentials credentials)
        {
            var token = _jwtAuthenticationManager.Authenticate(credentials.Username, credentials.Password);
            return token != null
                ? Ok(token)
                : Unauthorized("Username or Password invalid");
        }
    }
}