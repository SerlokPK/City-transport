using FluentValidation;
using WebApp.Models.Requests.Post;

namespace WebApp.Validatiors.Post
{
    public class PostStationRequestValidator : AbstractValidator<PostStationRequest>
    {
        public PostStationRequestValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("You must enter address.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("You must enter name.");
            RuleFor(x => x.LineIds).NotEmpty().WithMessage("You must add lines to the station.");
        }
    }
}