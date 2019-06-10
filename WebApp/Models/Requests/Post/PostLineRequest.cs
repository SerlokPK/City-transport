using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using WebApp.Persistence.Models;

namespace WebApp.Models.Requests.Post
{
    public class PostLineRequest
    {
        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public int Number { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public LineType LineType { get; set; }

        public List<int> Stations { get; set; }

        public List<DeparturePostRequest> Departures { get; set; }
    }
}