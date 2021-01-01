using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
   public  class DownloadManager
    {

         public int Id { get; set; }

        public string Name { get; set; }
        public Guid? TeannatId { get; set; }


        public int RowVersion { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
