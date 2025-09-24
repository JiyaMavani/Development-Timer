using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(int id);
        Task<List<Project>> GetByNameAsync(string name);
        Task<List<Project>> GetByMaxHours(int maxHours);
        Task<List<Project>> GetByStatus(Status status);
        Task<List<Project>> GetProjectsForDeveloperAsync(int developerId);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
    }
}
