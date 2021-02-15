using Microsoft.AspNetCore.Identity;
using MSFSAddons.Models;
using MSFSAddons.Models.Models;
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
            ClubMember=6,
            ClubAdmin=7,
            SuperAdmin=199,
            BandUser=999
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? GamerTag { get; set; }
        public bool? isOnline { get; set; }
        public int? UserType { get; set; }
        public Guid? TennantId { get; set; }
        public Guid? ClubId { get; set; }
   
         public List<Badges>? Badges { get; set; }
        public virtual List<ClubUsers> ClubUsers { get; set; }


    }
}
