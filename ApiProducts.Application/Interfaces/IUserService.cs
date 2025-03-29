using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiProducts.Domain.Entities;

namespace ApiProducts.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByUsernameAsync(string username);
    }
}
