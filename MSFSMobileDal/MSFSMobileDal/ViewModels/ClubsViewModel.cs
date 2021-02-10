using MSFSAddons.Models;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.ViewModels
{
  public  class ClubsViewModel
    {

        public List<Club> Clubs { get; set; }

        public List<ClubDownloads> ClubDownloads { get; set; }
    }
}
