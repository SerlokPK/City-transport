using FluentValidation;
using WebApp.Models.Requests;

namespace WebApp.Validatiors
{
    public class PriceRequestValidator : AbstractValidator<PriceRequest>
    {
        public PriceRequestValidator()
        {
            RuleFor(x => x.PassengerType).NotNull().WithMessage("Requested line type is not supported. Supported: PENSIONER, STUDENT, REGULAR.");
            RuleFor(x => x.TicketType).NotNull().WithMessage("Requested line type is not supported. Supported: TIME, DAILY, MONTHLY, YEARLY.");
        }
    }
}