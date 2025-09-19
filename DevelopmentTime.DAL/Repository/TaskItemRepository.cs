using DevelopmentTimer.DAL.Data;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var existingtaskitem = await appDbContext.TaskItems.AnyAsync(t => t.ProjectId == taskItem.ProjectId && t.Title.ToLower() == taskItem.Title.ToLower() && t.DeveloperId == taskItem.DeveloperId);
            if (existingtaskitem)
            {
                return false;
            }
            await appDbContext.TaskItems.AddAsync(taskItem);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var existingtaskitem = await appDbContext.TaskItems.FindAsync(id);
            if(existingtaskitem != null)
            {
                appDbContext.TaskItems.Remove(existingtaskitem);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await appDbContext.TaskItems.FromSqlInterpolated($"EXEC sp_GetAllTaskItems").ToListAsync();
        }

        public Task<List<TaskItem>> GetByDateAsync(DateOnly date)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskItem>> GetByDescriptionAsync(string Description)
        {
            return await appDbContext.TaskItems.FromSqlInterpolated($"EXEC sp_GetTaskItemsByDescription @Description = {Description}").ToListAsync();
        }

        public async Task<List<TaskItem>> GetByDeveloperIdAsync(int DeveloperId)
        {
            return await appDbContext.TaskItems
            .FromSqlInterpolated($"EXEC sp_GetTaskItemsByDeveloperId @DeveloperId={DeveloperId}").ToListAsync();
        }

        public async Task<List<TaskItem>> GetByEstimatedHoursAsync(int EstimatedHours)
        {
            return await appDbContext.TaskItems.FromSqlInterpolated($"EXEC sp_GetTaskItemsByEstimatedHours @EstimatedHours = {EstimatedHours}").ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            var taskItems = await appDbContext.TaskItems
                .FromSqlInterpolated($"EXEC sp_GetTaskItemById @Id={id}")
                .ToListAsync();

            return taskItems.FirstOrDefault();
        }

        public async Task<List<TaskItem>> GetByProjectIdAsync(int ProjectId)
        {
            return await appDbContext.TaskItems
            .FromSqlInterpolated($"EXEC sp_GetTaskItemsByProjectId @ProjectId = {ProjectId}").ToListAsync();
        }

        public async Task<List<TaskItem>> GetByStatusAsync(Status status)
        {
            return await appDbContext.TaskItems.FromSqlInterpolated($"EXEC sp_GetTaskItemsByStatus @Status = {status}").ToListAsync();
        }

        public Task<List<TaskItem>> GetByStatusAsync(bool isApproved)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TaskItem>> GetByTitleAsync(string Title)
        {
            return await appDbContext.TaskItems.FromSqlInterpolated($"EXEC sp_GetTaskItemsByTitle @Title = {Title}").ToListAsync();
        }

        public Task<List<TaskItem>> GetByTotalHours(int totalHours)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            appDbContext.TaskItems.Update(taskItem);
            await appDbContext.SaveChangesAsync();
        }
    }
}
