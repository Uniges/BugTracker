using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.Applicaton.Services;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using BugTracker.WebApp.Helpers;
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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userService.GetByIdAsync(id);
        }

        [HttpPost("auth")]
        public async Task<UserResponse> Auth(UserRequest userRequest)
        {
            //if (userRequest == null)
            //{
            //    return BadRequest("TripOrder is null");
            //}
            //return Ok("TripOrder created");

            var user = await _userService.AuthorizationAsync(userRequest);
            var token = _configuration.GenerateJwtToken(user);
            return new UserResponse() { Token = token };

            //return Ok("TripOrder created");
        }
    }
}
