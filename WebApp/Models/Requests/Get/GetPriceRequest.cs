using FluentValidation.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetPriceRequestValidator))]
    public class GetPriceRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PassengerType? PassengerType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TicketType? TicketType { get; set; }
    }
}