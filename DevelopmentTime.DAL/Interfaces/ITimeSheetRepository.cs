using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Interfaces
{
    public interface ITimeSheetRepository
    {
        Task<List<TimeSheet>> GetAllAsync();
        Task<TimeSheet?> GetByIdAsync(int id);
        Task<List<TimeSheet>> GetByDeveloperIdAsync(int developerId);
        Task<List<TimeSheet>> GetByTaskItemIdAsync(int taskItemId);
        Task<List<TimeSheet>> GetByHoursWorkedAsync(decimal hoursWorked);
        Task<List<TimeSheet>> GetBySubmittedAsync(bool submitted);
        Task<List<TimeSheet>> GetByApprovalStatusAsync(Status approvalStatus);
        Task<List<TimeSheet>> GetBySubmissionDateAsync(DateTime? submissionDate);
        Task AddAsync(TimeSheet timeSheet);
        Task UpdateAsync(TimeSheet timeSheet);
        Task DeleteAsync(int id);
    }
}
