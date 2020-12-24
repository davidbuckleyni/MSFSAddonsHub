using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddonsHub.Dal.Models
{
   public  class AddOnDetails
    {

        public int Name { get; set; }

        public string ThumbNail { get; set; }

        public string Version { get; set; }

        public string DownloadUrl { get; set; }

        public int Category { get; set; }
    }
}
