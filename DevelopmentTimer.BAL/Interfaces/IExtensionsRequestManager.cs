using DevelopmentTimer.BAL.DTOs.ExtensionsRequestDTO;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Interfaces
{
    public interface IExtensionsRequestManager
    {
        Task<List<ExtensionsRequestReadDto>> GetAllExtensionsRequestAsync();
        Task<ExtensionsRequestReadDto?> GetByExtensionsRequestIdAsync(int id);
        Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestDeveloperIdAsync(int developerId);
        Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestTaskItemIdAsync(int taskItemId);
        Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestExtraHoursAsync(int extraHours);
        Task<List<ExtensionsRequestReadDto>> GetByExtensionsRequestJustificationAsync(string justification);
        Task<ExtensionsRequestReadDto?> CreateExtensionsRequestAsync(ExtensionsRequestCreateDto extensionsRequestCreateDto);
        Task<ExtensionsRequestReadDto?> UpdateExtensionsRequestAsync(ExtensionsRequestUpdateDto extensionsRequestUpdateDto);
        Task<bool> DeleteExtensionsRequestAsync(int id);
    }
}
