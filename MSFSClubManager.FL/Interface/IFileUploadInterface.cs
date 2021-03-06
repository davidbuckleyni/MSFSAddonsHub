﻿using MSFSClubManager.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSFSClubManager.FL.Interface
{
    public interface IFileUploadInterface
    {
         Task<double> UploadFileAsync(MSFSClubManagerDBContext context, string UserName, string Password, string fileName,string destFileName, string extension, string userId, string ipAddress);
        Task<double> DownloadFilesAsync(MSFSClubManagerDBContext context, string UserName, string Password, string fileName, string extension, string userId, string ipAddress);

    }
}
