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
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly AppDbContext appDbContext;

        public TimeSheetRepository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddAsync(TimeSheet timeSheet)
        {
            await appDbContext.Timesheets.AddAsync(timeSheet);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existingtimesheet = await appDbContext.Timesheets.FindAsync(id);
            if (existingtimesheet != null)
            {
                appDbContext.Timesheets.Remove(existingtimesheet);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<TimeSheet>> GetAllAsync()
        {
            return await appDbContext.Timesheets.FromSqlInterpolated($"EXEC GetTimeSheet").ToListAsync();
        }

        public async Task<List<TimeSheet>> GetByApprovalStatusAsync(Status approvalStatus)
        {
            return await appDbContext.Timesheets.FromSqlInterpolated($"EXEC GetTimeSheet @ApprovalStatus = {approvalStatus}").ToListAsync();
        }

        public async Task<List<TimeSheet>> GetByDeveloperIdAsync(int developerId)
        {
            return await appDbContext.Timesheets.FromSqlInterpolated($"EXEC GetTimeSheet @DeveloperId = {developerId}").ToListAsync();
        }

        public async Task<List<TimeSheet>> GetByHoursWorkedAsync(decimal hoursWorked)
        {
            return await appDbContext.Timesheets.FromSqlInterpolated($"EXEC GetTimeSheet @HoursWorked = {hoursWorked}").ToListAsync();
        }

        public async Task<TimeSheet?> GetByIdAsync(int id)
        {
            return await appDbContext.Timesheets.FromSqlInterpolated($"EXEC GetTimeSheet @Id = {id}").FirstOrDefaultAsync();
        }

        public async Task<List<TimeSheet>> GetBySubmissionDateAsync(DateTime? submissionDate)
        {
            if (!submissionDate.HasValue)
                return new List<TimeSheet>();
            else 
            { 
                return await appDbContext.Timesheets.Where(s => s.SubmissionDate.HasValue && s.SubmissionDate.Value.Date == submissionDate.Value.Date).ToListAsync(); 
            }
        }

        public async Task<List<TimeSheet>> GetBySubmittedAsync(bool submitted)
        {
            return await appDbContext.Timesheets.Where(s => s.Submitted== submitted).ToListAsync();
        }

        public async Task<List<TimeSheet>> GetByTaskItemIdAsync(int taskItemId)
        {
            return await appDbContext.Timesheets.Where(s => s.TaskItemId == taskItemId).ToListAsync();
        }

        public async Task UpdateAsync(TimeSheet timeSheet)
        {
            appDbContext.Timesheets.Update(timeSheet);
            await appDbContext.SaveChangesAsync();
        }
    }
}
