using System;
using System.IO.Compression;
using System.Xml.Serialization;

namespace MSFSAddonsHub.BL
{
    public class MSFSBL
    {


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
