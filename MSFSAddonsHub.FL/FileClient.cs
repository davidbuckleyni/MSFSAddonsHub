using CG.Web.MegaApiClient;
using Microsoft.Extensions.Options;
using MSFSAddons.Models;
using MSFSAddonsHub.Dal;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MSFSAddonsHub.FL
{
    public  class FileClient
    {
        private readonly IOptions<FileTransferConfig> transferSettings;

    
        void Main()
        {
            var client = new MegaApiClient();
            client.LoginAnonymous();

            Uri folderLink = new Uri("https://mega.nz/#F!e1ogxQ7T!ee4Q_ocD1bSLmNeg9B6kBw");
            IEnumerable<INode> nodes = client.GetNodesFromLink(folderLink);
            foreach (INode node in nodes.Where(x => x.Type == NodeType.File))
            {
                Console.WriteLine($"Downloading {node.Name}");
                client.DownloadFile(node, node.Name);
            }

            client.Logout();
        }
        private CancellationTokenSource uploadCancellationTokenSource = new CancellationTokenSource();

    public async Task<double> UploadFileAsync(MSFSAddonDBContext context, string UserName,string Password, string fileName,string extension,string userId,string ipAddress)        {
        double progressValue=0.00;
        var client = new MegaApiClient();
        client.Login(UserName, Password);
            
        IEnumerable<INode> nodes = client.GetNodes();

        INode root = nodes.Single(x => x.Type == NodeType.Root);
        INode myFolder = nodes.SingleOrDefault(x => x.ParentId == root.Id && x.Type == NodeType.Directory && x.Name == userId) ?? client.CreateFolder(userId, root);
        var progress = new Progress<double>();
        progress.ProgressChanged += (s, progressValue) =>
        {
            //Update the UI (or whatever) with the progressValue 
            progressValue = Convert.ToInt32(progressValue);
        };
        if (uploadCancellationTokenSource.IsCancellationRequested)
        {
            uploadCancellationTokenSource.Dispose();
            uploadCancellationTokenSource = new CancellationTokenSource();
        }

        INode myFile =await client.UploadFileAsync(fileName, myFolder,progress, uploadCancellationTokenSource.Token);
        Uri downloadLink = client.GetDownloadLink(myFile);
        Console.WriteLine(downloadLink);
        FileManger uploadRecord= new FileManger();
        Guid.TryParse(userId, out Guid userIdValue);
        uploadRecord.UserId = userIdValue;
        uploadRecord.isZipFile = true;
        uploadRecord.OrignalFilename = fileName;
        uploadRecord.FileExtension = Path.GetExtension(fileName);
        uploadRecord.isActive = true;
        uploadRecord.IPAddressBytes = ipAddress;
        uploadRecord.isDeleted = false;
        uploadRecord.CreatedDate = DateTime.Now;
        uploadRecord.CreatedBy = UserName;
        uploadRecord.canBeDownloadedByOtherUsers = true;
        uploadRecord.DownloadLink = downloadLink.ToString();
        var upload = context.FileManager.Add(uploadRecord);
        await context.SaveChangesAsync();
        client.Logout();

        return progressValue;
    }
    }
}
