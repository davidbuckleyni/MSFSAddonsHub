using MSFSClubManager.Models;
using MSFSClubManager.Models.Models;
using MSFSClubManager.BL;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;

namespace MSFSClubManager.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

    [TestCase (@"VFR_Pamplona_LEPP_to_Camaleno-Artanin_Ulm_LECW.pln")]
    public   void LoadMSFSFlightPlanTest(string filename)
    {
            MSFSBL _import = new MSFSBL();

            var jsonPln=_import.ConvertFlightToObject(filename);
        }
         
    }
}