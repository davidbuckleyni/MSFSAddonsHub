﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Dal.Models
{
    public class ApplicationUser : IdentityUser
    {
        public enum UserTypeEnum
        {
            Guest=0,
            User=1,
            Author=2,
            AddonOwner=3,
            GroupOwner=5,
            SuperAdmin=199
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }


        public int UserType { get; set; }
        public Guid TennantId { get; set; }


        

    }
}
