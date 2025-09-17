using DevelopmentTimer.BAL.DTOs.ExtensionsRequestDTO;
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
    public class ExtensionsRequestManager : IExtensionsRequestManager
    {
        private readonly IExtensionsRequestRepository extensionsRequestRepository;

        public ExtensionsRequestManager(IExtensionsRequestRepository extensionsRequestRepository) 
        {
            this.extensionsRequestRepository = extensionsRequestRepository;
        }

        public async Task<ExtensionsRequestReadDto> CreateExtensionsRequestAsync(ExtensionsRequestCreateDto extensionsRequestCreateDto)
        {
            var existingextensionRequest = (await extensionsRequestRepository.GetAllAsync())
            .Any(t => t.TaskItemId == extensionsRequestCreateDto.TaskItemId && t.DeveloperId == extensionsRequestCreateDto.DeveloperId);
            if (existingextensionRequest == false)
            {
                var extensionsRequest = new ExtensionsRequest
                {
                    TaskItemId = extensionsRequestCreateDto.TaskItemId,
                    DeveloperId = extensionsRequestCreateDto.DeveloperId,
                    ExtraHours = extensionsRequestCreateDto.ExtraHours,
                    Justification = extensionsRequestCreateDto.Justification,
                    Status = extensionsRequestCreateDto.Status,
                    RequestDate = extensionsRequestCreateDto.RequestDate,
                };
                await extensionsRequestRepository.AddAsync(extensionsRequest);
                return new ExtensionsRequestReadDto
                {
                    Id = extensionsRequest.Id,
                    TaskItemId = extensionsRequest.TaskItemId,
                    DeveloperId = extensionsRequest.DeveloperId,
                    ExtraHours = extensionsRequest.ExtraHours,
                    Justification = extensionsRequest.Justification,
                    Status = extensionsRequest.Status,
                    RequestDate = extensionsRequest.RequestDate,
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteExtensionsRequestAsync(int id)
        {
            var extensionsRequest = await extensionsRequestRepository.GetByIdAsync(id);
            if (extensionsRequest != null)
            {
                await extensionsRequestRepository.DeleteAsync(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<ExtensionsRequestReadDto>> GetAllExtensionsRequestAsync()
        {
            var extensionRequest = await extensionsRequestRepository.GetAllAsync();
            return extensionRequest.Select(extensionsRequest => new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            }).ToList();
        }

        public async Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestDeveloperIdAsync(int developerId)
        {
            var extensionRequest = await extensionsRequestRepository.GetByDeveloperIdAsync(developerId);
            return extensionRequest.Select(extensionsRequest => new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            }).ToList();
        }

        public async Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestExtraHoursAsync(int extraHours)
        {
            var extensionRequest = await extensionsRequestRepository.GetByExtraHoursAsync(extraHours);
            return extensionRequest.Select(extensionsRequest => new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            }).ToList();
        }

        public async Task<ExtensionsRequestReadDto> GetByExtensionsRequestId(int id)
        {
            var extensionsRequest = await extensionsRequestRepository.GetByIdAsync(id);
            if (extensionsRequest == null) return null;
            return new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            };
        }

        public async Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestJustificationAsync(string justification)
        {
            var extensionRequest = await extensionsRequestRepository.GetByJustificationAsync(justification);
            return extensionRequest.Select(extensionsRequest => new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            }).ToList();
        }

        public async Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestRequestDateAsync(DateTime requestDate)
        {
            var extensionRequest = await extensionsRequestRepository.GetByRequestDateAsync(requestDate);
            return extensionRequest.Select(extensionsRequest => new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            }).ToList();
        }

        public async Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestStatusAsync(Status status)
        {
            var extensionRequest = await extensionsRequestRepository.GetByStatusAsync(status);
            return extensionRequest.Select(extensionsRequest => new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            }).ToList();
        }

        public async Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestTaskItemIdAsync(int taskItemId)
        {
            var extensionRequest = await extensionsRequestRepository.GetByTaskItemIdAsync(taskItemId);
            return extensionRequest.Select(extensionsRequest => new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
                Status = extensionsRequest.Status,
                RequestDate = extensionsRequest.RequestDate,
            }).ToList();
        }

        public async Task<ExtensionsRequestReadDto> UpdateExtensionsRequestAsync(ExtensionsRequestUpdateDto extensionsRequestUpdateDto)
        {
            var existingextensionrequest = await extensionsRequestRepository.GetByIdAsync(extensionsRequestUpdateDto.Id);
            if (existingextensionrequest != null)
            {
                existingextensionrequest.ExtraHours = extensionsRequestUpdateDto.ExtraHours;
                existingextensionrequest.Justification = extensionsRequestUpdateDto.Justification;
                existingextensionrequest.Status = extensionsRequestUpdateDto.Status;
                existingextensionrequest.RequestDate = extensionsRequestUpdateDto.RequestDate;
                
                await extensionsRequestRepository.UpdateAsync(existingextensionrequest);

                return new ExtensionsRequestReadDto
                {
                    Id = existingextensionrequest.Id,
                    TaskItemId = existingextensionrequest.TaskItemId,
                    DeveloperId = existingextensionrequest.DeveloperId,
                    ExtraHours = existingextensionrequest.ExtraHours,
                    Justification = existingextensionrequest.Justification,
                    Status = existingextensionrequest.Status,
                    RequestDate = existingextensionrequest.RequestDate,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
