
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
using Dropbox.Api;
using Dropbox.Api.Common;
using Dropbox.Api.Files;
using Dropbox.Api.Team;
using System.IO.Compression;
using System.Linq;

namespace MSFSAddonsHub.FL
{
    public class DropBoxApiClient 
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
        static readonly int IsCompressed = 1; //Set Flag = 1 to unzip file
        public string DropboxFolderPath { get; set; }
        public string DestFile { get; set; }

        public string DropboxApiKey { get; set; }
        public string reportName;
        public DropBoxApiClient()
        {

        
          
        }

        //Task<double> UploadFileAsync(MSFSAddonDBContext context, string UserName, string Password, string fileName, string extension, string userId, string ipAddress)
        //{
 
        //   string  filePath = DropboxFolderPath + DestFile;  //Replace with your filename
        //    using (var client = new DropboxClient(DropboxApiKey))
        //    {
        //        using (var stream = IsFileCompressedCheck(fileName))
        //        {
        //            var resp = client.Files.UploadAsync(filePath, WriteMode.Overwrite.Instance, body: stream).Result;
        //        }
        //    }
        //    Console.WriteLine($"Saved to {filePath}\n\n");

        //}

        private static Stream IsFileCompressedCheck(Stream file)
        {
            if (IsCompressed == 1)
            {
                file = UnZip(file);
            }

            return file;
        }

        private static Stream UnZip(Stream file)
        {
            using (ZipArchive archive = new ZipArchive(file, ZipArchiveMode.Read))
            {
                ZipArchiveEntry entry = archive.Entries.FirstOrDefault();
                using (StreamReader reader = new StreamReader(entry.Open()))
                {
                    MemoryStream stream = new MemoryStream();
                    StreamWriter writer = new StreamWriter(stream);
                    writer.Write(reader.ReadToEnd());
                    writer.Flush();
                    stream.Position = 0;
                    file = stream;
                    string reportName = entry.Name;
                    Console.WriteLine(entry.Name);
                }
            }

            return file;
        }
    }     
}
