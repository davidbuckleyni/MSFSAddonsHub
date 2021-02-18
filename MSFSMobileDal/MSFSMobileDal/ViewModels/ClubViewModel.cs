using MSFSAddons.Models;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Dal.ViewModels
{
  public  class ClubViewModel
    {

        public Club Club { get; set; }

        public List<ClubDownloads> ClubDownloads { get; set; }
    }
}
