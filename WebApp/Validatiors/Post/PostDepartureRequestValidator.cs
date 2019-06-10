using FluentValidation;
using WebApp.Models.Requests.Post;

namespace WebApp.Validatiors.Post
{
    public class PostDepartureRequestValidator : AbstractValidator<PostDepartureRequest>
    {
        public PostDepartureRequestValidator()
        {
            RuleFor(x => x.DayType).NotNull().WithMessage("Day type format not supported");
            RuleFor(x => x.Direction).NotNull().WithMessage("Direciton format not supported.");
        }
    }
}