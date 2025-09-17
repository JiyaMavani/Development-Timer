using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Interfaces
{
    public interface ITaskItemRepository
    { 
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem> GetByIdAsync(int id);
        Task<List<TaskItem>> GetByTitleAsync(string Title);
        Task<List<TaskItem>> GetByDescriptionAsync(string Description);
        Task<List<TaskItem>> GetByEstimatedHoursAsync(int EstimatedHours);
        Task<List<TaskItem>> GetByStatusAsync(Status status);
        Task<List<TaskItem>> GetByProjectIdAsync(int ProjectId);
        Task<List<TaskItem>> GetByDeveloperIdAsync(int DeveloperId);
        Task AddAsync(TaskItem taskItem);
        Task UpdateAsync(TaskItem taskItem);
        Task DeleteAsync(int id);
    }
}
