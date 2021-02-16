using Microsoft.AspNetCore.Identity;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
  public  class ClubUsers
    {
        [Key]
        public int? Id { get; set; }
          public int? ClubId { get; set; }
        public String? UserId { get; set; }


        public string? Avatar { get; set; }

        public ApplicationUser? User { get; set; }
        public Club? Club { get; set; }
        public string? RoleId { get; set; }
        public IdentityRole? Role { get; set; }
        public DateTime? BannedStartDateTime { get; set; }
        public DateTime? BannedEndDateTime { get; set; }
        public bool? isBanned { get; set; }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
    }
}
