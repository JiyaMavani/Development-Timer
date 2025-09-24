using DevelopmentTimer.BAL.DTOs.ProjectDTO;
using DevelopmentTimer.DAL.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Interfaces
{
    public interface IProjectManager
    {
        Task<List<ProjectReadDto>> GetAllProjectAsync();
        Task<ProjectReadDto?> GetByProjectIdAsync(int id);
        Task<List<ProjectReadDto>> GetByProjectNameAsync(string name);
        Task<List<ProjectReadDto>> GetByProjectMaxHoursAsync(int maxHours);
        Task<List<ProjectReadDto>> GetByProjectStatusAsync(Status status);
        Task<List<ProjectReadDto>> GetProjectsForDeveloperAsync(int developerId);

        Task<ProjectReadDto?> CreateProjectAsync(ProjectCreateDto projectCreateDto);
        Task<ProjectReadDto?> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto);
        Task<bool> DeleteProjectAsync(int id);
    }
}
