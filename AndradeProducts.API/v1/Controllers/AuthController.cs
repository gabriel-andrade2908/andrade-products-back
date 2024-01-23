using AndradeProducts.API.v1.Controllers.Base;
using AndradeProducts.Domain.DTOs.User;
using AndradeProducts.Domain.v1.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace AndradeProducts.API.v1.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/auth/")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authServices;

        public AuthController(IAuthService authServices)
        {
            _authServices = authServices;
        }

        [HttpGet("login")]
        [SwaggerOperation("Authenticate user")]
        [SwaggerResponse(StatusCodes.Status200OK, "", typeof(LoginResponse))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "User not found", typeof(string))]
        public async Task<IActionResult> Login(string userName, string password)
        {
            return Ok(await _authServices.LoginAsync(userName, password));
        }
    }
}
