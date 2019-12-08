﻿using Microsoft.AspNetCore.Identity;
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
            var defaultUser = new ApplicationUser { UserName = "zionlloyd05@gmail.com", Email = "zionlloyd05@gmail.com" };
            await userManager.CreateAsync(defaultUser, "qwerty123");
        }
    }
}