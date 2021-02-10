using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
    public class ClubDownloads
    {
        public int Id { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? ClubId { get; set; }

        public Guid? UserId { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
        public int? FlightId { get; set; }

        public FileManger? File { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

    }
}
