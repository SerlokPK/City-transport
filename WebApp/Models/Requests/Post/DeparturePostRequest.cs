using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using WebApp.Persistence.Models;

namespace WebApp.Models.Requests.Post
{
    public class DeparturePostRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DayType DayType { get; set; }

        public Direction Direction { get; set; }

        public List<string> DepartureTimes { get; set; }
    }
}