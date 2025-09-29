using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Interfaces
{
    public interface ITaskItemManager
    {
        Task<List<TaskItemReadDto>> GetAllTaskItemAsync();
        Task<TaskItemReadDto?> GetByTaskItemId(int id);
        Task<List<TaskItemReadDto>> GetByTaskItemTitleAsync(string Title);
        Task<List<TaskItemReadDto>> GetByTaskItemDescriptionAsync(string Description);
        Task<List<TaskItemReadDto>> GetByTaskItemEstimatedHoursAsync(int EstimatedHours);
        Task<List<TaskItemReadDto>> GetByTaskItemTotalHoursAsync(TimeSpan TotalHours);
        Task<List<TaskItemReadDto>> GetByTaskItemStatusAsync(Status status);
        Task<List<TaskItemReadDto>> GetByTaskItemProjectIdAsync(int ProjectId);
        Task<List<TaskItemReadDto>> GetByTaskItemDeveloperIdAsync(int DeveloperId);
        Task<List<TaskItemReadDto>> GetByTaskItemisApprovedAsync(bool isApproved);
        Task<List<TaskItemReadDto>> GetByTaskItemDateAsync(DateTime date);
        Task<List<TaskItemReadDto>> GetByTaskItemNotificationThresholdMinutesAsync(TimeSpan threshold);

        Task<TaskItemReadDto?> CreateTaskItemAsync(TaskItemCreateDto taskItemCreateDto);
        Task<bool> UpdateTaskItemAsync(TaskItemReadDto taskItemReadDto);
        Task<bool> CompleteTaskItemAsync(int id, TimeSpan actualHours);
        Task<bool> DeleteTaskItemAsync(int id);
    }
}