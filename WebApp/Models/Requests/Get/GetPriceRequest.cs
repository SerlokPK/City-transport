using FluentValidation.Attributes;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetPriceRequestValidator))]
    public class GetPriceRequest
    {
        public PassengerType? PassengerType { get; set; }
        public TicketType? TicketType { get; set; }
    }
}