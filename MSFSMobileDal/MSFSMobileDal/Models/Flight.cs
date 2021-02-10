using MSFSAddons.Models.Models;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        public Guid? TeannatId { get; set; }


        public Guid? UserId { get; set; }
        public string? StartAirportCode { get; set; }


        public string? DestAirportCode { get; set; }

        
        public DateTime? FlightDate { get; set; }
        public DateTime? StartDate { get; set; }

        public int? TimeinMins { get; set; }
        public string? TimeInFluent { get; set; }

        public string? TimeZone { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
        public string? FlightDescription { get; set; }

        public string? FlightPlanXML {get;set; }

        public string? FlightPlanUrl { get; set; }
        public virtual List<MyAddon>? Addons { get; set; }
        //This will be the club id or the Teannant Id dont no which to use as of yet.
        public int? ClubId { get; set; }

        public string? ThumbNail { get; set; }
        public int? Version { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
        public virtual List<FlightRoutes>? FlightRoutes { get; set; }


    }
}
