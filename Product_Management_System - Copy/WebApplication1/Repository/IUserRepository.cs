using Microsoft.AspNetCore.Mvc;
using Product_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        User GetUser(string username);
        Task<User> UserRegistration(User user);
        Task<User> UserLogin(Tuple<string, string> user);
        Task<User> UpdateUser(User user);
    }
}
