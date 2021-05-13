using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.Applicaton.Services;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
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
        //private readonly IRepository<User> _userService;
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await _userService.GetByIdAsync(id);
            //return result;
        }

        [HttpPost("auth")]
        public async Task<UserResponse> Auth(UserRequest userRequest)
        {
            //if (userRequest == null)
            //{
            //    return BadRequest("TripOrder is null");
            //}
            //return Ok("TripOrder created");

            return await _userService.AuthorizationAsync(userRequest);

            //return Ok("TripOrder created");
        }
    }
}
