using MSFSClubManager.Models;
using MSFSClubManager.Models.Models;
using MSFSClubManager.BL;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Net.Http;
using System.Xml;
using System.Xml.Serialization;
using AngleSharp;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp.Html.Dom;
using AngleSharp.Dom;

namespace MSFSClubManager.Tests
{
    public class AngleSharp
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task RipVersionNumberFlightSimTo()
        {
            var testint = 1;
            var config = Configuration.Default.WithDefaultLoader();
            var address = "https://flightsim.to/file/8709/en10-hasslemoen-airstrip-norway";
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(address);
            var cellSelector = "table table-striped";
            var cells = document.QuerySelectorAll(cellSelector);
            var titles = cells.Select(m => m.TextContent);
            var links = document
     .Links
     .OfType<IHtmlAnchorElement>()
     .Select(e => e.Href)
     .Where(h => h.Contains("Version"));



        }

        //[TestCase (@"VFR_Pamplona_LEPP_to_Camaleno-Artanin_Ulm_LECW.pln")]
        //public   void LoadMSFSFlightPlanTest(string filename)
        //{
        //        MSFSBL _import = new MSFSBL();

        //        var jsonPln=_import.ConvertFlightToObject(filename);
        //    }

        //}

    }
}