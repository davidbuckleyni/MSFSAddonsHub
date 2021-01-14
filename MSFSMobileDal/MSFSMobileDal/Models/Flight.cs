﻿using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Models
{
    public class Flight
    {

        public int Id { get; set; }

        public Guid? TeannatId { get; set; }

        public Guid? UserId { get; set; }
        public DateTimeOffset? FlightDate { get; set; }

        public string? FlightDescription { get; set; }

     
 
        public virtual List<MyAddon>? Addons { get; set; }

        public int ClubId { get; set; }

        public string ThumbNail { get; set; }
        public int Version { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
       

    }
}
