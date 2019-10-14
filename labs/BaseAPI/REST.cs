using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BaseAPI
{
    class REST
    {
        static HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            
        }

        static async Task<T> GetAsync<T>(string path, int itemID)
        {
            Console.WriteLine("Getting Task Item");
            var response = await client.GetAsync(path + itemID);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                T item = JsonConvert.DeserializeObject<T>(responseString);
                var objectAsJson = response.Content.ReadAsStringAsync();
                var objectAsTask = JsonConvert.DeserializeObject<T>(objectAsJson.Result);
                return objectAsTask;
            }

            return default;
        }

        static Item DeserializeObject<Item>(HttpResponseMessage response)
        {
            var objectAsJson = response.Content.ReadAsStringAsync();
            var objectAsTask = JsonConvert.DeserializeObject<Item>(objectAsJson.Result);
            return objectAsTask;
        }
    }
}
