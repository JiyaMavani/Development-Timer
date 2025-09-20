using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;

namespace DevelopmentTimer.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        [MinLength(3, ErrorMessage = " Username must be at least 3 characters")]
        [MaxLength(50,ErrorMessage = " Username cannot exceed 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^A-Za-z0-9]).{8,16}$",ErrorMessage = "Password must contain one uppercase , one lowercase , one digit , one special symbol and should be between 8 to 16 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public Role Role { get; set; }
        public string AssignedProjectIds { get; set; } = "0";
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public ICollection<ExtensionsRequest> ExtensionRequests { get; set; } = new List<ExtensionsRequest>();
    }
}
