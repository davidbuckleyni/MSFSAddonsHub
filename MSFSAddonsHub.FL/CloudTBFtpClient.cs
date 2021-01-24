
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.Extensions.Configuration;
using MSFSAddons.Models;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.FL.Interface;

namespace MSFSAddonsHub.FL
{
    public class CloudTBFtpClient : IDisposable
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
        public CloudTBFtpClient(IConfiguration configRoot, FtpTypeEnum ftpType)
        {
            _configRoot = (IConfigurationRoot)configRoot;
            this.host = _configRoot.GetValue<string>("FTPHost");
            this.port = Convert.ToInt32(_configRoot.GetValue<string>("FTPPort"));
            this.enableSSL = Convert.ToBoolean(_configRoot.GetValue<string>("FTPEnableSSL"));
            this.userName = _configRoot.GetValue<string>("FTPUserName");
            this.password = _configRoot.GetValue<string>("FTPPassword");
            // create an FTP client
            client = new FtpClient(host);
            // specify the login credentials, unless you want to use the "anonymous" user account

            if (ftpType == FtpTypeEnum.Ftp)
            {
                var t = Task.Run(() => FtpConnectAsync());
            }
            else if (ftpType == FtpTypeEnum.SFTP)
            {

                FtpsConnectAsync();
            }
        }

        public async Task<int> FtpConnectAsync()
        {
            client.Credentials = new NetworkCredential(userName, password);

            await client.ConnectAsync();
            return 1;

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

        public async Task<double> UploadFileAsync(MSFSAddonDBContext context, string UserName, string Password, string fileName, string destFilename, string extension, string userId, string ipAddress)
        {

            string customPath = userId + @"\" + Path.GetFileName(fileName) + Path.GetExtension(fileName);


            await client.UploadFileAsync(fileName, destFilename);

            FileManger uploadRecord = new FileManger();
            Guid.TryParse(userId, out Guid userIdValue);

            uploadRecord.UserId = userIdValue;
            uploadRecord.isZipFile = true;
            uploadRecord.OrignalFilename = customPath;
            uploadRecord.FileExtension = Path.GetExtension(fileName);
            uploadRecord.isActive = true;
            uploadRecord.IPAddressBytes = ipAddress;
            uploadRecord.isDeleted = false;
            uploadRecord.CreatedDate = DateTime.Now;
            uploadRecord.CreatedBy = UserName;
            uploadRecord.canBeDownloadedByOtherUsers = true;
            var upload = context.FileManager.Add(uploadRecord);
            await context.SaveChangesAsync();
            return 1;
        }

        void IDisposable.Dispose()
        {
            client.DisconnectAsync();

        }
    }
}
