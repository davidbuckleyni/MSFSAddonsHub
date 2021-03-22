using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
    public class ClubViewModelApi
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool isActive { get; set; }

        public bool isDeleted { get; set; }
    }
}
