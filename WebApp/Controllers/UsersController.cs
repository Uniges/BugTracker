using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.WebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace BugTracker.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("auth")]
        public async Task<JsonResult> Auth(UserRequest userRequest)
        {
            return new JsonResult(new { token = _configuration.GenerateJwtToken(await _userService.AuthorizationAsync(userRequest)) }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize]
        [HttpPut("edit")]
        public async Task Update(UserUpdateRequest userUpdateRequest)
        {
            await _userService.UpdateByUserAsync(userUpdateRequest);
        }
    }
}
