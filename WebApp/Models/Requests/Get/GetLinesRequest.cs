using FluentValidation.Attributes;
using WebApp.Persistence.Models;
using WebApp.Validatiors;

namespace WebApp.Models.Requests.Get
{
    [Validator(typeof(GetLinesRequestValidator))]
    public class GetLinesRequest
    {
        public LineType? LineType { get; set; }
    }
}