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
        //public DbSet<TimeSheet> Timesheets { get; set; }
        public DbSet<ExtensionsRequest> ExtensionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<TimeSheet>()
            //    .HasOne(ts => ts.Developer)
            //    .WithMany(u => u.Timesheets)
            //    .HasForeignKey(ts => ts.DeveloperId)
            //    .OnDelete(DeleteBehavior.Restrict); 

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


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1,Username = "Admin",Password = "Admin@1234",Role = Role.Admin},
                new User { Id = 2,Username = "Sita",Password = "Sita@1234",Role = Role.Developer},
                new User { Id = 3,Username = "Rita",Password = "Rita@5678",Role = Role.Developer}
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
                    Description = "Creating the login page with username, password fields, and validation for user authentication.",
                    EstimatedHours = 2,
                    Status = Status.InProgress,
                    ProjectId = 1,
                    DeveloperId = 2,
                    TotalHours = 1,
                    isApproved = false,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-2)),
                    NotificationThresholdMinutes = new TimeOnly(1, 30)
                },
                new TaskItem
                {
                    Id = 2,
                    Title = "Register Page",
                    Description = "Creating the registration page with user input validations, email verification, and password rules.",
                    EstimatedHours = 3,
                    Status = Status.Completed,
                    ProjectId = 1,
                    DeveloperId = 2,
                    TotalHours = 3,
                    isApproved = true,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)),
                    NotificationThresholdMinutes = new TimeOnly(0, 45)
                },
                new TaskItem
                {
                    Id = 3,
                    Title = "Login Page",
                    Description = "Implement login functionality including API integration and proper error handling for Project Beta.",
                    EstimatedHours = 2,
                    Status = Status.InProgress,
                    ProjectId = 2,
                    DeveloperId = 3,
                    TotalHours = 2,
                    isApproved = false,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-3)),
                    NotificationThresholdMinutes = new TimeOnly(2, 0)
                },
                new TaskItem
                {
                    Id = 4,
                    Title = "Register Page",
                    Description = "Implement registration functionality including validations, email service, and security checks for Project Beta.",
                    EstimatedHours = 3,
                    Status = Status.Completed,
                    ProjectId = 2,
                    DeveloperId = 3,
                    TotalHours = 3,
                    isApproved = true,
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)),
                    NotificationThresholdMinutes = new TimeOnly(1, 0)
                }
            );

            //modelBuilder.Entity<TimeSheet>().HasData(
            //    new TimeSheet { Id = 1,DeveloperId = 2,TaskItemId = 1,HoursWorked = 5,Submitted = true,ApprovalStatus = Status.Pending,SubmissionDate = new DateTime(2025,09,15)},
            //    new TimeSheet { Id = 2, DeveloperId = 2, TaskItemId = 2, HoursWorked = 4, Submitted = false, ApprovalStatus = Status.OnHold, SubmissionDate = new DateTime(2025, 09, 25)}
            //);
            modelBuilder.Entity<ExtensionsRequest>().HasData(
                new ExtensionsRequest { Id = 1,TaskItemId = 1,DeveloperId = 2,ExtraHours = 1,Justification = "To create responsive design"},
                new ExtensionsRequest { Id = 2,TaskItemId = 3,DeveloperId = 3,ExtraHours = 2,Justification = "To create responsive design"}
            );
        }
    }
}
