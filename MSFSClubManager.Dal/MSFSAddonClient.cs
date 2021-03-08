using MSFSClubManager.Dal.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MSFSClubManager.Models.Models;
using MSFSClubManager.Dal.ViewModels;

namespace MSFSClubManager.Dal
{


    public class MSFSAddonClient
    {
        HttpClient client;
        HttpContent baseContent;

        private string ApiUrl = "https://api-msfsaddonshub.com/";
        private string GetAllAddonsEndPOint = "Addons/GetAll/";
        private string Authenticate = "/authenticate";

        public JWTToken currentToken { get; set; }
        public MSFSAddonClient()
        {
            client = new HttpClient();
            currentToken = new JWTToken();
            client.BaseAddress = new Uri(ApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task AuthenticateUser()
        {
            var requestUri = string.Format(ApiUrl + Authenticate);

            AuthenticateRequest myuser = new AuthenticateRequest();
            myuser.Username = "davidbuckleyweb@outlook.com";
            myuser.Password = "test12345!";
            JWTToken _result = new JWTToken();
            string stringPayload = JsonConvert.SerializeObject(myuser);
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            // Do the actual request and await the response
            var httpResponse = await client.PostAsync(requestUri, httpContent);
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                _result = JsonConvert.DeserializeObject<JWTToken>(responseContent);
            }

            currentToken = _result;


        }

        public async Task<List<AddonsViewModel>> GetAllAddons()
        {
            string requestUri = string.Format(ApiUrl + GetAllAddonsEndPOint);
            var responseContent = "";

            List<AddonsViewModel> _result = new List<AddonsViewModel>();
            client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", currentToken.jwtToken);
            HttpResponseMessage result = await client.GetAsync(requestUri);


            if (result.IsSuccessStatusCode)
            {
                responseContent = await result.Content.ReadAsStringAsync();
                _result = JsonConvert.DeserializeObject<List<AddonsViewModel>>(responseContent);
            }

            


            return _result;

        }
    }
}
