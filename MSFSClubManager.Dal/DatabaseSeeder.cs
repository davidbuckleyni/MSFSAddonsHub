using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MSFSClubManager.Dal;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSFSClubManager.Dal
{
    public class DatabaseSeeder
    { 
        public static async void SeedAdminUser(MSFSAddonDBContext context)


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



                var Test1 = new ApplicationUser
                {
                    UserName = "test1@msfsaddonshub.com",
                    NormalizedUserName = "test1@msfsaddonshub.com",
                    Email = "test1@msfsaddonshub.com",
                    NormalizedEmail = "test1@msfsaddonshub.com",

                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };


                var Test2 = new ApplicationUser
                {
                    UserName = "test2@msfsaddonshub.com",
                    NormalizedUserName = "test2@msfsaddonshub.com",
                    Email = "test2@msfsaddonshub.com",
                    NormalizedEmail = "test2@msfsaddonshub.com",

                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var roleStore = new RoleStore<IdentityRole>(context);

                //if (!_context.Roles.Any(r => r.Name == "admin"))
                //{
                //    await roleStore.CreateAsync(new IdentityRole { Name = "admin", NormalizedName = "admin" });
                //}




                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(user, "Test12345!");
                    user.PasswordHash = hashed;
                    var userStore = new UserStore<ApplicationUser>(context);
                    var test = await userStore.CreateAsync(user);
                    await userStore.AddToRoleAsync(user, "ClubSuperAdmin");
                    await context.SaveChangesAsync();

                }

                if (!context.Users.Any(u => u.UserName == Test1.UserName))
                {
                    try
                    {
                        var password = new PasswordHasher<ApplicationUser>();
                        var hashed = password.HashPassword(Test1, "Test12345!");
                        Test1.PasswordHash = hashed;
                        var userStore = new UserStore<ApplicationUser>(context);
                        var test = await userStore.CreateAsync(Test1);
                        await userStore.AddToRoleAsync(Test1, "ClubMod");
                        await context.SaveChangesAsync();

                    }

                    catch (Exception EX)
                    {
                        var error = EX.InnerException.ToString();
                        Console.WriteLine(error);

                    }
                }



                if (!context.Users.Any(u => u.UserName == Test2.UserName))
                {
                    var password = new PasswordHasher<ApplicationUser>();
                    var hashed = password.HashPassword(Test2, "Test12345!");
                    Test2.PasswordHash = hashed;
                    var userStore = new UserStore<ApplicationUser>(context);
                    var test = await userStore.CreateAsync(Test2);
                    await userStore.AddToRoleAsync(Test2, "ClubUser");
                    await context.SaveChangesAsync();

                }



            }
            catch (Exception EX)
            {


            }




        }
    }
}
