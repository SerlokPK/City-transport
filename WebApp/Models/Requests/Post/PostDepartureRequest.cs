using FluentValidation.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using WebApp.Persistence.Models;
using WebApp.Validatiors.Post;

namespace WebApp.Models.Requests.Post
{
    [Validator(typeof(PostDepartureRequestValidator))]
    public class PostDepartureRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DayType DayType { get; set; }

        public Direction Direction { get; set; }

        public List<string> DepartureTimes { get; set; }
    }
}