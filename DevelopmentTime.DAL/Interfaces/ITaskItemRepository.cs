using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<List<TaskItem>> GetByTitleAsync(string Title);
        Task<List<TaskItem>> GetByDescriptionAsync(string Description);
        Task<List<TaskItem>> GetByEstimatedHoursAsync(int EstimatedHours);
        Task<List<TaskItem>> GetByTotalHoursAsync(int totalHours);
        Task<List<TaskItem>> GetByStatusAsync(Status status);
        Task<List<TaskItem>> GetByProjectIdAsync(int ProjectId);
        Task<List<TaskItem>> GetByDeveloperIdAsync(int DeveloperId);
        Task<List<TaskItem>> GetByisApprovedAsync(bool isApproved);
        Task<List<TaskItem>> GetByDateAsync(DateTime date);
        Task<List<TaskItem>> GetByNotificationThresholdMinutesAsync(TimeOnly threshold);

        Task<bool> AddAsync(TaskItem taskItem);
        Task<bool> UpdateAsync(TaskItem taskItem);
        Task<bool> UpdateCompletionAsync(int id, int totalHours);
        Task DeleteAsync(int id);
    }
}
