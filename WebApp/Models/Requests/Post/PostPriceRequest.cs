using FluentValidation.Attributes;
using WebApp.Persistence.Models;
using WebApp.Validatiors.Post;

namespace WebApp.Models.Requests.Post
{
    [Validator(typeof(PostPriceRequestValidator))]
    public class PostPriceRequest
    {
        public int Cost { get; set; }
        public PassengerType? PassengerType { get; set; }
        public TicketType? TicketType { get; set; }
    }
}