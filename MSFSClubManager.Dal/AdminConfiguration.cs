using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal
{
   public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
   
        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = adminId,
                UserName = "davidbuckleyweb@outlook.com",
                NormalizedUserName = "davidbuckleyweb@outlook.com",
                FirstName = "David",
                LastName = "Admin",
                Email = "davidbuckleyweb@outlook.com",
                NormalizedEmail = "davidbuckleyweb@outlook.com",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
                UserType =(int) ApplicationUser.UserTypeEnum.SuperAdmin
            };

            admin.PasswordHash = PassGenerate(admin,"Test12345");

            builder.HasData(admin);
        }


        public string PassGenerate(ApplicationUser user,string password)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, password);
        }

    }
}
