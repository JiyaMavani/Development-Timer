using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            if (user == null) return NotFound($"User with Id = {id} cannot be found");
            return Ok(user);
        }

        [HttpGet("name/{username}")]
        public async Task<ActionResult<List<UserReadDto>>> GetUserByName(string username)
        {
            var users = await userManager.GetUserByNameAsync(username);
            if (users == null || users.Count == 0)
                return NotFound($"User with username = {username} cannot be found");
            return Ok(users);
        }

        [HttpGet("role/{role}")]
        public async Task<ActionResult<List<UserReadDto>>> GetUsersByRole(Role role)
        {
            var users = await userManager.GetUsersByRoleAsync(role);
            if (users == null || users.Count == 0)
                return NotFound($"No users found with role = {role}");
            return Ok(users);
        }

        [HttpGet("project/{projectId}")]
        public async Task<ActionResult<List<UserReadDto>>> GetUsersByAssignedProject(int projectId)
        {
            var users = await userManager.GetUsersByAssignedProjectAsync(projectId);
            if (users == null || users.Count == 0)
                return NotFound($"No users assigned to project with Id = {projectId}");
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");

            var user = await userManager.CreateUserAsync(userCreateDto);
            if (user == null)
                return BadRequest("User with the same username already exists");

            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserReadDto>> UpdateUser(int id, [FromBody] UserUpdateDto userUpdateDto)
        {
            if (id != userUpdateDto.Id)
                return BadRequest("Id mismatch");

            var user = await userManager.UpdateUserAsync(userUpdateDto);
            if (user == null)
                return BadRequest($"Update not possible. User with Id = {id} does not exist");

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await userManager.DeleteUserAsync(id);
                if (!result)
                    return NotFound($"Deletion not possible. User with Id = {id} does not exist");

                return Ok($"User with Id = {id} deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
