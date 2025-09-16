using DevelopmentTimer.DAL.Data;
using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext) 
        {
            this.appDbContext = appDbContext;
        }

        public async Task AddAsync(User user)
        {
            var existinguser = await appDbContext.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == user.Username.ToLower());
            if (existinguser == null)
            {
                await appDbContext.Users.AddAsync(user);
                await appDbContext.SaveChangesAsync();
            }
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

        public async Task<User> GetByIdAsync(int id)
        {
            return await appDbContext.Users.FindAsync(id);
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == name.ToLower());
        }

        public Task<List<User>> GetAllAsync()
        {
            return appDbContext.Users.ToListAsync();
        }

        public async Task UpdateAsync(User user)
        {
            appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
        }
    }
}
