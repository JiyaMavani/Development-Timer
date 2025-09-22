using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.DTOs.UserDTO;
using DevelopmentTimer.DAL.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DevelopmentTimer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public LoginController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<UserLoginRequestDto>> Login([FromBody] UserLoginRequestDto userLoginRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _appDbContext.Users
                .FromSqlInterpolated($"EXEC sp_GetLoginCredientials @Username = {userLoginRequestDto.Username}, @Password = {userLoginRequestDto.Password}")
                .AsEnumerable()
                .Select(u => new UserLoginResponseDto
                {
                    Username = u.Username,
                    Role = u.Role.ToString()
                })
                .FirstOrDefault();

            if (user == null)
                return Unauthorized("Invalid Username or Password");

            return Ok(user);
        }
    }
}


