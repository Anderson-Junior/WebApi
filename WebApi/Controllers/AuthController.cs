using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.InputModels;
using WebApi.Services.Auth;
using WebApi.Services.Users;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginInputModel loginInputModel)
        {
            var user = await _userService.GetUserAsync(loginInputModel.UserName, loginInputModel.Password);
            if (user == null)
                return NotFound("Usuário ou senha inválidos.");

            var token = _authService.Authenticate(user);

            return new
            {
                User = user,
                token = token
            };
        }
    }
}
