using DevelopmentTimer.BAL.DTOs.ProjectDTO;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentTimer.BAL.Managers
{
    public class ProjectManager : IProjectManager
    {
        private readonly IProjectRepository projectRepository;
        private readonly ITaskItemRepository taskItemRepository;

        public ProjectManager(IProjectRepository projectRepository, ITaskItemRepository taskItemRepository)
        {
            this.projectRepository = projectRepository;
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<ProjectReadDto?> CreateProjectAsync(ProjectCreateDto projectCreateDto)
        {
            var existingProject = await projectRepository.GetByNameAsync(projectCreateDto.Name);
            if (existingProject != null && existingProject.Any()) return null;

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
                Status = project.Status.ToString()
            };
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            if (project == null) return false;

            var tasks = await taskItemRepository.GetByProjectIdAsync(id);
            if (tasks != null && tasks.Any())
                throw new InvalidOperationException($"Cannot delete Project with Id = {id} because it has assigned tasks.");

            await projectRepository.DeleteAsync(id);
            return true;
        }

        public async Task<List<ProjectReadDto>> GetAllProjectAsync()
        {
            var projects = await projectRepository.GetAllAsync();
            return projects.Select(p => new ProjectReadDto
            {
                Id = p.Id,
                Name = p.Name,
                MaxHoursPerDay = p.MaxHoursPerDay,
                Status = p.Status.ToString()
            }).ToList();
        }

        public async Task<ProjectReadDto?> GetByProjectIdAsync(int id)
        {
            var project = await projectRepository.GetByIdAsync(id);
            if (project == null) return null;

            return new ProjectReadDto
            {
                Id = project.Id,
                Name = project.Name,
                MaxHoursPerDay = project.MaxHoursPerDay,
                Status = project.Status.ToString()
            };
        }

        public async Task<List<ProjectReadDto>> GetByProjectNameAsync(string name)
        {
            var projects = await projectRepository.GetByNameAsync(name);
            return projects.Select(p => new ProjectReadDto
            {
                Id = p.Id,
                Name = p.Name,
                MaxHoursPerDay = p.MaxHoursPerDay,
                Status = p.Status.ToString()
            }).ToList();
        }

        public async Task<List<ProjectReadDto>> GetByProjectMaxHoursAsync(int maxHours)
        {
            var projects = await projectRepository.GetByMaxHours(maxHours);
            return projects.Select(p => new ProjectReadDto
            {
                Id = p.Id,
                Name = p.Name,
                MaxHoursPerDay = p.MaxHoursPerDay,
                Status = p.Status.ToString()
            }).ToList();
        }

        public async Task<List<ProjectReadDto>> GetByProjectStatusAsync(Status status)
        {
            var projects = await projectRepository.GetByStatus(status);
            return projects.Select(p => new ProjectReadDto
            {
                Id = p.Id,
                Name = p.Name,
                MaxHoursPerDay = p.MaxHoursPerDay,
                Status = p.Status.ToString()
            }).ToList();
        }

        public async Task<ProjectReadDto?> UpdateProjectAsync(ProjectUpdateDto projectUpdateDto)
        {
            var existingProject = await projectRepository.GetByIdAsync(projectUpdateDto.Id);
            if (existingProject == null) return null;

            existingProject.Name = projectUpdateDto.Name;
            existingProject.MaxHoursPerDay = projectUpdateDto.MaxHoursPerDay;
            existingProject.Status = projectUpdateDto.Status;

            await projectRepository.UpdateAsync(existingProject);

            return new ProjectReadDto
            {
                Id = existingProject.Id,
                Name = existingProject.Name,
                MaxHoursPerDay = existingProject.MaxHoursPerDay,
                Status = existingProject.Status.ToString()
            };
        }

        public async Task<List<ProjectReadDto>> GetProjectsForDeveloperAsync(int developerId)
        {
            var projects = await projectRepository.GetProjectsForDeveloperAsync(developerId);

            return projects.Select(p => new ProjectReadDto
            {
                Id = p.Id,
                Name = p.Name,
                MaxHoursPerDay = p.MaxHoursPerDay,
                Status = p.Status.ToString()
            }).ToList();
        }
    }
}
