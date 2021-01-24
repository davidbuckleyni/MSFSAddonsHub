using Microsoft.AspNetCore.Http;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Models
{
    public class FileManger
    {

        public enum FileManagerEnum{
         Upload=1,
        Download=2,

        }


        public enum Status
        {
            Published=1,
            Disabled=2,
            NewVersion=3,
            Archived=4

        }

        public int Id { get; set; }

        public string Name { get; set; }
        public virtual FileFolders? Folders { get; set; }

        public int? ConflictId { get; set; }
        public string? ThumbNail { get; set; }

        public string? Version { get; set; }

        public string? CustomFileName { get; set; }
        public string? OrignalFilename { get; set; }
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

        public string? FilePath { get; set; }

        public bool? isActive { get; set; }

        public bool? isDeleted { get; set; }
        public string? IPAddressBytes { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedBy { get; set; }
    }
}
