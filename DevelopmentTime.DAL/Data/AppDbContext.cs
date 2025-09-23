using DevelopmentTimer.DAL.Entities;
using DevelopmentTimer.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentTimer.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<ExtensionsRequest> ExtensionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ExtensionsRequest>()
                .HasOne(e => e.Developer)
                .WithMany(u => u.ExtensionRequests)
                .HasForeignKey(e => e.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExtensionsRequest>()
                .HasOne(e => e.TaskItem)
                .WithMany(t => t.ExtensionRequests)
                .HasForeignKey(e => e.TaskItemId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Developer)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v));

            modelBuilder.Entity<Project>()
              .Property(t => t.Status)
              .HasConversion(
                  v => v.ToString(),
                  v => (Status)Enum.Parse(typeof(Status), v));

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (Status)Enum.Parse(typeof(Status), v));

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1,Username = "Admin",Password = "Admin@1234",Role = Role.Admin,AssignedProjectIds = "0"},
                new User { Id = 2,Username = "Sita",Password = "Sita@1234",Role = Role.Developer,AssignedProjectIds = "1"},
                new User { Id = 3,Username = "Rita",Password = "Rita@5678",Role = Role.Developer,AssignedProjectIds = "2,3"}
            );
            modelBuilder.Entity<Project>().HasData(
               new Project { Id = 1, Name = "Project1", MaxHoursPerDay = 7, Status = Status.InProgress },
               new Project { Id = 2, Name = "Project2", MaxHoursPerDay = 6, Status = Status.Completed },
               new Project { Id = 3, Name = "Project3", MaxHoursPerDay = 8, Status = Status.OnHold }
            );

            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem
                {
                    Id = 1,
                    Title = "Login Page",
                    Description = "This is the login page creation task with detailed description",
                    EstimatedHours = 2,
                    TotalHours = 2,
                    Status = Status.InProgress,
                    ProjectId = 1,
                    DeveloperId = 2,
                    isApproved = false,
                    Date = new DateOnly(2025, 9, 19),
                    NotificationThresholdMinutes = new TimeOnly(0, 10)
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Register Page",
                    Description = "Develop the register page including email verification, password rules validation, and linking it with the database for new users.",
                    EstimatedHours = 3,
                    TotalHours = 3,
                    Status = Status.Completed,
                    ProjectId = 1,
                    DeveloperId = 2,
                    isApproved = true,
                    Date = new DateOnly(2025, 9, 18),
                    NotificationThresholdMinutes = new TimeOnly(0, 45)
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Dashboard",
                    Description = "Implement dashboard UI to display project status, active tasks, and progress reports using charts and grids for better user insights.",
                    EstimatedHours = 3,
                    TotalHours = 3,
                    Status = Status.Pending,
                    ProjectId = 2,
                    DeveloperId = 3,
                    isApproved = false,
                    Date = new DateOnly(2025, 9, 20),
                    NotificationThresholdMinutes = new TimeOnly(0, 30) 
                },
                new TaskItem
                {
                    Id = 4,
                    Title = "Profile Page",
                    Description = "Design and build profile page where users can update details, change password, and manage their personal settings securely.",
                    EstimatedHours = 4,
                    TotalHours = 4,
                    Status = Status.InProgress,
                    ProjectId = 2,
                    DeveloperId = 3,
                    isApproved = false,
                    Date = new DateOnly(2025, 9, 21),
                    NotificationThresholdMinutes = new TimeOnly(0, 15) 
                }
            );

            modelBuilder.Entity<ExtensionsRequest>().HasData(
                new ExtensionsRequest { Id = 1,TaskItemId = 1,DeveloperId = 2,ExtraHours = 2,Justification = "To create responsive design"},
                new ExtensionsRequest { Id = 2,TaskItemId = 3,DeveloperId = 3,ExtraHours = 3,Justification = "To create responsive design"}
            );
        }
    }
}
