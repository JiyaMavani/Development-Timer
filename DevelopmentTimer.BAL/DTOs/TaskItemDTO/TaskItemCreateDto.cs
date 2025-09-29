using DevelopmentTimer.DAL.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace DevelopmentTimer.BAL.DTOs.TaskItemDTO
{
    public class TaskItemCreateDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Estimated Hours is required")]
        public int EstimatedHours { get; set; }
        public TimeSpan? TotalHours { get; set; } 

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
        public TimeSpan NotificationThresholdMinutes { get; set; }
        public bool isReadonly { get; set; } = true;
    }
}