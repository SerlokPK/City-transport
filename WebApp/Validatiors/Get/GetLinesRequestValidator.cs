using FluentValidation;
using WebApp.Models.Requests.Get;

namespace WebApp.Validatiors
{
    public class GetLinesRequestValidator : AbstractValidator<GetLinesRequest>
    {
        public GetLinesRequestValidator()
        {
            RuleFor(x => x.LineType).NotNull().WithMessage("Requested line type is not supported. Supported: URBAN, SUBURBAN.");
        }
    }
}