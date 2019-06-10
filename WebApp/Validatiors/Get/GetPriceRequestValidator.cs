using FluentValidation;
using WebApp.Models.Requests.Get;

namespace WebApp.Validatiors
{
    public class GetPriceRequestValidator : AbstractValidator<GetPriceRequest>
    {
        public GetPriceRequestValidator()
        {
            RuleFor(x => x.PassengerType).NotNull().WithMessage("Requested line type is not supported. Supported: PENSIONER, STUDENT, REGULAR.");
            RuleFor(x => x.TicketType).NotNull().WithMessage("Requested line type is not supported. Supported: TIME, DAILY, MONTHLY, YEARLY.");
        }
    }
}