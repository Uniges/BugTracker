using BugTracker.Applicaton.Models;
using BugTracker.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.Applicaton.Contracts
{
    public interface IBugService
    {
        public Task<IEnumerable<Bug>> GetAllAsync();
        public Task<Bug> GetByIdAsync(int id);
        public Task UpdateByUserAsync(BugUpdateRequest entity);
        public Task CreateByUserAsync(BugInputRequest bugRequest, int userId);
        public Task<IEnumerable<Bug>> GetAllSortedAsync(BugSortRequest entity);
        public Task<ICollection<BugHistory>> GetBugHistoryAsync(int id);
    }
}
