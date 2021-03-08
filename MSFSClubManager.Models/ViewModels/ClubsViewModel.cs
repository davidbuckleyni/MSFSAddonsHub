using MSFSClubManager.Models;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
  public  class ClubsViewModel
    {

        public List<Club>? Clubs { get; set; }

        public List<ClubDownloads>? ClubDownloads { get; set; }
        public List<Mods>? Mods { get; set; }
        public List<Planes>? Planes { get; set; }

        public bool? IsClubAdmin { get; set; }

        public string? Roles { get; set; }
    }
}
