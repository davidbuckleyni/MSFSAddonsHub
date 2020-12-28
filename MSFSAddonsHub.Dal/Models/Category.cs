using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
   public  class Category
    {

        public int Id{ get; set; }
        public Guid? TeannatId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public int? ParentId { get; set; }

        

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }

    }
}
