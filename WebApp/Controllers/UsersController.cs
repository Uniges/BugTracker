using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.Applicaton.Services;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using BugTracker.WebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //[Authorize]
        //[HttpGet("{id}")]
        //public async Task<User> Get(int id)
        //{
        //    return await _userService.GetByIdAsync(id);
        //}

        [HttpPost("auth")]
        public async Task<JsonResult> Auth(UserRequest userRequest)
        {
            return new JsonResult(new { token = _configuration.GenerateJwtToken(await _userService.AuthorizationAsync(userRequest)) }) { StatusCode = StatusCodes.Status200OK };
            //return Ok("TripOrder created");
        }

        [Authorize]
        [HttpPut("edit")]
        public async Task Update(UserUpdateRequest userUpdateRequest)
        {
            await _userService.UpdateByUserAsync(userUpdateRequest);
        }
    }
}
