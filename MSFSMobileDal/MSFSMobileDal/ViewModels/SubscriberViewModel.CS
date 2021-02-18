using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddons.Dal.ViewModels
{
    public class SubscriberViewModel
    {

        public int Id { get; set; }

        public string Email { get; set; }

        public DateTime GPDRReqestDate { get; set; }

       
        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
         
    }
}
