using System;
using System.Collections.Generic;
using System.Text;

namespace CLUBManager.Mobile.ViewModels
{
    public class ClubViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
    }
}
