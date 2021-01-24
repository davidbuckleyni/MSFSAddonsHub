using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Models
{
   public  class FlightRoutes
    {

        
        public int Id { get; set; }

        

        public string? ICAOCode { get; set; }

        public string? AirportName { get; set; }

        public Guid? TeannatId { get; set; }


        public Guid? UserId { get; set; }
        public int? ClubId { get; set; }

        public string? ThumbNail { get; set; }
        public int? Version { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
