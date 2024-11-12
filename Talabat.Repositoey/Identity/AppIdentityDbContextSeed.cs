using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entites.identity;

namespace Talabat.Repositoey.Identity
{
    public static class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var User = new AppUser()
                {
                    DisplayName = "Nada Salah",
                    Email = "nadasalahahmed000@gmail.com",
                    UserName = "nada_salah",
                    PhoneNumber = "01274321817"
                };
                await userManager.CreateAsync(User,"Pa$$w0rd");
            }
        }
    }
}
