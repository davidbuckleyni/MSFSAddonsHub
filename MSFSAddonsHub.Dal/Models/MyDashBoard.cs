using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Dal.Models
{
   public  class MyDashBoard
    {

        public enum ProfileType
        {
            User=1,
            Company=2,
            Admin=3


        }
        public int Id { get; set; }

        public int Type { get; set; }
        public Guid TeannatId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AboutMe { get; set; }

    }
}
