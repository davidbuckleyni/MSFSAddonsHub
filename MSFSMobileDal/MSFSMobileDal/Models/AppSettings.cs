using System;
using System.Collections.Generic;
using System.Text;

namespace MSFSAddons.Models.Models
{
    public class AppSettings
    {

        public string Secret { get; set; }

        public string MegaUserName { get; set; }
        public string MegaPassword { get; set; }

        public string MegaAPIKey { get; set; }

        public string EmailHost { get; set; }

        public string EmailPort { get; set; }

        public string EnableSSL { get; set; }

        public string EmailUserName { get; set; }

        public string EmailPassword { get; set; }

        public string FTPHost { get; set; }

        public string FTPPort { get; set; }
        public string FTPEnableSSL { get; set; }
        public string FTPUserName { get; set; }
        public string FTPPassword { get; set; }
 
    }
}
