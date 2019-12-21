using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {        
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            Console.WriteLine("Arrived application seeder");
            var defaultUser = new ApplicationUser { UserName = "zionlloyd05@gmail.com", Email = "zionlloyd05@gmail.com" };
            await userManager.CreateAsync(defaultUser, "Qwerty123*");
        }
    }
}
