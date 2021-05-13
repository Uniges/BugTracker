using BugTracker.Applicaton.Models;
using BugTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Applicaton.Contracts
{
    public interface IBugService
    {
        public Task<IEnumerable<Bug>> GetAllAsync();
        public Task<Bug> GetByIdAsync(int id);
        public Task UpdateByUserAsync(BugUpdateRequest entity);
        //public Task AddAsync(Bug entity);
        public Task CreateByUserAsync(BugRequest bugRequest, int userId);
        public Task<IEnumerable<Bug>> GetAllSortedAsync(BugSortRequest entity);
        //public Task DeleteByIdAsync(int id);
    }
}
