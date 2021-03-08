using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSClubManager.Dal.Models
{
  public  class Mods
    {
        public int Id { get; set; }


        public enum AddonTypeEnum
        {
            User=1,
            Company=2,
            ThirdParty=3,
            MSFS=4

        }

        public int? AddonType { get; set; }

        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }

        public DateTime? StarDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }
        public virtual Category? AddonCategory { get; set; }
        public int? ConflictId { get; set; }
        public string? ThumbNail { get; set; }

        public string? Version { get; set; }


        public int? TotalDownloads { get; set; }
        public string? DownloadUrl { get; set; }

        public bool? isZipFile { get; set; }
        public bool? isJsonFile { get; set; }
        public string? DownloadJson { get; set; }
        public int? Category { get; set; }

        public bool? isDisplayHomePage { get; set; }
        public bool? isFeatured { get; set; }
 
 
        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
      
  
    }
}
