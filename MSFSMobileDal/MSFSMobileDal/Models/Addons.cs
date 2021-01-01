using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
   public  class Addons
    {
        public int Id { get; set; }

        public Guid? TeannatId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// this will be used by add on authors to allow them tell us what conlficts exist.
        /// </summary>
        public int ConflictId { get; set; }
        public string ThumbNail { get; set; }

        public string Version { get; set; }


        public int TotalDownloads { get; set; }
        public string DownloadUrl { get; set; }

        public bool? isZipFile { get; set; }
        public bool? isJsonFile { get; set; }
        public string DownloadJson { get; set; }
        public int? Category { get; set; }



        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
