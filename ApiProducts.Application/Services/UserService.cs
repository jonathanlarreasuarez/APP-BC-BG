using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Application.Interfaces;
using ApiProducts.Domain.Entities;
using ApiProducts.Domain.Interfaces;

namespace ApiProducts.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var user = await _userRepository.GetByUsernameAsync(username);
            if (user == null) {
                throw new InvalidOperationException("User not found.");

            }
            return user;
        }
    }
}
