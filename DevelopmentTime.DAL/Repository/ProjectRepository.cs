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
                await appDbContext.AddAsync(project);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var existingProject = await appDbContext.Projects.FindAsync(id);
            if (existingProject != null)
            {
                appDbContext.Projects.Remove(existingProject);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await appDbContext.Projects.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await appDbContext.Projects.FindAsync(id);
        }

        public Task<Project> GetByNameAsync(string name)
        {
            return appDbContext.Projects.FirstOrDefaultAsync(p => p.Name.ToLower() == name.ToLower());
        }

        public async Task<List<Project>> GetByMaxHours(int maxHours)
        {
            return await appDbContext.Projects
                            .Where(p => p.MaxHoursPerDay == maxHours)
                            .ToListAsync();
        }
        public async Task<List<Project>> GetByStatus(Status status)
        {
            return await appDbContext.Projects
                            .Where(p => p.Status == status)
                            .ToListAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            appDbContext.Projects.Update(project);
            await appDbContext.SaveChangesAsync();
        }
    }
}
