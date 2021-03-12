using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
   public  class LeaderBoards
    {


        public int Id { get; set; }

        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }

    }
}
