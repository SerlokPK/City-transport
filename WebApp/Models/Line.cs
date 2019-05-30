using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using WebApp.Persistence.Models;

namespace WebApp.Models
{
    public class Line
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Number { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public LineType LineType { get; set; }

        public List<Station> Stations { get; set; }

        public List<string> Departures { get; set; }
    }
}