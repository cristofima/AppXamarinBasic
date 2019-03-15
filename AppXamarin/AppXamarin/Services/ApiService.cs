using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppXamarin.Services
{
    public class ApiService
    {
        public async Task<object> GetList<T>(string urlBase, string servicePrefix)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);
                var response = await client.GetAsync(servicePrefix);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var list = JsonConvert.DeserializeObject<List<T>>(result);
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}