using DevelopmentTimer.DAL.Data;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext appDbContext;
        public ProjectRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddAsync(Project project)
        {
            var existingProject = await appDbContext.Projects.FirstOrDefaultAsync(p => p.Name.ToLower() == project.Name.ToLower());
            if (existingProject == null)
            {
                await appDbContext.Projects.AddAsync(project);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var project = await appDbContext.Projects.FindAsync(id);
            if (project != null)
            {
                appDbContext.Projects.Remove(project);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await appDbContext.Projects.FromSqlRaw("EXEC sp_GetAllProjects").ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            var project = await appDbContext.Projects
                .FromSqlInterpolated($"EXEC sp_GetProjectById @Id={id}")
                .ToListAsync();

            return project.FirstOrDefault();
        }

        public async Task<List<Project?>> GetByNameAsync(string name)
        {
            return await appDbContext.Projects
            .FromSqlInterpolated($"EXEC sp_GetProjectByName @Name={name}").ToListAsync();
        }

        public async Task<List<Project>> GetByMaxHours(int maxHours)
        {
            return await appDbContext.Projects.FromSqlInterpolated($"EXEC sp_GetProjectsByMaxHours @MaxHoursPerDay={maxHours}").ToListAsync();
        }
        public async Task<List<Project>> GetByStatus(Status status)
        {
            return await appDbContext.Projects.FromSqlInterpolated($"EXEC sp_GetProjectsByStatus @Status={(int)status}").ToListAsync();

        }

        public async Task UpdateAsync(Project project)
        {
            appDbContext.Projects.Update(project);
            await appDbContext.SaveChangesAsync();
        }
    }
}
