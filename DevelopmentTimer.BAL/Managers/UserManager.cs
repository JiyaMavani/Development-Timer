using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        private readonly ITaskItemRepository taskItemRepository;

        public UserManager(IUserRepository userRepository,ITaskItemRepository taskItemRepository)
        {
            this.userRepository = userRepository;
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<UserReadDto?> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var existingUser = await userRepository.GetByNameAsync(userCreateDto.Username);
            if (existingUser != null) return null;

            var user = new User
            {
                Username = userCreateDto.Username,
                Password = userCreateDto.Password,
                Role = userCreateDto.Role
            };

            await userRepository.AddAsync(user);

            return new UserReadDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString()
            };
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
                return false;
            var tasks = await taskItemRepository.GetByDeveloperIdAsync(id);
            if (tasks.Any())
                throw new InvalidOperationException($"Cannot delete User with Id = {id} because they have assigned tasks.");
            await userRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<UserReadDto>> GetAllUsersAsync()
        {
            var users = await userRepository.GetAllAsync();
            return users.Select(u => new UserReadDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = u.Role.ToString()
            }).ToList();
        }

        public async Task<UserReadDto?> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserReadDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString()
            };
        }

        public async Task<UserReadDto?> GetUserByNameAsync(string username)
        {
            var user = await userRepository.GetByNameAsync(username);
            if (user == null) return null;

            return new UserReadDto
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString()
            };
        }

        public async Task<List<UserReadDto>> GetUsersByRoleAsync(Role role)
        {
            var users = await userRepository.GetByRoleAsync(role);
            return users.Select(u => new UserReadDto
            {
                Id = u.Id,
                Username = u.Username,
                Role = u.Role.ToString()
            }).ToList();
        }

        public async Task<UserReadDto?> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var existing = await userRepository.GetByIdAsync(userUpdateDto.Id);
            if (existing == null) return null;

            existing.Username = userUpdateDto.Username;
            existing.Password = userUpdateDto.Password;
            existing.Role = userUpdateDto.Role;

            await userRepository.UpdateAsync(existing);

            return new UserReadDto
            {
                Id = existing.Id,
                Username = existing.Username,
                Role = existing.Role.ToString()
            };
        }
    }
}

