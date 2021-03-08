using MSFSAddons.Models.Dal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
    public class Planes
    {

        [Key]
        public int Id { get; set; }

        public Guid? TeannatId { get; set; }


        public Guid? UserId { get; set; }
        public DateTime? StarDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
        public virtual List<Mods>? Mods { get; set; }

        public virtual List<PlanesLiverys>? Liveries { get; set; }

        public virtual List<FileManger>? Files { get; set; }
        public string? Version { get; set; }


        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
