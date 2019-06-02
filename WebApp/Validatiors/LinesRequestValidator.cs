using FluentValidation;
using WebApp.Models.Requests;

namespace WebApp.Validatiors
{
    public class LinesRequestValidator : AbstractValidator<LinesRequest>
    {
        public LinesRequestValidator()
        {
            RuleFor(x => x.LineType).NotNull().WithMessage("Requested line type is not supported. Supported: URBAN, SUBURBAN.");
        }
    }
}