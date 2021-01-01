using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
    public class RoleModels {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
    }
}
