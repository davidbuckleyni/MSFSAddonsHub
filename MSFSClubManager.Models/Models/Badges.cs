using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
  public  class Badges
    {

        public int Id { get; set; }

        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }



        public string? BadgeName { get; set; }


        public string? BadgePoints { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

    }
}
