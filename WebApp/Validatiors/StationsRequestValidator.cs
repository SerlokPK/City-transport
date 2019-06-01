using FluentValidation;
using WebApp.Models.Requests;

namespace WebApp.Validatiors
{
    public class StationsRequestValidator : AbstractValidator<StationsRequest>
    {
        public StationsRequestValidator()
        {
            RuleFor(x => x.LineNumber).NotNull().WithMessage("Line number format is not valid.");
            RuleFor(x => x.LineNumber).GreaterThan(0).WithMessage("Only positive numbers are allowed.");
        }
    }
}