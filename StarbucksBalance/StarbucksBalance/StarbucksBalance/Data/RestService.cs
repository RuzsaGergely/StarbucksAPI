using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using StarbucksBalance.Model;

namespace VizoraApp.Data
{
    public class RestService : IRestService
    {
        HttpClient client;
        string server;
        public RestService(string Server)
        {
            client = new HttpClient();
            server = Server;
        }
        
        public async Task<StarbucksData> GetStarbucksData()
        {

            StarbucksData sd = new StarbucksData();

            if (server == "NA")
            {
                sd.currency = "IFM";
                sd.currentAmount = -1;
                sd.currentStars = -1;
                return sd;
            }

            Uri uri = new Uri(string.Format(server, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    sd = JsonConvert.DeserializeObject<StarbucksData>(content);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sd;
        }
        
    }
}
