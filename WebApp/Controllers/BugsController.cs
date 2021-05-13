using BugTracker.Applicaton;
using BugTracker.DAL.Repository;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BugsController : ControllerBase
    {
        private readonly IBugService _bugService;
        private readonly IRepository<Bug> _bugContext;

        public BugsController(IBugService bugService, IRepository<Bug> bugContext)
        {
            _bugService = bugService;
            _bugContext = bugContext;
        }

        //[HttpGet("{id}")]
        //public async Task<BugDto> Get(int id)
        //{
        //    var result = await _bugService.GetByIdAsync(id);
        //    return result;
        //}

        [HttpGet("{id}")]
        public async Task<Bug> Get(int id)
        {
            var result = await _bugContext.GetByIdAsync(id);
            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<Bug>> Get()
        {
            //var result = await _bugService.GetByIdAsync(id);
            var result = await _bugContext.GetAllAsync();
            return result;
        }
    }
}
