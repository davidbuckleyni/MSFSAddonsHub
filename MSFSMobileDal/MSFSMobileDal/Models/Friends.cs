using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
    public class Friends
    {

        public enum FriendStatusEnum
        {
            Requested=1,
            Accepted=2,
            Rejected=3,
            Blocked=4
        }
        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? ClubId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public ApplicationUser?  FriendId { get; set; }

        public bool? hasExcepted { get; set; }

        public int? Status { get; set; }

        public int? RequestedIp { get; set; }

        public bool? isBlocked { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }



    }
}
