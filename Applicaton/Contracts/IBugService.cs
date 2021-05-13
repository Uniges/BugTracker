using BugTracker.Applicaton.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Applicaton.Contracts
{
    public interface IBugService<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task UpdateAsync(T entity);
        public Task AddAsync(T entity);
        public Task<IEnumerable<T>> GetAllSortedAsync(BugSortRequest entity);
        //public Task DeleteByIdAsync(int id);
    }
}
