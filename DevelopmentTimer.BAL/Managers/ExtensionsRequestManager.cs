using DevelopmentTimer.BAL.DTOs.ExtensionsRequestDTO;
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

        public async Task<ExtensionsRequestReadDto?> CreateExtensionsRequestAsync(ExtensionsRequestCreateDto extensionsRequestCreateDto)
        {
            var existingExtensionRequest = await extensionsRequestRepository
            .GetByDeveloperIdAsync(extensionsRequestCreateDto.DeveloperId);

            if (existingExtensionRequest.Any(t => t.TaskItemId == extensionsRequestCreateDto.TaskItemId))
            {
                throw new InvalidOperationException(
                    $"Developer with Id = {extensionsRequestCreateDto.DeveloperId} already submitted an Extension Request for TaskItem Id = {extensionsRequestCreateDto.TaskItemId}");
            }
            var extensionsRequest = new ExtensionsRequest
            {
                TaskItemId = extensionsRequestCreateDto.TaskItemId,
                DeveloperId = extensionsRequestCreateDto.DeveloperId,
                ExtraHours = extensionsRequestCreateDto.ExtraHours,
                Justification = extensionsRequestCreateDto.Justification,
            };
            await extensionsRequestRepository.AddAsync(extensionsRequest);
            return new ExtensionsRequestReadDto
            {
                Id = extensionsRequest.Id,
                TaskItemId = extensionsRequest.TaskItemId,
                DeveloperId = extensionsRequest.DeveloperId,
                ExtraHours = extensionsRequest.ExtraHours,
                Justification = extensionsRequest.Justification,
            };
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
            }).ToList();
        }

        public async Task<ExtensionsRequestReadDto?> GetByExtensionsRequestIdAsync(int id)
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
            }).ToList();
        }

        public async Task<ExtensionsRequestReadDto?> UpdateExtensionsRequestAsync(ExtensionsRequestUpdateDto extensionsRequestUpdateDto)
        {
            var existingextensionrequest = await extensionsRequestRepository.GetByIdAsync(extensionsRequestUpdateDto.Id);
            if (existingextensionrequest != null)
            {
                existingextensionrequest.ExtraHours = extensionsRequestUpdateDto.ExtraHours;
                existingextensionrequest.Justification = extensionsRequestUpdateDto.Justification;

                await extensionsRequestRepository.UpdateAsync(existingextensionrequest);

                return new ExtensionsRequestReadDto
                {
                    Id = existingextensionrequest.Id,
                    TaskItemId = existingextensionrequest.TaskItemId,
                    DeveloperId = existingextensionrequest.DeveloperId,
                    ExtraHours = existingextensionrequest.ExtraHours,
                    Justification = existingextensionrequest.Justification,
                };
            }
            else
            {
                return null;
            }
        }
    }
}
