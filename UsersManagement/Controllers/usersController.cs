using System;
using Bogus;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UsersManagement.Fake;
using UsersManagement.Models;


namespace UsersManagement.Controllers
{
    [Route ("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase

    {
        private List<User> _users = FakeData.GetUsers(100);
       

        /// <summary>
        /// Get users
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_users);
        }

        /// <summary>
        /// Get users by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetUserbyId(int id)
        {

            var user = _users.FirstOrDefault(x => x.Id == id);

            if(user!=null)
            {
                return Ok(user);
            }

            return NotFound();
        }


        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>

        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateUser([FromBody] User user)
        {
            
                _users.Add(user);
                return CreatedAtAction("Get", new { id = user.Id }, user);
            
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>


        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateUser([FromBody] User user)
        {
            var editUser = _users.FirstOrDefault(x => x.Id == user.Id);
            if (editUser!=null)
            {
                editUser.Firstname = user.Firstname;
                editUser.Lastname = user.Lastname;
                editUser.PhoneNumber = user.PhoneNumber;
                editUser.Email = user.Email;
                return Ok();
            }

            return NotFound();
        }

        /// <summary>
        /// Delete user by ID
        /// </summary>
        /// <param name="id"></param>


        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteUserbyId(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            if (deletedUser!=null)
            {
                _users.Remove(deletedUser);
                return Ok();
            }

            return NotFound();


        }

        /// <summary>
        /// Delete user by Firstname
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("[action]/{name}")]
        public IActionResult DeleteUserbyName(string name)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Firstname == name);
            if (deletedUser != null)
            {
                _users.Remove(deletedUser);
                return Ok();
            }

            return NotFound();


        }
    }
}
