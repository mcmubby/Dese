using System.Collections;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
// using System.Collections;
// using Newtonsoft.Json;

namespace httprequest
{
    public class Data
    {
        // public HttpClient Client { get; }

        // public Data(HttpClient client)
        // {
        //     client.BaseAddress = new Uri("https://coderbyte.com/api/challenges/json/json-cleaning");

        //     Client = client;
        // }
        
        // public async Task<Object> GetData()
        // {
        //     var response = await Client.GetAsync("");
        //     Client.PostAsync("/read",)
        //     if (response.IsSuccessStatusCode)
        //     {
        //         var data = await response.Content.ReadAsStringAsync();
        //         return JsonConvert.DeserializeObject<Object>(data); 
        //        // var result = await JsonSerializer.DeserializeAsync(data);
        //         //Console.Write(data);
        //     }
        //     return null;
        // }

        public HttpClient Client { get; }
        private const string pluginId = "6131f73d569dbbb7ce5b4fc5";

        public Data(HttpClient client)
        {
            client.BaseAddress = new Uri("https://zccore.herokuapp.com/data/");

            Client = client;
        }

        //Get all data from zc_core without filter from a collection
        public async Task<JsonResponse> ReadData(string collectionName, string organizationId)
        {
            var dataUrl = $"read/{pluginId}/{collectionName}/{organizationId}";
            var response = await Client.GetAsync(dataUrl);
            var responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<JsonResponse>(responseStream);
        }

        public async Task PostData<TDataModel>(string collectionName, string organizationId, TDataModel dataModel)
        {
            var body = new DataWriteModel<TDataModel>
            {
                plugin_id = pluginId,
                organization_id = organizationId,
                collection_name = collectionName,
                bulk_write = false,
                payload = dataModel
            };

            var jsonBody = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(body),
                Encoding.UTF8, "application/json"
            );

            using var response = await Client.PostAsync("write", jsonBody);
            response.EnsureSuccessStatusCode();
        }
    }
}