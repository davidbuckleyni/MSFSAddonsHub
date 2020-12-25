using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
   public  class Category
    {

        public int Id{ get; set; }
        public Guid TeannatId { get; set; }
        public int ParentId { get; set; }

        public string CategoryId { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

    }
}
