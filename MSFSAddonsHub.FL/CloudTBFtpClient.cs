
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.Extensions.Configuration;
using MSFSAddons.Models;
using MSFSAddons.Models.Models;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.FL.Interface;

namespace MSFSAddonsHub.FL
{
    public class CloudTBFtpClient : IDisposable, IFileUploadInterface
    {

        public enum FtpTypeEnum
        {
            Ftp = 1,
            SFTP = 2
        }
        private IConfiguration _configRoot;
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;
        private FtpClient client;
        public CloudTBFtpClient(AppSettings _appSettings, FtpTypeEnum ftpType)
        {

            this.host = _appSettings.FTPHost;
            this.port = Convert.ToInt32(_appSettings.FTPPort);
            this.enableSSL = Convert.ToBoolean(_appSettings.FTPEnableSSL);
            this.userName = _appSettings.FTPUserName;
            this.password = _appSettings.FTPPassword;
            // create an FTP client
            client = new FtpClient(host);
            client.Port = port;
            // specify the login credentials, unless you want to use the "anonymous" user account

            if (ftpType == FtpTypeEnum.Ftp)
            {
                FtpConnectAsync();


            }
            else if (ftpType == FtpTypeEnum.SFTP)
            {

                FtpsConnectAsync();
            }
        }

        public void FtpConnectAsync()
        {
            client.Credentials = new NetworkCredential(userName, password);

            client.Connect();


        }
        public void FtpsConnectAsync()
        {
            using (var conn = new FtpClient(host, userName, password))
            {
                conn.EncryptionMode = FtpEncryptionMode.Explicit;
                conn.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
                conn.Connect();
            }
        }
        private static void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
        {
            if (e.PolicyErrors != System.Net.Security.SslPolicyErrors.None)
            {
                // invalid cert, do you want to accept it?
                // e.Accept = true;
            }
            else
            {
                e.Accept = true;
            }
        }

       

        void IDisposable.Dispose()
        {
            client.DisconnectAsync();

        }

        public async Task<double> UploadFileAsync(MSFSAddonDBContext context, string UserName, string Password, string fileName,string destFileName, string extension, string userId, string ipAddress)
        {
            try
            {
                string webRoot = @"\\www\";

                string urlDomain = "https://davidbuckley.cloudtb.online";
                string customPath = @"\www\" + @"\public_html\UserFiles\" + userId + @"\";
                string custompathWebUrl = @"/UserFiles/" + userId + @"/";

                string file = Path.GetFileName(fileName);

                if (!client.DirectoryExists("customPath"))
                    client.CreateDirectory(customPath);

                FileManger uploadRecord = new FileManger();
                Guid.TryParse(userId, out Guid userIdValue);
                string fullFilename = customPath + Path.GetFileName(fileName);
                await client.UploadFileAsync(fileName, fullFilename);

                uploadRecord.UserId = userIdValue;
                uploadRecord.isZipFile = true;
                uploadRecord.HttpDownloadUrl = urlDomain + custompathWebUrl + file;
                uploadRecord.OrignalFilename = file;
                extension = Path.GetExtension(fileName).Replace(".", "");
                if (extension == "lnmp" && extension == "pln")
                    extension = "xml";
                uploadRecord.FileExtensionIcon = extension;
                uploadRecord.FileExtension = Path.GetExtension(fileName).Replace(".", ""); ;
                uploadRecord.isActive = true;
                uploadRecord.IPAddressBytes = ipAddress;
                uploadRecord.isDeleted = false;
                uploadRecord.CreatedDate = DateTime.Now;
                uploadRecord.CreatedBy = UserName;
                uploadRecord.canBeDownloadedByOtherUsers = true;
                context.FileManager.Add(uploadRecord);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {


            }
            return 1;
        }

        public Task<double> DownloadFilesAsync(MSFSAddonDBContext context, string UserName, string Password, string fileName, string extension, string userId, string ipAddress)
        {
            throw new NotImplementedException();
        }
    }
}
