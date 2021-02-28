using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal
{
   public class TestUser2Seeder : IEntityTypeConfiguration<ApplicationUser>
    {

        private const string TestUser2Id = "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = TestUser2Id,
                UserName = "test2@msfsaddonshub.com",
                NormalizedUserName = "test2@msfsaddonshub.com",
                FirstName = "The",
                LastName = "Dr",
                Email = "test2@msfsaddonshub.com",
                NormalizedEmail = "test2@msfsaddonshub.com",
                PhoneNumber = "XXXXXXXXXXXXX",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = new Guid().ToString("D"),
                UserType = (int)ApplicationUser.UserTypeEnum.SuperAdmin
            };

            admin.PasswordHash = PassGenerate(admin, "Test12345");

            builder.HasData(admin);
        }


        public string PassGenerate(ApplicationUser user, string password)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, password);
        }

    }
}
