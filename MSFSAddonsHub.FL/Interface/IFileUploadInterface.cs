using MSFSAddonsHub.Dal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.FL.Interface
{
    public interface IFileUploadInterface
    {
        Task<double> UploadFileAsync(MSFSAddonDBContext context, string UserName, string Password, string fileName, string extension, string userId, string ipAddress);

    }
}
