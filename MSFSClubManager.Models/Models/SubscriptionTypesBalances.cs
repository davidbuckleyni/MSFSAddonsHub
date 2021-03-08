using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSFSClubManager.Models
{
   public class SubscriptionTypesBalances
    {
       
        public int Id { get; set; }


        public Guid? TeannatId { get; set; }
        public int? ClubId { get; set; }
        public ApplicationUser? UserId { get; set; }

        public int? ClubsAllowed { get; set; }

        public int? DownloadsAllowed { get; set; }

        public int? ModsAllowed { get; set; }

        public int? AircraftsAllowed { get; set; }


        public int? FlightsAllowed { get; set; }
        public int? EventsAllowed { get; set; }



        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }



    }
}
