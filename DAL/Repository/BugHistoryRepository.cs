using BugTracker.DAL.Context;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.DAL.Repository
{
    public class BugHistoryRepository : IRepository<BugHistory>
    {
        private readonly AppDbContext context;

        public BugHistoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<BugHistory>> GetAllAsync()
        {
            return await context.BugHistory.ToListAsync();
        }

        public async Task<BugHistory> GetByIdAsync(int id)
        {
            return await context.BugHistory.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(BugHistory entity)
        {
            await context.BugHistory.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BugHistory entity)
        {
            context.BugHistory.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var bugHistory = await context.BugHistory.FirstOrDefaultAsync(e => e.Id == id);
            context.BugHistory.Remove(bugHistory);
            await context.SaveChangesAsync();
        }
    }
}
