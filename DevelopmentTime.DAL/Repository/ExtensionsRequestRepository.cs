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
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC GetExtensionsRequest").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByDeveloperIdAsync(int developerId)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC GetExtensionsRequest @DeveloperId = {developerId}").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByExtraHoursAsync(int extraHours)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC GetExtensionsRequest @ExtraHours = {extraHours}").ToListAsync();
        }

        public async Task<ExtensionsRequest?> GetByIdAsync(int id)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC GetExtensionsRequest @Id = {id}").FirstOrDefaultAsync(); 
        }

        public async Task<List<ExtensionsRequest>> GetByJustificationAsync(string justification)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC GetExtensionsRequest @Justification = {justification}").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByRequestDateAsync(DateTime requestDate)
        {
            var dateOnly = requestDate.Date;
            return await appDbContext.ExtensionRequests
                .FromSqlInterpolated($"EXEC GetExtensionsRequest @RequestDate = {dateOnly}")
                .ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByStatusAsync(Status status)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC GetExtensionsRequest @Status = {status}").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByTaskItemIdAsync(int taskItemId)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC GetExtensionsRequest @TaskItemId = {taskItemId}").ToListAsync();
        }

        public async Task UpdateAsync(ExtensionsRequest extensionsRequest)
        {
            appDbContext.ExtensionRequests.Update(extensionsRequest);
            await appDbContext.SaveChangesAsync();
        }
    }
}
