using FluentValidation;
using WebApp.Models.Requests.Get;

namespace WebApp.Validatiors
{

    public class GetSchedulesRequestValidator : AbstractValidator<GetSchedulesRequest>
    {
        public GetSchedulesRequestValidator()
        {
            RuleFor(x => x.DayType).NotNull().WithMessage("Requested day type is not supported. Supported: WORKDAY, SATURDAY, SUNDAY.");
            RuleFor(x => x.LineNumber).NotNull().WithMessage("Requested line number format is not supported.");
            RuleFor(x => x.LineNumber).GreaterThan(0).WithMessage("Only positive numbers are allowed.");
        }
    }
}
