using FluentValidation;
using WebApp.Models.Requests.Post;

namespace WebApp.Validatiors.Post
{
    public class PostLineRequestValidator : AbstractValidator<PostLineRequest>
    {
        public PostLineRequestValidator()
        {
            RuleFor(x => x.EndLocation).NotEmpty().WithMessage("You must enter end location.");
            RuleFor(x => x.StartLocation).NotEmpty().WithMessage("You must enter start location.");
            RuleFor(x => x.Number).GreaterThan(0).WithMessage("Only positive numbers are allowed.");
            RuleFor(x => x.LineType).NotNull().WithMessage("Line type format not supported.");
        }
    }
}