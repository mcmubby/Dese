using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace httprequest
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Datum
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("VisitCount")]
        public int VisitCount { get; set; }

        [JsonProperty("_id")]
        public string Identity { get; set; }
    }

    public class JsonResponse
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }
    }


}