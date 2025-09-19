using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using DevelopmentTimer.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var existingtaskitem = await taskItemRepository.GetByTitleAsync(taskItemCreateDto.Title);
            bool existingtask = existingtaskitem.Any(t => t.ProjectId == taskItemCreateDto.ProjectId && t.DeveloperId == taskItemCreateDto.DeveloperId);
            if (existingtask)
            {
                throw new InvalidOperationException($"Tasks with {taskItemCreateDto.Title} is already assigned to Developer Id = {taskItemCreateDto.DeveloperId} under Project Id = {taskItemCreateDto.ProjectId}");
            }
            var taskitem = new TaskItem
            {
                Title = taskItemCreateDto.Title,
                Description = taskItemCreateDto.Description,
                EstimatedHours = taskItemCreateDto.EstimatedHours,
                Status = taskItemCreateDto.Status,
                ProjectId = taskItemCreateDto.ProjectId,
                DeveloperId = taskItemCreateDto.DeveloperId,
            };
            await taskItemRepository.AddAsync(taskitem);
            return new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            };
        }

        public async Task<bool> DeleteTaskItemAsync(int id)
        {
            var taskitem = await taskItemRepository.GetByIdAsync(id);
            if (taskitem == null)
                return false;
            if (taskitem.ProjectId != null && taskitem.DeveloperId != null && taskitem.Status != Status.Completed && taskitem.Status != Status.Approved)
            { 
                throw new InvalidOperationException($"TaskItem with Id = {id} can not be deleted because it is assigned to a Project with Id = {taskitem.ProjectId} and Developer with Id = {taskitem.DeveloperId} and is not Completed and Approved."); 
            }

            await taskItemRepository.DeleteAsync(taskitem.Id);
            return true;
        }

        public async Task<List<TaskItemReadDto>> GetAllTaskItemAsync()
        {
            var taskitem = await taskItemRepository.GetAllAsync();
            return taskitem.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemDescriptionAsync(string Description)
        {
            var taskitem = await taskItemRepository.GetByDescriptionAsync(Description);
            return taskitem.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            }).ToList();
        }


        public async Task<List<TaskItemReadDto>> GetByTaskItemDeveloperIdAsync(int DeveloperId)
        {
            var taskitem = await taskItemRepository.GetByDeveloperIdAsync(DeveloperId);
            return taskitem.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemEstimatedHoursAsync(int EstimatedHours)
        {
            var taskitem = await taskItemRepository.GetByEstimatedHoursAsync(EstimatedHours);
            return taskitem.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            }).ToList();
        }

        public async Task<TaskItemReadDto?> GetByTaskItemId(int id)
        {
            var taskitem = await taskItemRepository.GetByIdAsync(id);
            if (taskitem == null) return null;
            else
            {
                return new TaskItemReadDto
                {
                    Id = taskitem.Id,
                    Title = taskitem.Title,
                    Description = taskitem.Description,
                    EstimatedHours = taskitem.EstimatedHours,
                    Status = taskitem.Status.ToString(),
                    ProjectId = taskitem.ProjectId,
                    DeveloperId = taskitem.DeveloperId,
                };
            }
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemProjectIdAsync(int ProjectId)
        {
            var taskitem = await taskItemRepository.GetByProjectIdAsync(ProjectId);
            return taskitem.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemStatusAsync(Status status)
        {
            var taskitem = await taskItemRepository.GetByStatusAsync(status);
            return taskitem.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            }).ToList();
        }

        public async Task<List<TaskItemReadDto>> GetByTaskItemTitleAsync(string Title)
        {
            var taskitem = await taskItemRepository.GetByTitleAsync(Title);
            return taskitem.Select(taskitem => new TaskItemReadDto
            {
                Id = taskitem.Id,
                Title = taskitem.Title,
                Description = taskitem.Description,
                EstimatedHours = taskitem.EstimatedHours,
                Status = taskitem.Status.ToString(),
                ProjectId = taskitem.ProjectId,
                DeveloperId = taskitem.DeveloperId,
            }).ToList();
        }

        public async Task<TaskItemReadDto?> UpdateTaskItemAsync(TaskItemUpdateDto taskItemUpdateDto)
        {
            var existingtaskitem = await taskItemRepository.GetByIdAsync(taskItemUpdateDto.Id);
            if (existingtaskitem != null)
            {
                existingtaskitem.Title = taskItemUpdateDto.Title;
                existingtaskitem.Description = taskItemUpdateDto.Description;
                existingtaskitem.Status = taskItemUpdateDto.Status;
                existingtaskitem.EstimatedHours = taskItemUpdateDto.EstimatedHours;
                existingtaskitem.ProjectId = taskItemUpdateDto.ProjectId;
                existingtaskitem.DeveloperId = taskItemUpdateDto.DeveloperId;
                await taskItemRepository.UpdateAsync(existingtaskitem);

                return new TaskItemReadDto
                {
                    Id = existingtaskitem.Id,
                    Title = existingtaskitem.Title,
                    Description = existingtaskitem.Description,
                    EstimatedHours = existingtaskitem.EstimatedHours,
                    Status = existingtaskitem.Status.ToString(),
                    ProjectId = existingtaskitem.ProjectId,
                    DeveloperId = existingtaskitem.DeveloperId,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
