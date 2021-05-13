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
        public Task<UserResponse> AuthorizationAsync(UserRequest entity);
        public Task UpdateAsync(User entity);
        #region TEMP
        public Task<User> GetByIdAsync(int id);
        #endregion
    }
}
