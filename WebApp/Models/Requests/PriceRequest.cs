using FluentValidation.Attributes;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests
{
    [Validator(typeof(PriceRequestValidator))]
    public class PriceRequest
    {
        public PassengerType? PassengerType { get; set; }
        public TicketType? TicketType { get; set; }
    }
}