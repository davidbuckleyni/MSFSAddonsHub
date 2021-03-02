using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal
{
    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string TestUser1Id = "7796F3F2-5600-40A8-99B4-832EE57DC7E1";
        private const string TestUser2Id = "4F75BBA1-1CDF-44A7-84DF-D0C617E5E19D";
        private const string ClubSuperAdminRole = "f95d8e54-ab12-406b-973b-ab92d4cab72a";
        private const string ClubUserRole = "c2f9a56d-4e18-4d38-8eab-7a141895b049";
        private const string ClubModRole = "65f1941d-048a-4b02-ad8e-1757e392aad8";
        private const string Admin = "20ab180a-70cf-48b9-9315-4308b385b83f";

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            //IdentityUserRole<string> iur = new IdentityUserRole<string>
            //{
            //    RoleId = Admin,
            //    UserId = Admin,
            //};

       //     builder.HasData(iur);



            IdentityUserRole<string> TestUser2Roles = new IdentityUserRole<string>
            {
                RoleId = ClubUserRole,
                UserId = TestUser2Id,
            };

            builder.HasData(TestUser2Roles);


            IdentityUserRole<string> TestUser1Roles = new IdentityUserRole<string>
            {
                RoleId = ClubModRole,
                UserId = TestUser1Id,
            };

            builder.HasData(TestUser1Roles);
        }
    }
}
