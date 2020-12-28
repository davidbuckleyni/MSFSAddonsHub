using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.Dal.Models
{
  public   class AddonJson
    {

        public string Name { get; set; }

        public string Version { get; set; }

        public string ThumbNail { get; set; }

        public string Author { get; set; }

        public string isAfiliate { get; set; }

        public int AfiliateCode { get; set; }
    }
}
