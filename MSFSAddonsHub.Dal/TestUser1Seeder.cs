using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal
{
   public class TestUser1Seeder : IEntityTypeConfiguration<ApplicationUser>
{


        private const string TestUser1Id = "7796F3F2-5600-40A8-99B4-832EE57DC7E1";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = TestUser1Id,
                UserName = "test1@msfsaddonshub.com",
                NormalizedUserName = "test1@msfsaddonshub.com",
                FirstName = "Martha",
                LastName = "Jones",
                Email = "test1@msfsaddonshub.com",
                NormalizedEmail = "test1@msfsaddonshub.com",
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
