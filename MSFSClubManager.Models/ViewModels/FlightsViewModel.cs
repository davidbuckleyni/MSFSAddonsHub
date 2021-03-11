using MSFSClubManager.Models.Models;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
    public class FlightsViewModel
    {
        public bool isClubAdmin { get; set; }
        public virtual Club Club { get; set; }
        public virtual List<Flight>? Flights { get; set; }

        public virtual List<FlightRoutes>? FlightRoutes { get; set; }


    }
}
