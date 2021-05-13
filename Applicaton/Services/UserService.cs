using AutoMapper;
using BugTracker.Applicaton.Contracts;
using BugTracker.Applicaton.Models;
using BugTracker.DAL.Repository;
using BugTracker.DAL.Repository.Common;
using BugTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Configuration;
using BugTracker.Applicaton.Exceptions;

namespace BugTracker.Applicaton.Services
{
    public class UserService : IUserService
    {
        private readonly /*UserRepository*/IRepository<User> _userRepository;
        //private readonly IMapper _mapper;

        public UserService(/*IRepository<User>*/IRepository<User> userRepository/*, IMapper mapper*/)
        {
            _userRepository = userRepository;
            //_mapper = mapper;
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
