using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
    public class UsersViewModel
    {

        public bool IsClubAdmin { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
