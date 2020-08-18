using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Managment_System.Data;
using Product_Managment_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http.ModelBinding;

namespace Product_Managment_System.Repository
{
    public class UserRepository : IUserRepository
    {
        private SqlDbContext usersDbContext;
        public UserRepository(SqlDbContext usersDbContext)
        {
            this.usersDbContext = usersDbContext;
        }
        public User GetUser(string username)
        {
                User user =   usersDbContext.Users.Find(username);
                var result = user == null ? null : user;
               // if(result==null)
                // { throw new Exception("username not found"); }
                return result;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await usersDbContext.Users.ToListAsync();
        }

        public async Task<User> UpdateUser(User userchanges)
        {
            var userinfo = await usersDbContext.Users.FindAsync(userchanges.Username);
            if (userinfo != null)
            {
                userinfo.Name = userchanges.Name;
                userinfo.Password = userchanges.Password;
                userinfo.EmailAddress = userchanges.EmailAddress;
                userinfo.SalesOfficeName = userchanges.SalesOfficeName;
                 _=usersDbContext.SaveChangesAsync(true);
                return userchanges;
            }
            else
            {
                return userinfo;
            }
        }

        public async Task<User> UserLogin(Tuple<string, string> user)
        {
            var userinfo = await usersDbContext.Users.FindAsync(user.Item1);
            if (userinfo != null)
            {
                if (userinfo.Password.Equals(user.Item2))
                {
                    return userinfo;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return userinfo;
            }
        }

        public async Task<User> UserRegistration(User user)
        {
            var userinfo = usersDbContext.Users.FindAsync(user.Username);
            if (userinfo.Result == null)
            {
                _=await usersDbContext.Users.AddAsync(user);
                await usersDbContext.SaveChangesAsync(true);
                return null;
            }
            else
            {
                return user;
            }
        }
    }
}
