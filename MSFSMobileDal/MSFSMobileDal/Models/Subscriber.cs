using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Dal.Models
{
    public class Subscriber
    {

        public int Id { get; set; }

        public Guid? TeannatId { get; set; }

        public Guid? UserId { get; set; }
        public string Email { get; set; }

        public DateTime GPDRReqestDate { get; set; }

        public bool? GpdrRemoval { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
