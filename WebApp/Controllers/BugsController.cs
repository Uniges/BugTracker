using BugTracker.Applicaton;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id}")]
        public async Task<BugDto> Get(int id)
        {
            var result = await _bugService.GetByIdAsync(id);
            return result;
        }
    }
}
