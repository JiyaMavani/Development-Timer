using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DevelopmentTimer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserReadDto>>> GetAllUsers()
        {
            var users = await userManager.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int id)
        {
            var user = await userManager.GetUserByIdAsync(id);
            if (user == null) return NotFound($"User with Id = {id} can not be found");
            return Ok(user);
        }

        [HttpGet("name/{username}")]
        public async Task<ActionResult<List<UserReadDto>>> GetUserByName(string username)
        {
            var user = await userManager.GetUserByNameAsync(username);
            if (user == null) return NotFound($"User with username = {username} can not be found");
            return Ok(user);
        }

        [HttpGet("role/{role}")]
        public async Task<ActionResult<List<UserReadDto>>> GetUsersByRole(Role role)
        {
            var users = await userManager.GetUsersByRoleAsync(role);
            if (users == null) return NotFound($"User with role = {role} can not be found");
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            var user = await userManager.CreateUserAsync(userCreateDto);
            if (user == null)
                return BadRequest("User with the same username already exists");
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserReadDto>> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (id != userUpdateDto.Id) 
                return BadRequest("Id mismatch.");
            var user = await userManager.UpdateUserAsync(userUpdateDto);
            if (user == null)
                return BadRequest($"Update not possible.User with Id = {id} does not exist");
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await userManager.DeleteUserAsync(id);
                if (!result)
                    return NotFound($"Deletion not possible. User with Id = {id} does not exist.");

                return Ok($"User with Id = {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
