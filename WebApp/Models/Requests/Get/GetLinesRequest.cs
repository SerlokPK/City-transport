using FluentValidation.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetLinesRequestValidator))]
    public class GetLinesRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public LineType? LineType { get; set; }
    }
}