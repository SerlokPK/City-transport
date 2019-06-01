using FluentValidation;
using WebApp.Models.Requests;

namespace WebApp.Validatiors
{

    public class SchedulesRequestValidator : AbstractValidator<SchedulesRequest>
    {
        public SchedulesRequestValidator()
        {
            RuleFor(x => x.DayType).NotNull().WithMessage("Requested day type is not supported.");
            RuleFor(x => x.LineNumber).NotNull().WithMessage("Requested line number format is not supported.");
            RuleFor(x => x.LineNumber).GreaterThan(0).WithMessage("Only positive numbers are allowed.");
        }
    }
}
