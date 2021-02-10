using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
  public   class Invites
    {

        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? ClubId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }

        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }


        public string? ReferLink { get; set; }

        
        public bool? hasUserAccepted { get; set; }
        public int? Version { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
