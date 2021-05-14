using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using System.Threading.Tasks;
using System.Linq;
using BugTracker.Applicaton.Exceptions;

namespace BugTracker.Applicaton.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> AuthorizationAsync(UserRequest entity)
        {
            var users = await _userRepository.GetAllAsync();
            var currentUser = users.FirstOrDefault(e => e.Login == entity.Login && e.Password == entity.Password);
            if (currentUser == null) throw new UserAuthException();
            return currentUser;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new UserNotFoundException();
            return user;
        }

        private async Task UpdateAsync(User entity)
        {
            await _userRepository.UpdateAsync(entity);
        }

        public async Task UpdateByUserAsync(UserUpdateRequest entity)
        {
            var user = await GetByIdAsync(entity.UserId);
            user.Name = entity.Name;
            user.LastName = entity.LastName;
            await UpdateAsync(user);
        }
    }
}
