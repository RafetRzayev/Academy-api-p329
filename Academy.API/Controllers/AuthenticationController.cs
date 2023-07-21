using Academy.AuthenticationService.Contracts;
using Academy.AuthenticationService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Academy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(TokenRequestModel model)
        {
            var token = await _authService.CreateToken(model);
            var tokenResponeModel = new TokenResponseModel { Token = token };
           
            return Ok(tokenResponeModel);
        }
    }

    class TokenResponseModel
    {
        public string Token { get; set; }
    }
}
