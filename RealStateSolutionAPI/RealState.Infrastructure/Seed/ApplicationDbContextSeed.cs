using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using RealState.Infrastructure.Identity;
using RealState.Infrastructure.Persistence;
using RealState.Domain.Entities;

namespace RealState.Infrastructure.Seed
{
    public static class ApplicationDbContextSeed
    {
        /// <summary>
        /// Create initia user
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="userManagerRol"></param>
        /// <returns></returns>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRol> userManagerRol)
        {
            var defaultUser = new ApplicationUser { UserName = "Administrator", Email = "jorge.vizcaino@hotmail.net" };
            if (!userManager.Users.Any(u => u.UserName == defaultUser.UserName))
            {
                await userManagerRol.CreateAsync(new ApplicationRol { Name = "Administrator" });
                await userManager.CreateAsync(defaultUser, "123123$");
                await userManager.AddToRoleAsync(defaultUser, "Administrator");
            }
        }

        /// <summary>
        /// Populate main data
        /// </summary>
        /// <param name="identityDbContext"></param>
        /// <returns></returns>
        public static async Task SeedMainDataAsync(ApplicationDbContext identityDbContext)
        {
            if (identityDbContext.Property.Any())
                return;

            string pathBin = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\Data\\json1.json";

            using (var sr = new StreamReader(pathBin.Replace("file:\\", "").ToString()))
            {
                var properties = JsonConvert.DeserializeObject<root>(sr.ReadToEnd());
                identityDbContext.Property.AddRange(properties.properties);
                await identityDbContext.SaveChangesAsync();
            }


        }
    }

    public class root
    {
        public List<Property> properties { get; set; }
    }
}