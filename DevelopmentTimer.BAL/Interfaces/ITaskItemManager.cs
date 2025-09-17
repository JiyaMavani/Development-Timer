using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Interfaces
{
    public interface ITaskItemManager
    {
        Task<List<TaskItemReadDto>> GetAllTaskItemAsync();
        Task<TaskItemReadDto> GetByTaskItemId(int id);
        Task<List<TaskItemReadDto>> GetByTaskItemTitleAsync(string Title);
        Task<List<TaskItemReadDto>> GetByTaskItemDescriptionAsync(string Description);
        Task<List<TaskItemReadDto>> GetByTaskItemEstimatedHoursAsync(int EstimatedHours);
        Task<List<TaskItemReadDto>> GetByTaskItemStatusAsync(Status status);
        Task<List<TaskItemReadDto>> GetByTaskItemProjectIdAsync(int ProjectId);
        Task<List<TaskItemReadDto>> GetByTaskItemDeveloperIdAsync(int DeveloperId);
        Task<TaskItemReadDto> CreateTaskItemAsync(TaskItemCreateDto taskItemCreateDto);
        Task<TaskItemReadDto> UpdateTaskItemAsync(TaskItemUpdateDto taskItemUpdateDto);
        Task<bool> DeleteTaskItemAsync(int id);
    }
}
