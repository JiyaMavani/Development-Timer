using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentTimer.API.DTOs.UserDTO;

namespace DevelopmentTimer.BAL.Interfaces
{
    public interface IUserManager
    {
        Task<List<UserReadDto>> GetAllUsersAsync();
        Task<UserReadDto> GetUserByIdAsync(int id);
        Task<UserReadDto> GetUserByNameAsync(string username);
        Task<UserReadDto> CreateUserAsync(UserCreateDto userCreateDto);
        Task<UserReadDto> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteUserAsync(int id);
    }
}
