using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.Web
{
    public static class IdentityInitiliazer
    {

        public static async Task SeedData(UserManager<AppUser> usermanager,RoleManager<AppRole> rolemanager)
        {

            var adminRole = await rolemanager.FindByNameAsync("Admin");
            if (adminRole==null)
            {

                await rolemanager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await rolemanager.FindByNameAsync("Member");

            if (memberRole==null)
            {
                await rolemanager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = usermanager.FindByNameAsync("resad");
            if (adminUser.Result==null)
            {

                AppUser user = new AppUser()
                {
                    Name = "Resad",
                    UserName = "resad",
                    Surname = "Isayev",
                    Email = "resadisayev9@gmail.com"
                };
                await usermanager.CreateAsync(user,"1");

                await usermanager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
