using MSFSClubManager.Models;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
  public  class ClubViewModel
    {

        public Club Club { get; set; }

        public List<ClubDownloads> ClubDownloads { get; set; }
    }
}
