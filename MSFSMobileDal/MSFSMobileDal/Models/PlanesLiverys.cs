using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSAddons.Models.Dal
{
 public   class PlanesLiverys
    {
        [Key]
        public int Id { get; set; }

        public Guid? TeannatId { get; set; }


        public Guid? UserId { get; set; }

        public string? Name { get; set; }
        public DateTime? StarDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
       
        public virtual List<FileManger>? Files { get; set; }

          public string? Version { get; set; }


        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
