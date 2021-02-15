using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Models
{
  public  class BanHistory
    {
        public int Id { get; set; }

        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }

        public int? ClubId { get; set; }

        private bool? PermanatBan { get; set; }

        private bool? TempBan { get; set; }

        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public string? Notes { get; set; }


        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
