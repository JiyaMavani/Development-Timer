using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.ExtensionsRequestDTO
{
    public class ExtensionsRequestReadDto
    {
        public int Id {  get; set; }
        public int TaskItemId {  get; set; }
        public int DeveloperId {  get; set; }
        public int ExtraHours {  get; set; }
        public string Justification {  get; set; }
        public Status Status { get; set; }
        public DateTime RequestDate {  get; set; }
    }
}
