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
        public int ExtraHours { get; set; }
        public string Justification {  get; set; }
        public string Status {  get; set; }
        public DateTime RequestDate { get; set; }
    }
}
