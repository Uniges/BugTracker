using BugTracker.DAL.Context;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return await context.Bugs.ToListAsync();
        }

        public async Task<Bug> GetByIdAsync(int id)
        {
            return await context.Bugs.FirstOrDefaultAsync(e => e.Id == id);
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

        //public IEnumerable<Bug> All => context.Bugs.ToList();

        //public Bug Get(int id)
        //{
        //    return context.Bugs.FirstOrDefault(e => e.Id == id);
        //}

        //public async Task Add(Bug entity)
        //{
        //    await context.Bugs.AddAsync(entity);
        //    await context.SaveChangesAsync();
        //}

        //public async Task Update(Bug entity)
        //{
        //    context.Bugs.Update(entity);
        //    await context.SaveChangesAsync();
        //}

        //public void Delete(int id)
        //{
        //    var bug = context.Bugs.FirstOrDefault(e => e.Id == id);
        //    context.Bugs.Remove(bug);
        //    context.SaveChanges();
        //}

        //public async Task SaveAsync()
        //{
        //    await context.SaveChangesAsync();
        //}
    }
}
