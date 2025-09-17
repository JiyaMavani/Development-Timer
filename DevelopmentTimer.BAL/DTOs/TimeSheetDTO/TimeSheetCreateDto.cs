using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.TimeSheetDTO
{
    public class TimeSheetCreateDto
    {
        [Required(ErrorMessage = "Developer ID is required")]
        public int DeveloperId { get; set; }

        [Required(ErrorMessage = "TaskItem ID is required")]
        public int TaskItemId {  get; set; }

        [Required(ErrorMessage = "HoursWorked is required")]
        public decimal HoursWorked {  get; set; }
        public bool Submitted {  get; set; }
        public Status ApprovalStatus {  get; set; }
        public DateTime? SubmissionDate { get; set; }
    }
}
