using FluentValidation.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetSchedulesRequestValidator))]
    public class GetSchedulesRequest
    {
        public int? LineNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DayType? DayType { get; set; }
    }
}