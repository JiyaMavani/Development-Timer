using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.TaskItemDTO
{
    public class TaskItemCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MinLength(3,ErrorMessage = "Title must be atleast 3 characters")]
        [MaxLength(50,ErrorMessage = "Title must not exceed 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(20, ErrorMessage = "Description must be atleast 20 characters")]
        [MaxLength(200, ErrorMessage = "Description must not exceed 200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Estimated Hours is required")]
        [Range(1,24,ErrorMessage = "Estimated Hours must be between 1 and 24")]
        public int EstimatedHours { get; set; }

        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Project ID is required")]
        public int ProjectId {  get; set; }

        [Required(ErrorMessage = "Developer ID is required")]
        public int DeveloperId {  get; set; }
    }
}
