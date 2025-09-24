
using Microsoft.EntityFrameworkCore;
using DevelopmentTimer.DAL.Data;
using DevelopmentTimer.DAL.Repository;
using DevelopmentTimer.DAL.Interfaces;
using DevelopmentTimer.BAL.Interfaces;
using DevelopmentTimer.BAL.Managers;

namespace DevelopmentTimer.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

            // Add services to the container.

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
            builder.Services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            builder.Services.AddScoped<IExtensionsRequestRepository, ExtensionsRequestRepository>();
            

            builder.Services.AddScoped<IUserManager, UserManager>();
            builder.Services.AddScoped<IProjectManager, ProjectManager>();
            builder.Services.AddScoped<ITaskItemManager, TaskItemManager>();
            builder.Services.AddScoped<IExtensionsRequestManager, ExtensionsRequestManager>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorDevClient", policy =>
                {
                    policy.WithOrigins("https://localhost:7072", "http://localhost:5112")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });


            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();
            app.UseCors("AllowBlazorDevClient");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
