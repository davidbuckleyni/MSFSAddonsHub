using CG.Web.MegaApiClient;
using Microsoft.Extensions.Options;
using MSFSAddonsHub.Dal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace MSFSAddonsHub.FL
{
    public  class FileClient
    {
        private readonly IOptions<FileTransferConfig> transferSettings;

        public FileClient(IOptions<FileTransferConfig> _test)
        {
            transferSettings = _test;

        }
        public void UploadFile(string fileName,string userId)

        {
            var client = new MegaApiClient();
            client.Login(transferSettings.Value.UserName,transferSettings.Value.Password);

            IEnumerable<INode> nodes = client.GetNodes();

            INode root = nodes.Single(x => x.Type == NodeType.Root);
            INode myFolder = client.CreateFolder("MSFSAddons", root);

            INode myFile = client.UploadFile(fileName, myFolder);
            Uri downloadLink = client.GetDownloadLink(myFile);
            Console.WriteLine(downloadLink);

            client.Logout();

        }
    }
}
