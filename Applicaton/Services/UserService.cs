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

        public async Task<UserResponse> AuthorizationAsync(UserRequest entity)
        {
            var users = await _userRepository.GetAllAsync();
            var currentUser = users.FirstOrDefault(e => e.Login == entity.Login && e.Password == entity.Password);

            UserResponse userResponse = new UserResponse() { IsSuccess = false };

            if (currentUser == null) return userResponse;

            userResponse.IsSuccess = true;
            userResponse.Token = "token";

            return userResponse;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
