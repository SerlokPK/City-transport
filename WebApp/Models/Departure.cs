using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApp.Persistence.Models;

namespace WebApp.Models
{
    public class Departure
    {
        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DayType DayType { get; set; }

        public string DeparturesAt { get; set; }

        public int LineDbModelId { get; set; }
    }
}