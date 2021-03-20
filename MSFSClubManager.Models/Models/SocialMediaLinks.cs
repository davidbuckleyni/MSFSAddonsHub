using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Models
{
    public class SocialMediaLinks
    {
        public int Id { get; set; }
        public Guid? TeannatId { get; set; }


        public Guid? UserId { get; set; }
        public string? Name { get; set; }

        public string? Icon { get; set; }

        public string? URL { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
