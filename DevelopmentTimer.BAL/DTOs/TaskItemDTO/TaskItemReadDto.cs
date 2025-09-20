namespace DevelopmentTimer.BAL.DTOs.TaskItemDTO
{
    public class TaskItemReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public int TotalHours { get; set; }   
        public string Status { get; set; }    
        public int ProjectId { get; set; }
        public int DeveloperId { get; set; }
        public bool isApproved { get; set; } 
        public DateOnly Date { get; set; }    
        public TimeOnly NotificationThresholdMinutes { get; set; } 
        public bool isReadOnly {  get; set; }
    }
}
