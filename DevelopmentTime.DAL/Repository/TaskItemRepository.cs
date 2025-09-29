using DevelopmentTimer.DAL.Data;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Repository
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext appDbContext;

        public TaskItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<bool> AddAsync(TaskItem taskItem)
        {
            if (taskItem.TotalHours == default)
            {
                taskItem.TotalHours = TimeSpan.FromHours(taskItem.EstimatedHours);
            }

            var exists = await appDbContext.TaskItems
                .AnyAsync(t => t.ProjectId == taskItem.ProjectId
                            && t.Title.ToLower() == taskItem.Title.ToLower()
                            && t.DeveloperId == taskItem.DeveloperId);

            if (exists) return false;

            await appDbContext.TaskItems.AddAsync(taskItem);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await appDbContext.TaskItems.FindAsync(id);
            if (existing != null)
            {
                appDbContext.TaskItems.Remove(existing);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetAllTaskItems")
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            var list = await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemById @Id={id}")
                .ToListAsync();

            return list.FirstOrDefault();
        }

        public async Task<List<TaskItem>> GetByTitleAsync(string title)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByTitle @Title={title}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByDescriptionAsync(string description)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByDescription @Description={description}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByEstimatedHoursAsync(int estimatedHours)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByEstimatedHours @EstimatedHours={estimatedHours}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByTotalHoursAsync(TimeSpan totalHours)
        {
            string totalHoursString = totalHours.ToString(@"hh\:mm\:ss");
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByTotalHours @TotalHours={totalHoursString}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByStatusAsync(Status status)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByStatus @Status={status.ToString()}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByProjectIdAsync(int projectId)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByProjectId @ProjectId={projectId}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByDeveloperIdAsync(int developerId)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByDeveloperId @DeveloperId={developerId}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByisApprovedAsync(bool isApproved)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByisApprovedStatus @isApproved={isApproved}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByDateAsync(DateTime date)
        {
            string dateParam = date.ToString("yyyy-MM-dd");
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByDate @Date={dateParam}")
                .ToListAsync();
        }

        public async Task<List<TaskItem>> GetByNotificationThresholdMinutesAsync(TimeSpan threshold)
        {
            return await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemsByNotificationThresholdMinutes @NotificationThresholdMinutes={threshold}")
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(TaskItem taskItem)
        {
            var existing = await appDbContext.TaskItems.FindAsync(taskItem.Id);
            if (existing == null) return false;

            existing.Title = taskItem.Title;
            existing.Description = taskItem.Description;
            existing.EstimatedHours = taskItem.EstimatedHours;
            existing.TotalHours = taskItem.TotalHours;
            existing.Status = taskItem.Status;
            existing.isApproved = taskItem.isApproved;
            existing.Date = taskItem.Date;
            existing.NotificationThresholdMinutes = taskItem.NotificationThresholdMinutes;

            appDbContext.TaskItems.Update(existing);
            var saved = await appDbContext.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> UpdateCompletionAsync(int id, TimeSpan totalHours)
        {
            var existing = await appDbContext.TaskItems.FindAsync(id);
            if (existing == null) return false;

            existing.TotalHours = totalHours;
            existing.Status = Status.Completed;

            appDbContext.TaskItems.Update(existing);
            var saved = await appDbContext.SaveChangesAsync();
            return saved > 0;
        }
    }
}