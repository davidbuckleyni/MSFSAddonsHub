using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
  public   class FriendBlocks
    {

        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? UserId { get; set; }


        public DateTime? StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        private bool? PermanatBlock { get; set; }

        private bool? TempBlock { get; set; }

        public bool? isBlocked { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
