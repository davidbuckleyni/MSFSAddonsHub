using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
    public class UserModalViewModel
    {
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email  { get; set; }

        [Required]
        public string Password { get; set; }

        public bool isAdmin { get; set; }
        public string GamerTag { get; set; }

    }
}
