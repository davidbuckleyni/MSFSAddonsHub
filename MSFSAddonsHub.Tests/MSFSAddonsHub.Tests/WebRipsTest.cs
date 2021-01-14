using NUnit.Framework;
using System.Net.Http;

namespace MSFSAddonsHub.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void Test1()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            var content = await client.GetStringAsync("https://flightsim.to/file/5359/savage-grravel-gotgravel-repaint-in-stol-addicts-livery");
 

            Assert.Pass();
        }
    }
}