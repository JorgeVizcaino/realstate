using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RealState.Application.common.Interfaces;
using RealState.Infrastructure;
using RealState.Infrastructure.Identity;
using RealState.Infrastructure.Persistence;
using RealState.Infrastructure.Seed;

namespace RealState.WebApi
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var identityContext = services.GetRequiredService<ApplicationDbContext>();
                    identityContext.Database.Migrate();

                    //Populate Data
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var RolManager = services.GetRequiredService<RoleManager<ApplicationRol>>();
                    await ApplicationDbContextSeed.SeedAsync(userManager, RolManager);
                    await ApplicationDbContextSeed.SeedMainDataAsync(identityContext); 

                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or initializing the database.");
                }
            }

            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
