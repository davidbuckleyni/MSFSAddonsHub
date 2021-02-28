using MSFSAddons.Models;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Dal.ViewModels
{
    public class ClubMembersViewModal
    {

     
        public List<ClubMembers> ClubMembers { get; set; }

        public ClubInvitesViewModel ClubInvitesViewModal { get; set; }
    }
}
