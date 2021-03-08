using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSFSClubManager.Models
{
    public class SubscriptionTeirs
    {


        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid Id { get; set; }
        public ApplicationUser? User { get; set; }

        public Club? Club { get; set; }

        public SubscriptionTypesBalances? SubscriptionTypesBalances { get; set; }

        
        public string? Desciption { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? Enabled { get; set; }

        public bool? isBlocked { get; set; }


        public SubscriptionTierTypes? SubscriptionTeirsType { get; set; }
        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

    }
}
