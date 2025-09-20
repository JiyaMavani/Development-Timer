using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Managers
{
    public class TaskItemManager : ITaskItemManager
    {
        private readonly ITaskItemRepository taskItemRepository;

        public TaskItemManager(ITaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<TaskItemReadDto?> CreateTaskItemAsync(TaskItemCreateDto taskItemCreateDto)
        {
            var existingTaskItem = await taskItemRepository.GetByTitleAsync(taskItemCreateDto.Title);
            bool exists = existingTaskItem.Any(t => t.ProjectId == taskItemCreateDto.ProjectId && t.DeveloperId == taskItemCreateDto.DeveloperId);
            if (exists)
                throw new InvalidOperationException($"Task {taskItemCreateDto.Title} is already assigned for this developer in this project");

            var taskItem = new TaskItem
            {
                Title = taskItemCreateDto.Title,
                Description = taskItemCreateDto.Description,
                EstimatedHours = taskItemCreateDto.EstimatedHours,
                Status = taskItemCreateDto.Status,
                ProjectId = taskItemCreateDto.ProjectId,
                DeveloperId = taskItemCreateDto.DeveloperId,
                isReadonly = true,      
                isApproved = false      
            };

            await taskItemRepository.AddAsync(taskItem);
            return new TaskItemReadDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                EstimatedHours = taskItem.EstimatedHours,
                Status = taskItem.Status.ToString(),
                ProjectId = taskItem.ProjectId,
                DeveloperId = taskItem.DeveloperId,
                isReadOnly = taskItem.isReadonly
            };
        }

        public async Task<bool> DeleteTaskItemAsync(int id)
        {
            var taskItem = await taskItemRepository.GetByIdAsync(id);
            if (taskItem == null)
                return false;
            if (!taskItem.isApproved)
            {
                throw new InvalidOperationException($"TaskItem with Id = {id} cannot be deleted because it is not approved");
            }
            await taskItemRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<TaskItemReadDto>> GetAllTaskItemAsync()
        {
            var taskitems = await taskItemRepository.GetAllAsync();
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<TaskItemReadDto?> GetByTaskItemId(int id)
        {
            var taskitem = await taskItemRepository.GetByIdAsync(id);
            if (taskitem == null) return null;

            return new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            };
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemTitleAsync(string Title)
        {
            var taskitems = await taskItemRepository.GetByTitleAsync(Title);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemDescriptionAsync(string Description)
        {
            var taskitems = await taskItemRepository.GetByDescriptionAsync(Description);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemEstimatedHoursAsync(int EstimatedHours)
        {
            var taskitems = await taskItemRepository.GetByEstimatedHoursAsync(EstimatedHours);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemTotalHoursAsync(int TotalHours)
        {
            var taskitems = await taskItemRepository.GetByTotalHoursAsync(TotalHours);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemStatusAsync(Status status)
        {
            var taskitems = await taskItemRepository.GetByStatusAsync(status);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemProjectIdAsync(int ProjectId)
        {
            var taskitems = await taskItemRepository.GetByProjectIdAsync(ProjectId);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemDeveloperIdAsync(int DeveloperId)
        {
            var taskitems = await taskItemRepository.GetByDeveloperIdAsync(DeveloperId);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemisApprovedAsync(bool isApproved)
        {
            var taskitems = await taskItemRepository.GetByisApprovedAsync(isApproved);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemDateAsync(DateOnly date)
        {
            var taskitems = await taskItemRepository.GetByDateAsync(date);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemNotificationThresholdMinutesAsync(TimeOnly threshold)
        {
            var taskitems = await taskItemRepository.GetByNotificationThresholdMinutesAsync(threshold);
            return taskitems.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                TotalHours = taskitem.TotalHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
                isApproved = taskitem.isApproved,
                Date = taskitem.Date,
                NotificationThresholdMinutes = taskitem.NotificationThresholdMinutes
            }).ToList();
        }
    }
}
