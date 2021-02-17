using MSFSAddons.Models;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models

{
   public  class Club
    {

        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? ClubId { get; set; }
        public Guid? UserId { get; set; }
        public string? Name { get; set; }       
        public string? Description { get; set; }
        public string? Url { get; set; }
        public int? ClubLikes { get; set; }
        public int? ClubDislikes { get; set; }
        public int? MembersCount { get; set; }
        public string? Logo { get; set; }
        public List<Flight>? Flights { get; set; }
        public string? ThumbNail { get; set; }
        public DateTimeOffset? GpdrRemoveRequestDate { get; set; }
        public bool? isGpdrRemoveRequest { get; set; }
        public DateTimeOffset? BannedTime { get; set; }
        public TimeSpan? BanPeriod { get; set; }
        public bool? isBanned { get; set; }
        public bool? isActive { get; set; }
        public bool? isDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public virtual List<ClubMembers> ClubUsers { get; set; }

    }
}
