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
    public class ExtensionsRequestRepository : IExtensionsRequestRepository
    {
        private readonly AppDbContext appDbContext;

        public ExtensionsRequestRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddAsync(ExtensionsRequest extensionsRequest)
        {
            appDbContext.ExtensionRequests.Add(extensionsRequest);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var extensionrequest = await appDbContext.ExtensionRequests.FindAsync(id);
            if (extensionrequest != null)
            {
                appDbContext.ExtensionRequests.Remove(extensionrequest);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<ExtensionsRequest>> GetAllAsync()
        {
            return await appDbContext.ExtensionRequests.ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByDeveloperIdAsync(int developerId)
        {
            return await appDbContext.ExtensionRequests.Where(d => d.DeveloperId == developerId).ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByExtraHoursAsync(int extraHours)
        {
            return await appDbContext.ExtensionRequests.Where(h=>h.ExtraHours == extraHours).ToListAsync();
        }

        public async Task<ExtensionsRequest> GetByIdAsync(int id)
        {
            return await appDbContext.ExtensionRequests.FindAsync(id);

        }

        public async Task<List<ExtensionsRequest>> GetByJustificationAsync(string justification)
        {
            return await appDbContext.ExtensionRequests.Where(j => j.Justification == justification).ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByRequestDateAsync(DateTime requestDate)
        {
            var nextDay = requestDate.Date.AddDays(1);
            return await appDbContext.ExtensionRequests
                .Where(d => d.RequestDate >= requestDate.Date && d.RequestDate < nextDay).ToListAsync();

        }

        public async Task<List<ExtensionsRequest>> GetByStatusAsync(Status status)
        {
            return await appDbContext.ExtensionRequests.Where(s=>s.Status==status).ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByTaskItemIdAsync(int taskItemId)
        {
            return await appDbContext.ExtensionRequests.Where(t => t.TaskItemId==taskItemId).ToListAsync();
        }

        public async Task UpdateAsync(ExtensionsRequest extensionsRequest)
        {
            appDbContext.ExtensionRequests.Update(extensionsRequest);
            await appDbContext.SaveChangesAsync();
        }
    }
}
