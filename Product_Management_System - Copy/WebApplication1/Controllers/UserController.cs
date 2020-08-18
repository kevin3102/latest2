using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product_Managment_System.Data;
using Product_Managment_System.Models;
using Product_Managment_System.Repository;
using Product_Managment_System.Service;

namespace Product_Managment_System.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        // GET: api/Users
        //all user details
        [HttpGet]
        public Task<IEnumerable<User>> GetUsers()
        {
            return _userservice.GetUsers();
        }

        //get user details by username
        [HttpGet("{Username}",Name = "GetUser")]
        public IActionResult GetUser(string username)
        {
            var user = _userservice.GetUser(username);
            if(user!=null)
           return Ok (user);

            else { return NotFound("No records for found for username: "+username); }
        }
       
        // POST api/Users
        //user registration
        [HttpPost("register")]
        public async Task<IActionResult> UserRegistration([FromBody] User userdetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var user = await _userservice.UserRegistration(userdetails);
                if (user == true)
                {
                    return Created("User registration successful", userdetails);
                }
                else
                {
                    return BadRequest("Username already exists");
                }
            }
        }

        //user authentication
        [HttpGet("login", Name ="UserLogin")]
        public async Task<IActionResult> UserLogin([FromBody] UserAuthentication userdetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Tuple<string, string> logindetails = new Tuple<string, string>(userdetails.Username, userdetails.Password);
            
            var userinfo = await _userservice.UserLogin(logindetails);
            
            return Ok(userinfo);
            
        }

        //update user details by username
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userinfo =  await _userservice.UpdateUser(user);

                return Ok(userinfo);
        }

    }
}
