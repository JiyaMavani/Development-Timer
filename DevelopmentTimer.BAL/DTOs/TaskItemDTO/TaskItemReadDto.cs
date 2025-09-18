using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.TaskItemDTO
{
    public class TaskItemReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public string Status {  get; set; }
        public int ProjectId {  get; set; }
        public int DeveloperId { get; set; }
    }
}
