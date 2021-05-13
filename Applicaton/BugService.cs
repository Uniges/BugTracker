using AutoMapper;
using BugTracker.DAL;
using BugTracker.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Applicaton
{
    public class BugService : IBugService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public BugService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BugDto> GetByIdAsync(int id)
        {
            //var bug = await _dbContext.Bugs
            //    .AsNoTracking()
            //    //.Include(x => x.History).ThenInclude(x => x.Date)
            //    .Include(x => x.User)
            //    .FirstOrDefaultAsync(x => x.Id == id);
            var bug = await _dbContext.Bugs
                .AsNoTracking()
                .Include(x => x.User).Include(x => x.History)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (bug == null) throw new BugNotFoundException();

            var dto = _mapper.Map<BugDto>(bug);
            dto.OwnerName = $"{bug.User.Name} {bug.User.LastName}";

            return dto;
        }
    }
}
