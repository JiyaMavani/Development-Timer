using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.UserDTO
{
    public class UserLoginResponseDto
    {
        public int Id {  get; set; }
        public string Username {  get; set; }
        public string Role { get; set; }
    }
}
