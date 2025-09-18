using DevelopmentTimer.API.DTOs.UserDTO;
using DevelopmentTimer.BAL.DTOs.ProjectDTO;
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
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository projectRepository;
        private readonly ITaskItemRepository taskItemRepository;

        public ProjectManager(IProjectRepository projectRepository,ITaskItemRepository taskItemRepository) 
        {
            this.projectRepository = projectRepository;
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<ProjectReadDto?> CreateProjectAsync(ProjectCreateDto projectCreateDto)
        {
            var existingproject = await projectRepository.GetByNameAsync(projectCreateDto.Name);
            if (existingproject == null)
            {
                var project = new Project
                {
                    Name = projectCreateDto.Name,
                    MaxHoursPerDay = projectCreateDto.MaxHoursPerDay,
                    Status = projectCreateDto.Status,
                };
                await projectRepository.AddAsync(project);
                return new ProjectReadDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    MaxHoursPerDay = project.MaxHoursPerDay,
                    Status = project.Status.ToString(),
                };
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            if (project == null)
                return false;
            var tasks = await taskItemRepository.GetByProjectIdAsync(id);
            if (tasks.Any())
                throw new InvalidOperationException($"Cannot delete Project with Id = {id} because it has assigned tasks.");

            await projectRepository.DeleteAsync(id);
            return true;

        }

        public async Task<List<ProjectReadDto>> GetAllProjectAsync()
        {
            var project = await projectRepository.GetAllAsync();
            return project.Select(project => new ProjectReadDto
            {
                Id = project.Id,
                Name = project.Name,
                MaxHoursPerDay = project.MaxHoursPerDay,
                Status = project.Status.ToString(),
            }).ToList();
        }

        public async Task<ProjectReadDto?> GetByProjectId(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            if (project == null) return null;
            else
            {
                return new ProjectReadDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    MaxHoursPerDay = project.MaxHoursPerDay,
                    Status = project.Status.ToString(),
                };
            };
        }

        public async Task<List<ProjectReadDto>> GetByProjectMaxHours(int maxHours)
        {
            var project = await projectRepository.GetByMaxHours(maxHours);
            return project.Select(project => new ProjectReadDto
            {
                Id = project.Id,
                Name = project.Name,
                MaxHoursPerDay = project.MaxHoursPerDay,
                Status = project.Status.ToString(),
            }).ToList();
        }

        public async Task<ProjectReadDto?> GetByProjectNameAsync(string name)
        {
            var project = await projectRepository.GetByNameAsync(name);
            if (project == null) return null;
            else
            {
                return new ProjectReadDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    MaxHoursPerDay = project.MaxHoursPerDay,
                    Status = project.Status.ToString(),
                };
            };
        }

        public async Task<List<ProjectReadDto>> GetByProjectStatus(Status status)
        {
            var projectStatus = await projectRepository.GetByStatus(status);
            return projectStatus.Select(project => new ProjectReadDto
            {
                    Id = project.Id,
                    Name = project.Name,
                    MaxHoursPerDay = project.MaxHoursPerDay,
                    Status = project.Status.ToString(),
            }).ToList();
        }

        public async Task<ProjectReadDto?> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto)
        {
            var existingproject = await projectRepository.GetByIdAsync(projectUpdateDto.Id);
            if (existingproject != null)
            {
                existingproject.Name = projectUpdateDto.Name;
                existingproject.MaxHoursPerDay = projectUpdateDto.MaxHoursPerDay;
                existingproject.Status = projectUpdateDto.Status;
                await projectRepository.UpdateAsync(existingproject);
                return new ProjectReadDto
                {
                    Id = existingproject.Id,
                    Name = existingproject.Name,
                    MaxHoursPerDay = existingproject.MaxHoursPerDay,
                    Status = existingproject.Status.ToString(),
                };
            }
            else
            {
                return null;
            }
        }
    }
}
