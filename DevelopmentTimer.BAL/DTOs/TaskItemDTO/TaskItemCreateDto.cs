using DevelopmentTimer.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevelopmentTimer.BAL.DTOs.TaskItemDTO
{
    public class TaskItemCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        //[MinLength(3, ErrorMessage = "Title must be atleast 3 characters")]
        //[MaxLength(50, ErrorMessage = "Title must not exceed 50 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        //[MinLength(10, ErrorMessage = "Description must be atleast 10 characters")]
        //[MaxLength(200, ErrorMessage = "Description must not exceed 200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Estimated Hours is required")]
        //[Range(1, 24, ErrorMessage = "Estimated Hours must be between 1 and 24")]
        public int EstimatedHours { get; set; }
        public int TotalHours {  get; set; }

        [Required(ErrorMessage = "Status is required")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Project ID is required")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Developer ID is required")]
        public int DeveloperId { get; set; }

        [Required(ErrorMessage = "isApproved field is required")]
        public bool isApproved { get; set; }

        [Required(ErrorMessage = "Date field is required")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Notification Threshold field is required")]
        public TimeOnly NotificationThresholdMinutes { get; set; }
        public bool isReadonly { get; set; } = true;
    }
}
