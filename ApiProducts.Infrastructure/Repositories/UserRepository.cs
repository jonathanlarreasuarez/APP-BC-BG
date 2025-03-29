using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Application.Interfaces;
using ApiProducts.Domain.Entities;
using ApiProducts.Domain.Interfaces;
using ApiProducts.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiProducts.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ApiDbContext _context;

        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
