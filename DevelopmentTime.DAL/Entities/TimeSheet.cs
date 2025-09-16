using DevelopmentTimer.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Entities
{
    public class TimeSheet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Developer is required")]
        public int DeveloperId { get; set; }
        public User Developer { get; set; }

        [Required(ErrorMessage = "Task is required")]
        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }

        [Required(ErrorMessage = "Hours worked is required")]
        [Range(0, 24, ErrorMessage = "Hours worked must be between 0 and 24")]
        [Precision(4, 2)]
        public decimal HoursWorked { get; set; }

        public bool Submitted { get; set; } = false;

        [Required]
        public Status ApprovalStatus { get; set; }

        public DateTime? SubmissionDate { get; set; }
    }
}
