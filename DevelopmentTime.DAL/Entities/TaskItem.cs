using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevelopmentTimer.DAL.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        //[MinLength(3, ErrorMessage = "Title must be at least 3 characters")]
        //[MaxLength(20, ErrorMessage = "Title cannot exceed 20 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        //[MinLength(50, ErrorMessage = " Description must be at least 50 characters")]
        //[MaxLength(200, ErrorMessage = " Description cannot exceed 200 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter the hours")]
        public int EstimatedHours { get; set; }
        public int TotalHours {  get; set; }

        [Required(ErrorMessage = "Please enter the task status")]
        public Status Status { get; set; }

        [Required(ErrorMessage = "Project is required")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Required(ErrorMessage = "Developer is required")]
        public int DeveloperId { get; set; }
        public User Developer { get; set; }
        [Required(ErrorMessage = "isApproved field is required")]
        public bool isApproved { get; set; }
        [Required(ErrorMessage = "Date field is required")]
        public DateTime? Date {  get; set; }
        [Required(ErrorMessage = "Notification Threshold field is required")]
        public TimeOnly NotificationThresholdMinutes { get; set; }
        public bool isReadonly { get; set; } = true;
        public ICollection<ExtensionsRequest> ExtensionRequests { get; set; } = new List<ExtensionsRequest>();
    }
}
