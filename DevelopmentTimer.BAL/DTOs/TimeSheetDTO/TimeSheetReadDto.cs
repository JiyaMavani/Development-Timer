using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.TimeSheetDTO
{
    public class TimeSheetReadDto
    {
        public int Id { get; set; }
        public int DeveloperId { get; set; }
        public int TaskItemId {  get; set; }
        public decimal HoursWorked {  get; set; }
        public bool Submitted { get; set; }
        public Status ApprovalStatus { get; set; }
        public DateTime? SubmissionDate { get; set; }
    }
}
