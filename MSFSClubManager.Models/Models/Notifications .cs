using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.Models
{
    public class Notifications
    {

        public  enum NotificationsType
        {
            Invitation = 1,
            UserMessage=2,
            System=3


        }
        public int Id { get; set; }


        public Guid? TeannatId { get; set; }

        public Guid? UserId { get; set; }

        public string? From { get; set; }


        public string? To { get; set; }

        public Guid? FromUser { get; set; }

        public Guid? ToUser { get; set; }

        public string? MessageBody { get; set; }

        public int? FolderId { get; set; }

        public int? Type { get; set; }

        public string? isRead { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
