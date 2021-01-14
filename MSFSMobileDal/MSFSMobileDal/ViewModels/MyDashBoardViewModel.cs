using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Dal.Models
{
   public  class MyDashBoardViewModel
    {

        public enum ProfileType
        {
            User=1,
            Company=2,
            Admin=3


        }
        public int Id { get; set; }

        public int Type { get; set; }

        private string? GamerTag { get; set; }

        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AboutMe { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
