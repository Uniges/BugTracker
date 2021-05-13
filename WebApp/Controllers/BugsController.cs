using BugTracker.Applicaton;
using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.DAL.Repository;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using BugTracker.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugsController : ControllerBase
    {
        private readonly IBugService _bugService;

        public BugsController(IBugService bugService)
        {
            _bugService = bugService;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Bug> Get(int id)
        {
            //var user = HttpContext.Items["User"] as User;
            //;
            var result = await _bugService.GetByIdAsync(id);
            return result;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Bug>> GetAll()
        {
            var result = await _bugService.GetAllAsync();
            return result;
        }

        [Authorize]
        [HttpPost("sort")]
        public async Task<IEnumerable<Bug>> Sort(BugSortRequest bugSortRequest)
        {
            return await _bugService.GetAllSortedAsync(bugSortRequest);

            //if (userRequest == null)
            //{
            //    return BadRequest("TripOrder is null");
            //}
            //return Ok("TripOrder created");
        }

        [Authorize]
        [HttpPost("create")]
        public async Task Create(BugInputRequest bugRequest)
        {
            await _bugService.CreateByUserAsync(bugRequest, (HttpContext.Items["User"] as User).Id);
        }

        [Authorize]
        [HttpPut("edit")]
        public async Task Update(BugUpdateRequest bugUpdateRequest)
        {
            await _bugService.UpdateByUserAsync(bugUpdateRequest);
        }

        [Authorize]
        [HttpGet("history/{id}")]
        public async Task<ICollection<BugHistory>> GetBugHistory(int id)
        {
            return await _bugService.GetBugHistoryAsync(id);
        }
    }
}
