using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddons.Dal.ViewModels
{
  public  class UserAddonViewModel
    {
        public int Id { get; set; }

        public int AddONId { get; set; }
        public Guid TeannatId { get; set; }
        public string Name { get; set; }

        public virtual Category AddonCategory { get; set; }

        public string ThumbNail { get; set; }
 
        public bool isActive { get; set; }

        public bool isDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
