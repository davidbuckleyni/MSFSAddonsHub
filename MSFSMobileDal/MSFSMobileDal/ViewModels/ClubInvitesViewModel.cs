﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Dal.ViewModels
{
    public class ClubInvitesViewModel
    {
        public string? FromMember { get; set; }

        public Guid? ClubId  { get; set; }

        public string? ToMember { get; set; }

    }
}
