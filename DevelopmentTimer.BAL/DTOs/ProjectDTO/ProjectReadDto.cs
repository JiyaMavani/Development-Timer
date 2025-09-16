using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.ProjectDTO
{
    public class ProjectReadDto
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxHoursPerDay { get; set; }
        public Status Status { get; set; }
    }
}
