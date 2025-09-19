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
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC sp_GetAllExtensionRequests").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByDeveloperIdAsync(int developerId)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC sp_GetExtensionRequestByDeveloperId @DeveloperId = {developerId}").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByExtraHoursAsync(int extraHours)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC sp_GetExtensionRequestByExtraHours @ExtraHours = {extraHours}").ToListAsync();
        }

        public async Task<ExtensionsRequest> GetByIdAsync(int id)
        {
            var extensionRequest = await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC sp_GetExtensionRequestById @Id = {id}").ToListAsync();
            return extensionRequest.FirstOrDefault();
        }

        public async Task<List<ExtensionsRequest>> GetByJustificationAsync(string justification)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC sp_GetExtensionRequestByJustification @Justification = {justification}").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByRequestDateAsync(DateTime requestDate)
        {
            return await appDbContext.ExtensionRequests
                .FromSqlInterpolated($"EXEC sp_GetExtensionRequestByRequestDate @RequestDate = {requestDate:yyyy-MM-dd}")
                .ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByStatusAsync(Status status)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC sp_GetExtensionRequestByStatus @Status = {status}").ToListAsync();
        }

        public async Task<List<ExtensionsRequest>> GetByTaskItemIdAsync(int taskItemId)
        {
            return await appDbContext.ExtensionRequests.FromSqlInterpolated($"EXEC sp_GetExtensionRequestByTaskItemId @TaskItemId = {taskItemId}").ToListAsync();
        }

        public async Task UpdateAsync(ExtensionsRequest extensionsRequest)
        {
            appDbContext.ExtensionRequests.Update(extensionsRequest);
            await appDbContext.SaveChangesAsync();
        }
    }
}
