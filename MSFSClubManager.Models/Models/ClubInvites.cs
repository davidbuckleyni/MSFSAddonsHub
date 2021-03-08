using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
    public class ClubInvites
    {
        public enum InviteEnum {
            Sent=1,
            Invalid =2,
            Accepted=3,
            Declined = 4

            
            }
        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? ClubId { get; set; }
        public ApplicationUser? UserFrom { get; set; }

        public ApplicationUser? UserTo { get; set; }
        public Guid? UserId { get; set; }
        public string? Name { get; set; }


        public Guid?  From { get; set; }


        public Guid?  To { get; set; }


        public string? FromEmail { get; set; }


        public string? ToEmail{ get; set; }

        public int? Status { get; set; }

        public DateTime? StartDate { get; set; }


        public DateTime? EndDate { get; set; }

        public int? ExpiresHours { get; set; }
        public string? ReferLink { get; set; }

        public bool? DateUserAccepted { get; set; }

        public bool? hasUserAccepted { get; set; }
        public int? Version { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
