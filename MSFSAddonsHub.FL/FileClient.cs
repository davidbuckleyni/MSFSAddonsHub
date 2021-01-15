using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSFSAddonsHub.FL
{
    public class FileClient
    {



        public void UploadFile(string fileName)

        {
            var client = new MegaApiClient();
            client.Login("username@domain.com", "passw0rd");

            IEnumerable<INode> nodes = client.GetNodes();

            INode root = nodes.Single(x => x.Type == NodeType.Root);
            INode myFolder = client.CreateFolder("Upload", root);

            INode myFile = client.UploadFile(filename, myFolder);
            Uri downloadLink = client.GetDownloadLink(myFile);
            Console.WriteLine(downloadLink);

            client.Logout();

        }
    }
}
