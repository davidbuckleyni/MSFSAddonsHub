using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
    public class UserViewModel
    {
        public bool IsClubAdmin { get; set; }
        public ApplicationUser User { get; set; }
    }
}
