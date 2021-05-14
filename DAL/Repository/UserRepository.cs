using BugTracker.DAL.Context;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext context;

        public UserRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await context.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await context.Users.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(User entity)
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id);
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }
    }
}
