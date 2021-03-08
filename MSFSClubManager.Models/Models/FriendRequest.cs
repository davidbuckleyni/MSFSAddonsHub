using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
    public class FriendRequest
    {


        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? ClubId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }

        public ApplicationUser? FreindRequestedId { get; set; }


        public ApplicationUser?  FriendId { get; set; }

        public int? RequestedIp { get; set; }
        public bool? hasAccepted { get; set; }

        public int? Status { get; set; }

        public bool? isBlocked { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }



    }
}
