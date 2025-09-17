using DevelopmentTimer.BAL.DTOs.TaskItemDTO;
using DevelopmentTimer.BAL.DTOs.TimeSheetDTO;
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
    public class TimeSheetManager : ITimeSheetManager
    {
        private readonly ITimeSheetRepository timeSheetRepository;

        public TimeSheetManager(ITimeSheetRepository timeSheetRepository)
        {
            this.timeSheetRepository = timeSheetRepository;
        }

        public async Task<TimeSheetReadDto> CreateTimeSheetAsync(TimeSheetCreateDto timeSheetCreateDto)
        {
            var existingtimesheet = (await timeSheetRepository.GetAllAsync())
            .Any(t => t.TaskItemId == timeSheetCreateDto.TaskItemId && t.DeveloperId == timeSheetCreateDto.DeveloperId);
            if (existingtimesheet == false)
            {
                var timesheet = new TimeSheet
                {  
                    DeveloperId = timeSheetCreateDto.DeveloperId,
                    TaskItemId = timeSheetCreateDto.TaskItemId,
                    HoursWorked = timeSheetCreateDto.HoursWorked,
                    Submitted = timeSheetCreateDto.Submitted,
                    ApprovalStatus = timeSheetCreateDto.ApprovalStatus,
                    SubmissionDate = timeSheetCreateDto.SubmissionDate,
                };
                await timeSheetRepository.AddAsync(timesheet);
                return new TimeSheetReadDto
                {
                    Id = timesheet.Id,
                    DeveloperId = timesheet.DeveloperId,
                    TaskItemId = timesheet.TaskItemId,
                    HoursWorked = timesheet.HoursWorked,
                    Submitted = timesheet.Submitted,
                    ApprovalStatus = timesheet.ApprovalStatus,
                    SubmissionDate = timesheet.SubmissionDate,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteTimeSheetAsync(int id)
        {
            var timesheet = await timeSheetRepository.GetByIdAsync(id);
            if (timesheet != null)
            {
                await timeSheetRepository.DeleteAsync(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<TimeSheetReadDto>> GetAllTimeSheetAsync()
        {
            var timesheet = await timeSheetRepository.GetAllAsync();
            return timesheet.Select(timesheet => new TimeSheetReadDto
            {
                Id = timesheet.Id,
                DeveloperId = timesheet.DeveloperId,
                TaskItemId = timesheet.TaskItemId,
                HoursWorked = timesheet.HoursWorked,
                Submitted = timesheet.Submitted,
                ApprovalStatus = timesheet.ApprovalStatus,
                SubmissionDate = timesheet.SubmissionDate,
            }).ToList();
        }

        public async Task<List<TimeSheetReadDto>> GetByTimeSheetSubmissionDateAsync(DateTime? submissionDate)
        {
            var timesheet = await timeSheetRepository.GetBySubmissionDateAsync(submissionDate);
            return timesheet.Select(timesheet => new TimeSheetReadDto
            {
                Id = timesheet.Id,
                DeveloperId = timesheet.DeveloperId,
                TaskItemId = timesheet.TaskItemId,
                HoursWorked = timesheet.HoursWorked,
                Submitted = timesheet.Submitted,
                ApprovalStatus = timesheet.ApprovalStatus,
                SubmissionDate = timesheet.SubmissionDate,
            }).ToList();
        }

        public async Task<List<TimeSheetReadDto>> GetByTimeSheetApprovalStatusAsync(Status approvalStatus)
        {
            var timesheet = await timeSheetRepository.GetByApprovalStatusAsync(approvalStatus);
            return timesheet.Select(timesheet => new TimeSheetReadDto
            {
                Id = timesheet.Id,
                DeveloperId = timesheet.DeveloperId,
                TaskItemId = timesheet.TaskItemId,
                HoursWorked = timesheet.HoursWorked,
                Submitted = timesheet.Submitted,
                ApprovalStatus = timesheet.ApprovalStatus,
                SubmissionDate = timesheet.SubmissionDate,
            }).ToList();
        }

        public async Task<List<TimeSheetReadDto>> GetByTimeSheetHoursWorkedAsync(decimal hoursWorked)
        {
            var timesheet = await timeSheetRepository.GetByHoursWorkedAsync(hoursWorked);
            return timesheet.Select(timesheet => new TimeSheetReadDto
            {
                Id = timesheet.Id,
                DeveloperId = timesheet.DeveloperId,
                TaskItemId = timesheet.TaskItemId,
                HoursWorked = timesheet.HoursWorked,
                Submitted = timesheet.Submitted,
                ApprovalStatus = timesheet.ApprovalStatus,
                SubmissionDate = timesheet.SubmissionDate,
            }).ToList();
        }

        public async Task<List<TimeSheetReadDto>> GetByTimeSheetSubmittedAsync(bool submitted)
        {
            var timesheet = await timeSheetRepository.GetBySubmittedAsync(submitted);
            return timesheet.Select(timesheet => new TimeSheetReadDto
            {
                Id = timesheet.Id,
                DeveloperId = timesheet.DeveloperId,
                TaskItemId = timesheet.TaskItemId,
                HoursWorked = timesheet.HoursWorked,
                Submitted = timesheet.Submitted,
                ApprovalStatus = timesheet.ApprovalStatus,
                SubmissionDate = timesheet.SubmissionDate,
            }).ToList();
        }

        public async Task<List<TimeSheetReadDto>> GetByTimeSheetDeveloperIdAsync(int developerId)
        {
            var timesheet = await timeSheetRepository.GetByDeveloperIdAsync(developerId);
            return timesheet.Select(timesheet => new TimeSheetReadDto
            {
                Id = timesheet.Id,
                DeveloperId = timesheet.DeveloperId,
                TaskItemId = timesheet.TaskItemId,
                HoursWorked = timesheet.HoursWorked,
                Submitted = timesheet.Submitted,
                ApprovalStatus = timesheet.ApprovalStatus,
                SubmissionDate = timesheet.SubmissionDate,
            }).ToList();
        }

        public async Task<TimeSheetReadDto> GetByTimeSheetId(int id)
        {
            var timesheet = await timeSheetRepository.GetByIdAsync(id);
            if (timesheet == null) return null;
            else
            {
                return new TimeSheetReadDto
                {
                    Id = timesheet.Id,
                    DeveloperId = timesheet.DeveloperId,
                    TaskItemId = timesheet.TaskItemId,
                    HoursWorked = timesheet.HoursWorked,
                    Submitted = timesheet.Submitted,
                    ApprovalStatus = timesheet.ApprovalStatus,
                    SubmissionDate = timesheet.SubmissionDate,
                };
            }
        }

        public async Task<List<TimeSheetReadDto>> GetByTimeSheetTaskItemIdAsync(int taskItemId)
        {
            var timesheet = await timeSheetRepository.GetByTaskItemIdAsync(taskItemId);
            return timesheet.Select(timesheet => new TimeSheetReadDto
            {
                Id = timesheet.Id,
                DeveloperId = timesheet.DeveloperId,
                TaskItemId = timesheet.TaskItemId,
                HoursWorked = timesheet.HoursWorked,
                Submitted = timesheet.Submitted,
                ApprovalStatus = timesheet.ApprovalStatus,
                SubmissionDate = timesheet.SubmissionDate,
            }).ToList();
        }

        public async Task<TimeSheetReadDto> UpdateTimeSheetAsync(TimeSheetUpdateDto timeSheetUpdateDto)
        {
            var existingtimesheet = await timeSheetRepository.GetByIdAsync(timeSheetUpdateDto.Id);
            if (existingtimesheet != null)
            {
                existingtimesheet.DeveloperId = timeSheetUpdateDto.DeveloperId;
                existingtimesheet.TaskItemId = timeSheetUpdateDto.TaskItemId;
                existingtimesheet.HoursWorked = timeSheetUpdateDto.HoursWorked;
                existingtimesheet.Submitted = timeSheetUpdateDto.Submitted;
                existingtimesheet.ApprovalStatus = timeSheetUpdateDto.ApprovalStatus;
                existingtimesheet.SubmissionDate = timeSheetUpdateDto.SubmissionDate;
                await timeSheetRepository.UpdateAsync(existingtimesheet);

                return new TimeSheetReadDto
                {
                    Id = existingtimesheet.Id,
                    DeveloperId = existingtimesheet.DeveloperId,
                    TaskItemId = existingtimesheet.TaskItemId,
                    HoursWorked = existingtimesheet.HoursWorked,
                    Submitted = existingtimesheet.Submitted,
                    ApprovalStatus = existingtimesheet.ApprovalStatus,
                    SubmissionDate = existingtimesheet.SubmissionDate,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
