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

        public async Task AddAsync(TaskItem taskItem)
        {
            var existingtaskitem = await appDbContext.TaskItems.FirstOrDefaultAsync(t => t.ProjectId == taskItem.ProjectId && t.Title.ToLower() == taskItem.Title.ToLower() && t.DeveloperId == taskItem.DeveloperId);
            if (existingtaskitem == null)
            {
                await appDbContext.TaskItems.AddAsync(taskItem);
                await appDbContext.SaveChangesAsync();
            }
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
            return await appDbContext.TaskItems.ToListAsync();
        }

        public async Task<List<TaskItem>> GetByDescriptionAsync(string Description)
        {
            return await appDbContext.TaskItems.Where(p => p.Description.ToLower() == Description.ToLower()).ToListAsync();
        }

        public async Task<List<TaskItem>> GetByDeveloperIdAsync(int DeveloperId)
        {
           return await appDbContext.TaskItems.Where(p => p.DeveloperId ==  DeveloperId).ToListAsync();
        }

        public async Task<List<TaskItem>> GetByEstimatedHoursAsync(int EstimatedHours)
        {
            return await appDbContext.TaskItems.Where(p => p.EstimatedHours == EstimatedHours).ToListAsync();
        }

        public async Task<TaskItem> GetByIdAsync(int id)
        {
            return await appDbContext.TaskItems.FindAsync(id);
        }

        public async Task<List<TaskItem>> GetByProjectIdAsync(int ProjectId)
        {
            return await appDbContext.TaskItems.Where(p => p.ProjectId == ProjectId).ToListAsync();
        }

        public async Task<List<TaskItem>> GetByStatusAsync(Status status)
        {
            return await appDbContext.TaskItems.Where(p => p.Status == status).ToListAsync();
        }

        public async Task<List<TaskItem>> GetByTitleAsync(string Title)
        {
            return await appDbContext.TaskItems.Where(p => p.Title.ToLower() == Title.ToLower()).ToListAsync();
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            appDbContext.TaskItems.Update(taskItem);
            await appDbContext.SaveChangesAsync();
        }
    }
}
