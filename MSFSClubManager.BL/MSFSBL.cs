using MSFSClubManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using System.Xml;
using System.Xml.Serialization;

namespace MSFSClubManager.BL
{
    public class MSFSBL
    {

        public SimBaseDocument ConvertFlightToObject(string filename)
        {

            SimBaseDocument result = new SimBaseDocument();
            XmlSerializer serializer = new XmlSerializer(typeof(SimBaseDocument));
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                 result = (SimBaseDocument)serializer.Deserialize(fileStream);


            }
       
           
            return result;
        }
        public void DownloadTestFile()
        {
            GetMSFSAddonDetails("https://www.msfsaddonshub.com/uploads/gotgravel-savage-grravel.zip");
        }

        public void GetMSFSAddonDetails(string zipFileUrl) {
            using (ZipArchive archive = ZipFile.OpenRead(zipFileUrl))
            {
                var sample = archive.GetEntry("manifest.json");
                if (sample != null)
                {
                    using (var zipEntryStream = sample.Open())
                    {

                        
                        // serializer = new XmlSerializer(typeof(SampleClass));

                       /// SampleClass deserialized =
                          //  (SampleClass)serializer.Deserialize(zipEntryStream);
                    }
                }
            }

        }
    }
}
