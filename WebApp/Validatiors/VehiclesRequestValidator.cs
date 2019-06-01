using FluentValidation;
using WebApp.Models.Requests;

namespace WebApp.Validatiors
{
    public class VehiclesRequestValidator : AbstractValidator<VehiclesRequest>
    {
        public VehiclesRequestValidator()
        {
            RuleFor(x => x.LineNumber).NotNull().WithMessage("Line number format is not valid.");
            RuleFor(x => x.LineNumber).GreaterThan(0).WithMessage("Only positive numbers are allowed.");
        }
    }
}