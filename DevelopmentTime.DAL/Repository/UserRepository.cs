using DevelopmentTimer.DAL.Data;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using DevelopmentTimer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext context)
        {
            this.appDbContext = context;
        }

        public async Task AddAsync(User user)
        {
            await appDbContext.Users.AddAsync(user);
            await appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await appDbContext.Users.FindAsync(id);
            if (user != null)
            {
                appDbContext.Users.Remove(user);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var users = await appDbContext.Users
                .FromSqlInterpolated($"EXEC sp_GetUserById @Id={id}")
                .ToListAsync();

            return users.FirstOrDefault();
        }

        public async Task<User?> GetByNameAsync(string name)
        {
            var users = await appDbContext.Users
                .FromSqlInterpolated($"EXEC sp_GetUserByName @Name={name}")
                .ToListAsync();

            return users.FirstOrDefault();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await appDbContext.Users
                .FromSqlRaw("EXEC sp_GetAllUsers")
                .ToListAsync();
        }

        public async Task<List<User>> GetByRoleAsync(Role role)
        {
            return await appDbContext.Users
                .FromSqlInterpolated($"EXEC sp_GetUsersByRole @Role={(int)role}")
                .ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
        }
    }
}
