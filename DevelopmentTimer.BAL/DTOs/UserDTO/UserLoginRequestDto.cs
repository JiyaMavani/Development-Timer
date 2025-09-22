using System.ComponentModel.DataAnnotations;

namespace DevelopmentTimer.BAL.DTOs.UserDTO
{
    public class UserLoginRequestDto
    {
        [Required(ErrorMessage = "UserName is required")]
        [MinLength(3, ErrorMessage = "UserName must be atleast 3 characters")]
        [MaxLength(50, ErrorMessage = "UserName must not exceed 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^A-Za-z0-9]).{8,16}$",
            ErrorMessage = "Password must contain uppercase, lowercase, digit, special char and be 8-16 chars long")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string Role {  get; set; }
    }
}
