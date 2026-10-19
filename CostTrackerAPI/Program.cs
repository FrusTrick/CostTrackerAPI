using CostTrackerAPI.Data;
using CostTrackerAPI.Models;
using CostTrackerAPI.Repository;
using CostTrackerAPI.Repository.IRepository;
using CostTrackerAPI.Services;
using CostTrackerAPI.Services.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace CostTrackerAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<CostTrackerAPIDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddIdentityApiEndpoints<User>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole<int>>()
            .AddEntityFrameworkStores<CostTrackerAPIDBContext>();

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICostHistoryRepository, CostHistoryRepository>();
            builder.Services.AddScoped<ICostHistoryService, CostHistoryService>();
            builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            builder.Services.AddScoped<ISubscriptionService, SubscriptionService>();

            builder.Services.AddAuthorization();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("FrontendDev", policy =>
                {
                    policy.WithOrigins(builder.Configuration["Frontend_Domain"])
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            var app = builder.Build();

            // Seeding the DB with an Admin user if it doesn't exist
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    await Seeder.SeedAdminAsync(services);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
                app.UseCors("FrontendDev");
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            var api = app.MapGroup("/api");
            api.MapIdentityApi<User>();

            app.MapControllers();


            app.Run();
        }
    }
}
