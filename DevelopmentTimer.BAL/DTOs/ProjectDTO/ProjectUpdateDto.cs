using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.ProjectDTO
{
    public class ProjectUpdateDto
    {
        [Required(ErrorMessage = "Project ID is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Project Name is required")]
        [MinLength(3, ErrorMessage = "Project Name must be atleast 3 characters")]
        [MaxLength(50, ErrorMessage = "Project Name must not exceed 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "MaxHoursPerDay is required")]
        [Range(1, 24, ErrorMessage = "MaxHoursPerDay must be between 1 and 24")]
        public int MaxHoursPerDay { get; set; }
        [Required(ErrorMessage = "Project Status is required")]
        public Status Status { get; set; }
    }
}
