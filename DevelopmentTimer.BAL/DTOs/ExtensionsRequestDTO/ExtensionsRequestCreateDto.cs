using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.DTOs.ExtensionsRequestDTO
{
    public class ExtensionsRequestCreateDto
    {
        [Required(ErrorMessage = "TaskItemId is required")]
        public int TaskItemId { get; set; }

        [Required(ErrorMessage = "DeveloperId is required")]
        public int DeveloperId { get; set; }

        [Required(ErrorMessage = "Extra hours are required")]
        [Range(1, 24, ErrorMessage = "Extra hours must be between 1 and 24")]
        public int ExtraHours { get; set; }

        [Required(ErrorMessage = "Justification is required")]
        [MinLength(10, ErrorMessage = "Justification must be at least 10 characters")]
        [MaxLength(250, ErrorMessage = "Justification cannot exceed 250 characters")]
        public string Justification { get; set; }

        [Required]
        public Status Status { get; set; }
        [Required]
        public DateTime RequestDate { get; set; }
    }
}
