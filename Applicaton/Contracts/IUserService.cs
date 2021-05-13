using BugTracker.Applicaton.Models;
using BugTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Applicaton.Contracts
{
    public interface IUserService
    {
        public Task<User> AuthorizationAsync(UserRequest entity);
        public Task<User> GetByIdAsync(int id);
        public Task UpdateByUserAsync(UserUpdateRequest entity);
    }
}
