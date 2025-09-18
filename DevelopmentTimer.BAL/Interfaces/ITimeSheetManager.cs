using DevelopmentTimer.BAL.DTOs.TimeSheetDTO;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Interfaces
{
    public interface ITimeSheetManager
    {
        Task<List<TimeSheetReadDto>> GetAllTimeSheetAsync();
        Task<TimeSheetReadDto?> GetByTimeSheetId(int id);
        Task<List<TimeSheetReadDto>> GetByTimeSheetDeveloperIdAsync(int developerId);
        Task<List<TimeSheetReadDto>> GetByTimeSheetTaskItemIdAsync(int taskItemId);
        Task<List<TimeSheetReadDto>> GetByTimeSheetHoursWorkedAsync(decimal hoursWorked);
        Task<List<TimeSheetReadDto>> GetByTimeSheetSubmittedAsync(bool submitted);
        Task<List<TimeSheetReadDto>> GetByTimeSheetApprovalStatusAsync(Status approvalStatus);
        Task<List<TimeSheetReadDto>> GetByTimeSheetSubmissionDateAsync(DateTime? submissionDate);
        Task<TimeSheetReadDto?> CreateTimeSheetAsync(TimeSheetCreateDto timeSheetCreateDto);
        Task<TimeSheetReadDto?> UpdateTimeSheetAsync(TimeSheetUpdateDto timeSheetUpdateDto);
        Task<bool> DeleteTimeSheetAsync(int id);
    }
}
