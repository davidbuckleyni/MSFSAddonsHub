using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Dal.Models
{
   public  class Credits
    {

        public int Id { get; set; }

        public Guid TeannatId { get; set; }
        public string Name { get; set; }

        public int Teir { get; set; }

        public int Balance { get; set; }

        public int Total { get; set; }

        public bool isAdmin { get; set; }


        public bool isActive { get; set; }

        public bool isDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}
