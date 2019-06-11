using FluentValidation;
using WebApp.Models.Requests.Post;

namespace WebApp.Validatiors.Post
{
    public class PostPriceRequestValidator : AbstractValidator<PostPriceRequest>
    {
        public PostPriceRequestValidator()
        {
            RuleFor(x => x.Cost).GreaterThan(0).WithMessage("You must enter positive number.");
            RuleFor(x => x.PassengerType).NotEmpty().WithMessage("Passenger Type format not supported.");
            RuleFor(x => x.TicketType).NotNull().WithMessage("Ticket Type format not supported.");
        }
    }
}