using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSAddonsHub.WebApi
{
    public class MSFSContextSeedData
    {


        private MSFSAddonDBContext _context;

        public MSFSContextSeedData(MSFSAddonDBContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()

            
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = "davidbuckleyweb@outlook.com",
                    NormalizedUserName = "davidbuckleyweb@outlook.com",
                    Email = "davidbuckleyweb@outlook.com",
                    NormalizedEmail = "davidbuckleyweb@outlook.com",

                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var roleStore = new RoleStore<IdentityRole>(_context);

                //if (!_context.Roles.Any(r => r.Name == "admin"))
                //{
                //    await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
                //}

                if (!_context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user, "Test12345!");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<ApplicationUser>(_context);
                    var test =await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "admin");
                }
            }
            catch(Exception EX)
            {


            }

            await _context.SaveChangesAsync();
        }


    }
}
