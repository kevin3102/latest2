using Product_Managment_System.Models;
using Product_Managment_System.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product_Managment_System.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            var users= _userRepository.GetUsers();
            return users;
        }


        public User GetUser(string username)
        {
              var user= _userRepository.GetUser(username);
              return user;
        }

        public async Task<bool> UserRegistration(User userdetails)
        {
            var user = await _userRepository.UserRegistration(userdetails);
            if (user == null)
            {
                return  true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> UpdateUser(User user)
        {
            var userinfo = await _userRepository.UpdateUser(user);
            if (userinfo == null)
            {
                return "No records exist for username- " + user.Username;
            }
            else
            {
                return "Records updated successfully for "+user.Username;
            }
        }
        public async Task<string> UserLogin(Tuple<string,string> userdetails)
        {
           
            Tuple<string, string> logindetails = new Tuple<string, string>(userdetails.Item1, userdetails.Item2);

            var userinfo = await _userRepository.UserLogin(logindetails);
            if (userinfo != null)
            {
                return "Welcome - " + userinfo.Name;     // ("Welcome - " + userinfo.Name);
            }
            else
            {
                return "Invalid username or password";    //NotFound("Invalid username or password");
            }
        }


    }
}
