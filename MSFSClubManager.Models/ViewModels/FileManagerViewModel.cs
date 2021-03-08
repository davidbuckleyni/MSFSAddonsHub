using Microsoft.AspNetCore.Http;
using MSFSClubManager.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSClubManager.Dal.ViewModels
{
   public class FileManagerViewModel
    {
        public int Id { get; set; }

        public int? UploadServiceType { get; set; }
        public virtual Category? AddonCategory { get; set; }
        public int? ConflictId { get; set; }
        public string? ThumbNail { get; set; }
        public string? HttpDownloadUrl { get; set; }

        public string? Version { get; set; }

        public string? DownloadLink { get; set; }

        public int? TotalDownloads { get; set; }
        public string? DownloadUrl { get; set; }
        public bool? canBeDownloadedByOtherUsers { get; set; }

        public string? FileExtension { get; set; }
        public bool? isZipFile { get; set; }
        public bool? isJsonFile { get; set; }
        public string? DownloadJson { get; set; }
        public Guid? TeannatId { get; set; }
        public Guid? UserId { get; set; }


        public bool? isDisplayHomePage { get; set; }
        public bool? isFeatured { get; set; }
        public string? ThumbNailPath { get; set; }

        public IEnumerable<IFormFile>? File { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }
        public string? IPAddressBytes { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
