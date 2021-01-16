using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Models
{
    public class FileFolders
    {
        public int Id { get; set; }
         public int? ConflictId { get; set; }
        public string? ThumbNail { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }


        public bool? isDisplayHomePage { get; set; }
        public bool? isFeatured { get; set; }
        public string? ThumbNailPath { get; set; }

        public string? FilePath { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }
        public string? IPAddressBytes { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
