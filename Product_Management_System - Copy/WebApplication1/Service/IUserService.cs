using Product_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        User GetUser(string username);
        Task<bool> UserRegistration(User user);
        Task<string> UserLogin(Tuple<string, string> user);
        Task<string> UpdateUser(User user);
    }
}
