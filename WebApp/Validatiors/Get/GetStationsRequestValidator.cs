using FluentValidation;
using WebApp.Models.Requests.Get;

namespace WebApp.Validatiors
{
    public class GetStationsRequestValidator : AbstractValidator<GetStationsRequest>
    {
        public GetStationsRequestValidator()
        {
            RuleFor(x => x.LineNumber).NotNull().WithMessage("Line number format is not valid.");
            RuleFor(x => x.LineNumber).GreaterThan(0).WithMessage("Only positive numbers are allowed.");
        }
    }
}