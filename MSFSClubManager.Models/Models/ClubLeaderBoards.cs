using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
    public class ClubLeaderBoards
    {


        public int Id { get; set; }

        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }
        
        public string? Logo { get; set; }
        public int? Postion { get; set; }
        public int? Points { get; set; }
 
        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

        

    }
}
