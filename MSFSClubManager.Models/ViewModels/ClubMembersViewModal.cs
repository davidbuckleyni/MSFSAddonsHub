using MSFSClubManager.Models;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
    public class ClubMembersViewModal
    {
        public List<Mods> Mods { get; set; }

        public List<FlightsViewModel> Flights { get; set; }

        public List<ClubMembers> ClubMembers { get; set; }

        public ClubInvitesViewModel ClubInvitesViewModal { get; set; }
    }
}
