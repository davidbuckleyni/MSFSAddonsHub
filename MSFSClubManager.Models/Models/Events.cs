using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Models.Models
{
    public class Events
    {

        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }

        public int? ClubId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public TimeSpan? StartTime { get; set; }

        public static TimeZone? CurrentTimeZone { get; set; }


        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

    }
}
