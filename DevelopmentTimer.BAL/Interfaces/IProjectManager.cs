using DevelopmentTimer.BAL.DTOs.ProjectDTO;
using DevelopmentTimer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Interfaces
{
    public interface IProjectManager
    {
        Task<List<ProjectReadDto>> GetAllProjectAsync();
        Task<ProjectReadDto> GetByProjectId(int id);
        Task<ProjectReadDto> GetByProjectNameAsync(string name);
        Task<List<ProjectReadDto>> GetByProjectMaxHours(int maxHours);
        Task<ProjectReadDto> CreateProjectAsync(ProjectCreateDto projectCreateDto);
        Task<ProjectReadDto> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto);
        Task<bool> DeleteProjectAsync(int id);
    }
}
