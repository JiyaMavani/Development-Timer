using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Interfaces
{
    public interface IExtensionsRequestRepository
    {
        Task<List<ExtensionsRequest>> GetAllAsync();
        Task<ExtensionsRequest> GetByIdAsync(int id);
        Task<List<ExtensionsRequest>> GetByTaskItemIdAsync(int taskItemId);
        Task<List<ExtensionsRequest>> GetByDeveloperIdAsync(int developerId);
        Task<List<ExtensionsRequest>> GetByExtraHoursAsync(int extraHours);
        Task<List<ExtensionsRequest>> GetByJustificationAsync(string justification);
        Task AddAsync(ExtensionsRequest extensionsRequest);
        Task UpdateAsync(ExtensionsRequest extensionsRequest);
        Task DeleteAsync(int id);
    }
}
