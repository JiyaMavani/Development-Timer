using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<UserReadDto> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var existinguser = await userRepository.GetByNameAsync(userCreateDto.Username);
            if (existinguser == null)
            {
                var user = new User
                {
                    Username = userCreateDto.Username,
                    Password = userCreateDto.Password,
                    Role = userCreateDto.Role,
                };
                await userRepository.AddAsync(user);
                return new UserReadDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role.ToString()
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user != null)
            {
                await userRepository.DeleteAsync(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<UserReadDto>> GetAllUsersAsync()
        {
            var user = await userRepository.GetAllAsync();
            return user.Select(user => new UserReadDto { 
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString()
            }).ToList();
        }

        public async Task<UserReadDto> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetByIdAsync(id);
            if (user == null) return null;
            else
            {
                return new UserReadDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role.ToString()
                };
            };
        }

        public async Task<UserReadDto> GetUserByNameAsync(string username)
        {
            var user = await userRepository.GetByNameAsync(username);
            if (user == null) return null;
            else
            {
                return new UserReadDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role.ToString()
                };
            };
        }

        public async Task<UserReadDto> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var existinguser = await userRepository.GetByIdAsync(userUpdateDto.Id);
            if (existinguser != null)
            {
                existinguser.Username = userUpdateDto.Username;
                existinguser.Password = userUpdateDto.Password;
                existinguser.Role = userUpdateDto.Role;
                await userRepository.UpdateAsync(existinguser);
                return new UserReadDto
                {
                    Id = existinguser.Id,
                    Username = existinguser.Username,
                    Role = existinguser.Role.ToString()
                };
            }
            else
            {
                return null;
            }
        }
    }
}
