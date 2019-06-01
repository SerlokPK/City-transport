using FluentValidation.Attributes;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests
{
    [Validator(typeof(LinesRequestValidator))]
    public class LinesRequest
    {
        public LineType? LineType { get; set; }
    }
}