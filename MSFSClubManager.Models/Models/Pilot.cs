using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
    public class Pilot
    {
        [Key]
        public int Id { get; set; }

        public Guid? TeannatId { get; set; }


        public Guid? UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool? AllowFriends { get; set; }

       
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? GamerTag { get; set; }

        public virtual List<Badges>? Badges { get; set; }
        public virtual List<Friends>? Friends { get; set; }

        public virtual List<Flight>? Flights { get; set; }
        public virtual List<FileManger>? Files { get; set; }

        public virtual List<ClubLeaderBoards>? ClubLeaderBoards { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
