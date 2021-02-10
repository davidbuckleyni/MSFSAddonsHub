using MSFSAddons.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;

namespace MSFSAddonsHub.FL
{
    public class FileManagerClient
    {
        public enum FileStorageTypeEnum
        {
            MegaUpload = 1,
            FTPUpload = 2,
            DropBox = 3


        }

        public DropBoxApiClient clientDropBox;

        public FileManagerClient(FileManger Files, FileStorageTypeEnum storageType)
        {

            if (storageType == FileStorageTypeEnum.DropBox)
            {
                clientDropBox = new DropBoxApiClient();
            }
            else if (storageType == FileStorageTypeEnum.MegaUpload)
            {

            }
            else if (storageType == FileStorageTypeEnum.FTPUpload)
            {

            }

        }

        public void UploadFilesToStorage(FileManger files, FileStorageTypeEnum storageType)
        {
        }

    }

}
