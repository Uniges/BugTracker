using BugTracker.DAL.Context;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.DAL.Repository
{
    public class BugRepository : IRepository<Bug>
    {
        private readonly AppDbContext context;

        public BugRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Bug>> GetAllAsync()
        {
            return await context.Bugs.AsNoTracking().ToListAsync();
        }

        public async Task<Bug> GetByIdAsync(int id)
        {
            return await context.Bugs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Bug entity)
        {
            await context.Bugs.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bug entity)
        {
            context.Bugs.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var bug = await context.Bugs.FirstOrDefaultAsync(e => e.Id == id);
            context.Bugs.Remove(bug);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<BugHistory>> GetBugHistoryAsync(int id)
        {
            var bug = await context.Bugs
                .AsNoTracking()
                .Include(x => x.History)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (bug == null) return null;
            return bug.History.OrderBy(x => x.Date).ToList();
        }
    }
}
