using FluentValidation.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using WebApp.Persistence.Models;
using WebApp.Validatiors.Post;

namespace WebApp.Models.Requests.Post
{
    [Validator(typeof(PostLineRequestValidator))]
    public class PostLineRequest
    {
        public string StartLocation { get; set; }

        public string EndLocation { get; set; }

        public int Number { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public LineType? LineType { get; set; }

        public List<int> Stations { get; set; }

        public List<PostDepartureRequest> Departures { get; set; }
    }
}