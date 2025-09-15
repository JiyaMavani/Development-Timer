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
        public DbSet<TimeSheet> Timesheets { get; set; }
        public DbSet<ExtensionsRequest> ExtensionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Developer)
                .WithMany()
                .HasForeignKey(t => t.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<ExtensionsRequest>()
                .HasOne(er => er.TaskItem)
                .WithMany(t => t.ExtensionRequests)
                .HasForeignKey(er => er.TaskItemId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<ExtensionsRequest>()
                .HasOne(er => er.Developer)
                .WithMany()
                .HasForeignKey(er => er.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict);


            //seeding data for user entity
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Admin1", Password = "Admin@123", Role = UserRole.Admin },
                new User { Id = 2, Username = "Dev1", Password = "Dev@1234", Role = UserRole.Developer },
                new User { Id = 3, Username = "Dev2", Password = "Dev@5678", Role = UserRole.Developer }
            );

            //seeding data for project entity
            modelBuilder.Entity<Project>().HasData(
               new Project { Id = 1, Name = "Project A", MaxHoursPerDay = 8 },
               new Project { Id = 2, Name = "Project B", MaxHoursPerDay = 6 }
            );

            //seeding data for taskitem entity
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Design DB", Description = "Design database schema", EstimatedHours = 4, Status = TaskItemStatus.InProgress, ProjectId = 1, DeveloperId = 2 },
                new TaskItem { Id = 2, Title = "API Setup", Description = "Setup backend API", EstimatedHours = 6, Status = TaskItemStatus.Pending, ProjectId = 1, DeveloperId = 3 }
            );

            //seeding data for timesheet entity
            modelBuilder.Entity<TimeSheet>().HasData(
                new TimeSheet { Id = 1, DeveloperId = 2, TaskItemId = 1, HoursWorked = 2, Submitted = false, ApprovalStatus = ApprovalStatus.Pending },
                new TimeSheet { Id = 2, DeveloperId = 3, TaskItemId = 2, HoursWorked = 3, Submitted = false, ApprovalStatus = ApprovalStatus.Pending }
            );
            
            //seeding data for extension request entity
            modelBuilder.Entity<ExtensionsRequest>().HasData(
                new ExtensionsRequest { Id = 1, TaskItemId = 1, DeveloperId = 2, ExtraHours = 2, Justification = "Need more time to finalize design", Status = ExtensionStatus.Pending },
                new ExtensionsRequest { Id = 2, TaskItemId = 2, DeveloperId = 3, ExtraHours = 1, Justification = "API dependencies delay", Status = ExtensionStatus.Pending }
            );
        }
    }
}
