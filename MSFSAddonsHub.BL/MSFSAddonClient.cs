using MSFSAddonsHub.Dal.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MSFSAddonsHub.BL
{


    public class MSFSAddonClient
    {
        HttpClient client;
        HttpContent baseContent;
        public MSFSAddonClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(MSFSAddonClientConstants.ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            JObject tokenJobject = new JObject(
                                       new JProperty("username", "davidbuckleyweb@outlook.com"),
                                       new JProperty("Password", "test12345!"));
            baseContent = new StringContent(tokenJobject.ToString(), Encoding.UTF8, "application/json");




        }

        public async Task<List<Addons>> GetAllAddons()
        {
            string requestUri = string.Format(MSFSAddonClientConstants.GetAllAddons);
            List<Addons> _result = new List<Addons>();

            HttpResponseMessage responseMessage = await client.PostAsync(requestUri, baseContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                var byteArray = await responseMessage.Content.ReadAsByteArrayAsync();

                var content = Encoding.UTF8.GetString(byteArray, 0, byteArray.Length);
                _result = JsonConvert.DeserializeObject<List<Addons>>(content);
            }


            return _result;

        }
    }
}
